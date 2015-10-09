using UnityEngine;
using System.Collections;

public class AlienBullet : MonoBehaviour{

    public float BulletForce;
    public float BulletLife;
    public Rigidbody2D rb;

    private float Life;

    void Start()
    {
        Life = BulletLife;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(BulletForce * transform.up);
    }


    void Update()
    {
        Life -= Time.deltaTime;
        if (Life < 0) Destroy(gameObject);

    }
}
