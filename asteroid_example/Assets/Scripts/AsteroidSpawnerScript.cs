using UnityEngine;
using System.Collections;

public class AsteroidSpawnerScript : MonoBehaviour
{
    public GameObject Asteroid_large;
    public float SpawnDelay = 5f;

    private float spawnDelay;

    void Start()
    {

    }

    static void SpawnAsteroid()
    {

    }

    void Update()
    {
        int i = GameObject.FindGameObjectsWithTag("Asteroid_large").Length;

        spawnDelay -= Time.deltaTime;
        if (spawnDelay < 0 && i < 4)
        {
            if (Random.Range(-1f, 1f) > 0)
            {
                if (Random.Range(-1f, 1f) > 0)
                {
                    Instantiate(Asteroid_large, transform.position = new Vector3(640, Random.Range(-400f, 400f), 0), Quaternion.identity);

                }
                else
                {
                    Instantiate(Asteroid_large, transform.position = new Vector3(-640, Random.Range(-400f, 400f), 0), Quaternion.identity);

                }
            }
            else
            {
                if (Random.Range(-1f, 1f) > 0)
                {
                    Instantiate(Asteroid_large, transform.position = new Vector3(Random.Range(-625f, 625f), 400, 0), Quaternion.identity);

                }
                else
                {
                    Instantiate(Asteroid_large, transform.position = new Vector3(Random.Range(-625f, 625f), -400, 0), Quaternion.identity);
                }
            }
            spawnDelay = SpawnDelay;
        }
    }
}