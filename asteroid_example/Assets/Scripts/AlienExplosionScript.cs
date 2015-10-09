using UnityEngine;
using System.Collections;

public class AlienExplosionScript : MonoBehaviour {

    void Start()
    {
        ScoreScript.AddPoint();
        Destroy(gameObject, 2f);
    }

    void Update()
    {

    }
}