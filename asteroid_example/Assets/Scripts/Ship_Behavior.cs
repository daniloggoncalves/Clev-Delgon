using UnityEngine;
using System.Collections;

public class Ship_Behavior : MonoBehaviour {
    public ParticleSystem Thrust_Particle_Effect;
    public GameObject BulletPrefab;
    public GameObject ShipExplosion;
    public float ProxSpeed;
    public float DistanceRadio;


    private GameObject shipExplosion;


    void Start()
    {

    }

    void Update()
    {

        PositionAndThrust();
    }

	void FixedUpdate()
    {

        for (var i = 0; i < Input.touchCount; i++) {
            Direction();
            Shoot();
        }
    }

    void PositionAndThrust()
    {
        Touch touch_one = Input.GetTouch(0);

        if (touch_one.phase != TouchPhase.Ended)
        {
            Thrust_Particle_Effect.Play();

            if (Mathf.Abs(((touch_one.position.y / (float)Screen.height) * 800.0f - 250.0f) - transform.position.y) < DistanceRadio &&
                Mathf.Abs(((touch_one.position.x / (float)Screen.width) * 1280.0f - 640.0f) - transform.position.x) < DistanceRadio)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            else
            {
                float angle = Mathf.Atan2(
           ((touch_one.position.y / (float)Screen.height) * 800.0f - 250.0f) - transform.position.y,
           ((touch_one.position.x / (float)Screen.width) * 1280.0f - 640.0f) - transform.position.x);
                
                GetComponent<Rigidbody2D>().velocity = (new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * ProxSpeed);
            }
            
            if (GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0)){
                Thrust_Particle_Effect.Stop();
            }
        }

        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Thrust_Particle_Effect.Stop();
        }

    }

    void Direction()
    {
        Touch touch_two = Input.GetTouch(1);
        if (touch_two.phase != TouchPhase.Ended) {
            float angle = Mathf.Atan2(
        transform.position.y - ((touch_two.position.y / (float)Screen.height) * 800.0f - 250.0f),
        transform.position.x - ((touch_two.position.x / (float)Screen.width) * 1280.0f - 640.0f)) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + 90);
        }
    }

    void Shoot()
    {
        Touch touch_two = Input.GetTouch(1);

        if (touch_two.phase != TouchPhase.Ended)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Asteroid"|| collider.gameObject.tag == "AlienBullet" || collider.gameObject.tag == "Alien" || collider.gameObject.tag == "Asteroid_large")
        {
             Destroy(gameObject);
             Destroy(collider.gameObject);
             Instantiate(ShipExplosion, transform.position, new Quaternion());
        }
    }
}
