using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrustCode : MonoBehaviour
{
    // Start is called before the first frame update
    private rocketScript rocket;
    public Rigidbody2D myrigidbody;
    
    public ParticleSystem thrust;
    private bool press = false;
    void Start()
    {
        rocket = GameObject.FindGameObjectWithTag("rocket").GetComponent<rocketScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rocket.play)
        {
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
            {
                
                press = true;
            }
            else if(Input.GetKeyUp(KeyCode.Space)|| Input.GetMouseButtonUp(0)){
                press = false;
            }


            if(press){
                thrust.Play();
                myrigidbody.velocity = Vector2.up * rocket.jump;

            }
            else{
                thrust.Stop();
            }
            
        }
    }
}
