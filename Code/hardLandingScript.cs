using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hardLandingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particle;
    private rocketScript rocket;
    public float etime = 1;
    private float time;
    public AudioSource sound;
    void Start()
    {
        rocket = GameObject.FindGameObjectWithTag("rocket").GetComponent<rocketScript>();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (rocket.explode)
        {
            time += Time.deltaTime;
            particle.Play();
            if (mainMenuScript.sound) { sound.Play(); }
            if (time > etime)
            {
                particle.Stop();
                rocket.explode = false;
            }
        }
    }

}
