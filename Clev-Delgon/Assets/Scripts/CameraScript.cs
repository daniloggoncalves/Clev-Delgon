using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject Player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Player = UnityEngine.GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, -1000);
    }
}
