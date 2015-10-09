using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour {

    public float MinForce = 5f;
    public float MaxForce = 10f;
    public float DirectionChangeInterval = 1f;
    public float ShotInterval = 1f;
    public GameObject AlienBullet;
    public Rigidbody2D rb;
    public float ScreenLimitRight;
    public float ScreenLimitLeft;
    public float ScreenLimitTop;
    public float ScreenLimitBottom;
    public GameObject AlienExplosion;

    private GameObject ship;
    private float directionChangeInterval;
    private float shotinterval;

    void Start()
    {
        directionChangeInterval = DirectionChangeInterval;

        shotinterval = ShotInterval;

        Push();
    }

    void Update()
    {

        directionChangeInterval -= Time.deltaTime;
        if (directionChangeInterval < 0)
        {
            Push();
            directionChangeInterval = DirectionChangeInterval;
        }

        shotinterval -= Time.deltaTime;
        if (shotinterval < 0)
        {
            Shoot();
            shotinterval = ShotInterval;
        }

        float x = transform.position.x;
        float y = transform.position.y;

        ship = UnityEngine.GameObject.FindGameObjectWithTag("ship");
        if (ship != null)
        {
            float angle = Mathf.Atan2(
            ship.transform.position.y - transform.position.y,
            ship.transform.position.x - transform.position.x
            ) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }



        if (x > ScreenLimitRight)
        {
            x = ScreenLimitLeft;
        }

        if (x < ScreenLimitLeft)
        {
            x = ScreenLimitRight;
        }

        if (y > ScreenLimitTop)
        {
            y = ScreenLimitBottom;
        }

        if (y < ScreenLimitBottom)
        {
            y = ScreenLimitTop;
        }

        transform.position = new Vector3(x, y, transform.position.z);
    }

    void Push()
    {
        float force = Random.Range(MinForce, MaxForce);
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, 0f);
        rb.AddForce(force * new Vector2(x, y));
    }

    void Shoot()
    {
        ship = UnityEngine.GameObject.FindGameObjectWithTag("ship");

        if (ship != null)
        { 
            float angle = Mathf.Atan2(
                ship.transform.position.y - transform.position.y,
                ship.transform.position.x - transform.position.x
                ) * Mathf.Rad2Deg;

            Instantiate(AlienBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle - 90)));
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ship_bullet")
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);
            Instantiate(AlienExplosion, transform.position, new Quaternion());
        }
    }
}