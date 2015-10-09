using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    public float BulletForce;
    public Rigidbody2D rb;
    public float BulletLife;

	void Start ()
    {
        Destroy(gameObject, BulletLife);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(BulletForce * transform.up);
	}
	
	
	void Update ()
    {

    }
}
