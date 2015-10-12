using UnityEngine;
using System.Collections;

public class WereWolfNPCBehavior : MonoBehaviour {

    public float WereWolf_Velocity;
    static public int VillagerCountWerewolf;
    public GameObject VillagerSpawner;
    static public bool FollowingVillager;

    public float wereWolf_Velocity;
    private GameObject TemporaryFollowing;
    private GameObject Base;
    private GameObject Player;
    private bool PlayerAround;
    private bool ReturningBase;


	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Base = GameObject.FindGameObjectWithTag("Base");
        GoToVillage();
        VillagerCountWerewolf = 0;
	}
	
	void Update ()
    {

        wereWolf_Velocity = ((WereWolf_Velocity * (10 - VillagerCountWerewolf)) / 10);

        if (VillagerCountWerewolf >= 3 || PlayerAround == true)
        {
            ReturnBase();

            if (Vector2.Distance(transform.position, Base.transform.position) <= 50)
            {
                ScoreScript.WerewolfScore = ScoreScript.WerewolfScore + VillagerCountWerewolf;
                VillagerCountWerewolf = 0;
                ReturningBase = false;
                PlayerAround = false;
                GoToVillage();
                wereWolf_Velocity = WereWolf_Velocity;
            }
        }

        CheckForPlayer(Player);

        if (ReturningBase == false && PlayerAround == false)
        {

            if (FollowingVillager == true)
            {
                FollowObject(TemporaryFollowing);
            }
            if (Vector2.Distance(FindClosestVillager().transform.position, transform.position) <100 && FollowingVillager == false)
            {
                TemporaryFollowing = FindClosestVillager();
                FollowingVillager = true;
            }

            if (Vector2.Distance(FindClosestVillager().transform.position, transform.position) > 100 && FollowingVillager == false)
            {
                GoToVillage();
            }
        }
    }

    void CheckForPlayer(GameObject Player)
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < 30)
        {
            PlayerAround = true;
        }
    }

    void FollowObject(GameObject Object)
    {
        if (Object != null)
        {
            float angle = Mathf.Atan2(
    Object.transform.position.y - transform.position.y,
    Object.transform.position.x - transform.position.x
    ) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * wereWolf_Velocity;
            FollowingVillager = true;
        }
        if (Object == null)
        {
            FollowingVillager = false;
        }

    }

    void GoAfterVillager()
    {
        float angle = Mathf.Atan2(
            FindClosestVillager().transform.position.y - transform.position.y,
            FindClosestVillager().transform.position.x - transform.position.x
            ) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * wereWolf_Velocity;
        FollowingVillager = true;
    }

    GameObject FindClosestVillager()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Villager");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void GoToVillage()
    {
        VillagerSpawner = GameObject.FindGameObjectWithTag("VillagerSpawner");


        float angle = Mathf.Atan2(

            VillagerSpawner.transform.position.y - transform.position.y,
            VillagerSpawner.transform.position.x - transform.position.x) * Mathf.Rad2Deg;


        GetComponent<Rigidbody2D>().velocity = (new Vector2(Mathf.Cos(angle + 90), Mathf.Sin(angle + 90)) * wereWolf_Velocity);

        transform.eulerAngles = new Vector3(0, 0, angle);

    }

    void ReturnBase()
    {
        Base = GameObject.FindGameObjectWithTag("Base");


        float angle = Mathf.Atan2(
        
            Base.transform.position.y - transform.position.y,
            Base.transform.position.x - transform.position.x) * Mathf.Rad2Deg;


        GetComponent<Rigidbody2D>().velocity = (new Vector2(Mathf.Cos(angle + 90), Mathf.Sin(angle + 90)) * wereWolf_Velocity);
        transform.eulerAngles = new Vector3(0, 0, angle);
        
        ReturningBase = true;
    }
}
