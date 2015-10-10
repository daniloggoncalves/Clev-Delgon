using UnityEngine;
using System.Collections;

public class VillagerSpawner : MonoBehaviour {

	public GameObject villagerNPCPrefab;

	//1
	public float minSpawnTime = 0.75f; 
	public float maxSpawnTime = 2f; 
	
	//2    
	void Start () {
		Invoke("SpawnVillager",minSpawnTime);
	}
	
	//3
	void SpawnVillager()
	{

		int i = GameObject.FindGameObjectsWithTag ("Villager").Length;
		
			if (i < 5)
		{
				Instantiate(villagerNPCPrefab, Vector3.zero, Quaternion.identity);
		}

		Invoke("SpawnVillager", Random.Range(minSpawnTime, maxSpawnTime));
	}
}