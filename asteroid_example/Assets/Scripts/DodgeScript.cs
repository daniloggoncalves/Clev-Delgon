using UnityEngine;
using System.Collections;

public class DodgeScript : MonoBehaviour {

    public GameObject Aliens;
    public float Delay = 0.5f;

    private float turningForce;
    private float delay;
    void Start ()
    {
        turningForce= Aliens.GetComponent<AlienScript>().MaxForce;
	}
	
	void Update ()
    {
        delay = -Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (delay < 0f)
        {
            Aliens.GetComponent<Rigidbody2D>().AddForce(-Aliens.GetComponent<Rigidbody2D>().velocity.normalized * turningForce);
            delay = Delay;
        }
    }
}
