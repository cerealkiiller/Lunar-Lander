using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myrigidbody;

    public int jump = 8;
    public bool play = true;
    public AudioSource asource;
    private Vector2 speed;
    private logicScript logic;
    private bool press = false;
    public Sprite r1;
    public Sprite r2;
    public PolygonCollider2D r1h;
    public PolygonCollider2D r2h;

    public SpriteRenderer spriterenderer;
    public bool explode = false;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
        if (mainMenuScript.type == 1)
        {
            spriterenderer.sprite = r1;
            r1h.enabled = true;
            r2h.enabled = false;

        }
        else
        {
            spriterenderer.sprite = r2;
            r1h.enabled = false;
            r2h.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = myrigidbody.velocity;

        if (play)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {

                press = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                press = false;
            }


            if (press)
            {
                myrigidbody.velocity = Vector2.up * jump;
                if (mainMenuScript.sound) { asource.Play(); }

            }

        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (play)
        {
            if (col.gameObject.layer == 3)
            {
                play = false;
                if (speed.y > -6)
                {
                    logic.winGame();
                }
                else
                {
                    logic.looseGame();
                    explode = true;
                    spriterenderer.enabled = false;
                }
                if (-speed.y < PlayerPrefs.GetFloat("highScore", 100))
                {
                    PlayerPrefs.SetFloat("highScore", -speed.y);
                }
            }
        }
    }
}
