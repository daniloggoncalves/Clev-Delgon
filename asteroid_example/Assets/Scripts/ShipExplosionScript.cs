using UnityEngine;
using System.Collections;

public class ShipExplosionScript : MonoBehaviour {

    public float Delay = 2f;

    private float delay;

    void Start()
    {
        delay = Delay;
        //Destroy(gameObject, 2f);
    }

    void Update()
    {
        delay -= Time.deltaTime;
        if(delay < 0)
        {
            Application.LoadLevel(0);
        }
    }
}