using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {

    public float MinTorque;
    public float MaxTorque;
    public float MinForce;
    public float MaxForce;
    public GameObject Explosion;
    public Rigidbody2D rb;
    public float ScreenLimitRight;
    public float ScreenLimitLeft;
    public float ScreenLimitTop;
    public float ScreenLimitBottom;
    public GameObject SmallerAsteroid;
    public int NumSmallerAsteroids = 2;

    private float hitdelay = 2f;
    void Start ()
    {
        float InitialForce = Random.Range(MinForce, MaxForce);

        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(InitialForce * new Vector2(x,y));

        float InitialTorque = Random.Range(MinTorque, MaxTorque);

        rb.AddTorque(InitialTorque);
    }
	
	void Update ()
    {
        if (hitdelay >= 0)
        {
            hitdelay -= Time.deltaTime;
        }
        else
        {

        }
        float a = transform.position.x;
        float b = transform.position.y;

        if (a > ScreenLimitRight)
        {
            a = ScreenLimitLeft;
        }

        if (a < ScreenLimitLeft)
        {
            a = ScreenLimitRight;
        }

        if (b > ScreenLimitTop)
        {
            b = ScreenLimitBottom;
        }

        if (b < ScreenLimitBottom)
        {
            b = ScreenLimitTop;
        }
        
        transform.position = new Vector3(a, b, transform.position.z);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "ship_bullet")
        {
            if (gameObject.tag == "Asteroid_large")
            {
                Instantiate(Explosion, transform.position, new Quaternion());
                Destroy(gameObject);
                Destroy(collider.gameObject);

                if (SmallerAsteroid != null)
                {
                    for (int i = 0; i < NumSmallerAsteroids; i++)
                    {
                        Instantiate(SmallerAsteroid, transform.position, new Quaternion());
                    }
                }
            }
            else
            {
                if (hitdelay < 0)
                {
                    Instantiate(Explosion, transform.position, new Quaternion());
                    Destroy(gameObject);
                    Destroy(collider.gameObject);

                    if (SmallerAsteroid != null)
                    {
                        for (int i = 0; i < NumSmallerAsteroids; i++)
                        {
                            Instantiate(SmallerAsteroid, transform.position, new Quaternion());
                        }
                    }
                }
            }
            
        }
    }
}
