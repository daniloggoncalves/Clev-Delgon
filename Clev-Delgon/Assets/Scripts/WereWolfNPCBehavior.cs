using UnityEngine;
using System.Collections;

public class WereWolfNPCBehavior : MonoBehaviour {

    public float WereWolf_VelocityMAX;
    static public int VillagerCountWerewolf;
    public GameObject VillagerSpawner;
    static public bool FollowingVillager;
	public int WeightofVillagerforWerewolf;

    private float wereWolf_VelocityACTUAL;
    private GameObject TemporaryFollowing;
    private GameObject Base;
    private GameObject Player;
    private bool PlayerAround;
    private bool ReturningBase;

	int targetIndex;
	Vector3[] path;




	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Base = GameObject.FindGameObjectWithTag("Base");
		VillagerSpawner = GameObject.FindGameObjectWithTag("VillagerSpawner");
		// Go to Village
		Follow (VillagerSpawner);
        VillagerCountWerewolf = 0;
	}

	
	void Update ()
    {

        wereWolf_VelocityACTUAL = WereWolf_VelocityMAX  - (VillagerCountWerewolf * (WeightofVillagerforWerewolf/10) );


		//Return to the base after hunting 3 Villagers OR player around
        if (VillagerCountWerewolf >= 3 || PlayerAround == true)
        {
            Follow(Base);
			ReturningBase = true;

            if (Vector2.Distance(transform.position, Base.transform.position) <= 50)
	            {
	                ScoreScript.WerewolfScore = ScoreScript.WerewolfScore + VillagerCountWerewolf;
	                VillagerCountWerewolf = 0;
	                ReturningBase = false;
	                PlayerAround = false;

					//Go to village
					Follow (VillagerSpawner);

	                wereWolf_VelocityACTUAL = WereWolf_VelocityMAX;
	            }
        }

        CheckForPlayer(Player);

		// go to village or follow closest villager
        if (ReturningBase == false && PlayerAround == false)
        {

			TemporaryFollowing = FindClosestVillager();

            if (Vector2.Distance(TemporaryFollowing.transform.position, transform.position) < 100 && FollowingVillager == false)
	            {
					Follow(TemporaryFollowing);
					FollowingVillager = true;
	            }

			if (Vector2.Distance(TemporaryFollowing.transform.position, transform.position) > 100 && FollowingVillager == false)
	            {
	                //Go to village
					Follow(VillagerSpawner);
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
	
	public void Follow(GameObject target)	{
		PathRequestManager.RequestPath (transform.position, target.transform.position, OnPathFound);
	}
	
	public void OnPathFound(Vector3[] newPath, bool pathSuccessful){
		if (pathSuccessful) {
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}
	
	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path [0];
		
		while (true) {
			if(transform.position == currentWaypoint){
				targetIndex ++;
				if (targetIndex >= path.Length){
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}
			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, wereWolf_VelocityACTUAL);
			yield return null;
		}
	}
}
