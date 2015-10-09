using UnityEngine;
using System.Collections;

public class AlienSpawnerScript : MonoBehaviour
{
    public GameObject Aliens;
    public float SpawnDelay = 5f;

    private float spawnDelay;

    void Start()
    {

    }

    static void SpawnAlien()
    {

    }

    void Update()
    {
        int i = GameObject.FindGameObjectsWithTag("Alien").Length;

        spawnDelay -= Time.deltaTime;
        if (spawnDelay < 0 && i < 4)
        {
            if (Random.Range(-1f, 1f) > 0)
            {
                if (Random.Range(-1f, 1f) > 0)
                {
                    Instantiate(Aliens, transform.position = new Vector3(640, Random.Range(-400f, 400f), 0), Quaternion.identity);

                }
                else
                {
                    Instantiate(Aliens, transform.position = new Vector3(-640, Random.Range(-400f, 400f), 0), Quaternion.identity);

                }
            }
            else
            {
                if (Random.Range(-1f, 1f) > 0)
                {
                    Instantiate(Aliens, transform.position = new Vector3(Random.Range(-625f, 625f), 400, 0), Quaternion.identity);

                }
                else
                {
                    Instantiate(Aliens, transform.position = new Vector3(Random.Range(-625f, 625f), -400, 0), Quaternion.identity);
                }
            }
            spawnDelay = SpawnDelay;
        }
    }
}