using UnityEngine;
using System.Collections;

public class WereWolfNPCBehavior : MonoBehaviour {

    public float WereWolf_Velocity;

    private int VillagerCount;

	void Start ()
    {
        VillagerCount = 0;
	}
	
	void Update ()
    {
        if(Vector2.Distance(FindClosestVillager().transform.position, transform.position) < 56)
        {
            GoAfterVillager();
        }
	}

    void AddVillagerPoint()
    {

    }

    void GoAfterVillager()
    {
        float angle = Mathf.Atan2(
            FindClosestVillager().transform.position.y - transform.position.y,
            FindClosestVillager().transform.position.x - transform.position.x
            ) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * WereWolf_Velocity;
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

    void GoBack()
    {

    }
}
