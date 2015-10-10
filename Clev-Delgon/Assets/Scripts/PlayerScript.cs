using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float Screen_speed;


    void Start () {
        transform.position = new Vector3(0, 0, 0);
    }
	
	void FixedUpdate () {
        Camera_Controller();
        PlayerDirection();

    }


    void PlayerDirection()
    {
            Touch touch_one = Input.GetTouch(0);
            if (touch_one.phase != TouchPhase.Ended)
            {
                float angle = Mathf.Atan2(
            transform.position.y - ((touch_one.position.x / (float)Screen.width) * 320.0f - 160.0f),
            transform.position.x - ((touch_one.position.y / (float)Screen.height) * 200.0f - 100.0f)) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + 90);
            }
        
    }

    void Camera_Controller()
    {
        Touch touch_one = Input.GetTouch(0);
        if (touch_one.phase != TouchPhase.Ended)
        {

            Vector2 Direction = new Vector2(
              ((touch_one.position.x / (float)Screen.width) * 320.0f - 160.0f),
              ((touch_one.position.y / (float)Screen.height) * 200.0f - 100.0f));

            GetComponent<Rigidbody2D>().velocity = (Direction / Direction.magnitude) * Screen_speed;
        }

        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
