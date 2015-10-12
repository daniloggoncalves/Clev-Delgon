using UnityEngine;
using System.Collections;

public class VillagerBehavior : MonoBehaviour {

    public float VillagerVelocity;
    public float RaomingRadius;
    public float Delay;

    private float delay;
    private Vector2 SpawnPosition;

	void Start ()
    {
        delay = Delay;
        SpawnPosition = transform.position;
        Direction_Speed();
       
    }
	
	void Update ()
    {
        delay -= Time.deltaTime;

        if (Vector2.Distance(transform.position, SpawnPosition) > RaomingRadius)
        {
            GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity;
        }

        if (delay < 0)
        {
            Direction_Speed();
            delay = Delay;
        }
	}

    void Direction_Speed()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        Vector2 Direction = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = (Direction / Direction.magnitude) * VillagerVelocity;

        float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle + 90);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "WerewolfNPC")
        {
            if (WereWolfNPCBehavior.VillagerCountWerewolf < 3)
            {
                WereWolfNPCBehavior.VillagerCountWerewolf++;
                WereWolfNPCBehavior.FollowingVillager = false;
                Destroy(gameObject);
            }
        }

        if (collider.gameObject.tag == "Player")
        {
            if (PlayerScript.VillagerCountPlayer < 2)
            {
                PlayerScript.VillagerCountPlayer++;
                Destroy(gameObject);
            }
        }
    }
}

