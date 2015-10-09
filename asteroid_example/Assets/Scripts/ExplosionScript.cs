using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	void Start ()
    {
        ScoreScript.AddPoint();
        Destroy(gameObject, 2f);
	}
	
	void Update ()
    {
	
	}
}
