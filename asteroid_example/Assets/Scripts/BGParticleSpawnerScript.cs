using UnityEngine;
using System.Collections;

public class BGParticleSpawnerScript : MonoBehaviour {
    public GameObject BackgroundParticle;
    public float SpawnDelay = 2f;

    private float spawnDelay;

    void Start ()
    {

	}
	
	void Update () {
        spawnDelay -= Time.deltaTime;
        if(spawnDelay < 0)
        {
            Instantiate(BackgroundParticle, transform.position = new Vector3(Random.Range(-625f, 625f), Random.Range(-400f, 400f), 0), Quaternion.identity);
            spawnDelay = SpawnDelay;
        }
	}
}
