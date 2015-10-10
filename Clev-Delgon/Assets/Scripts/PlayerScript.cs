using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public GameObject BackGround;
    public float Screen_Speed_y;
    public float Screen_Speed_x;

    void Start () {
        transform.position = new Vector3(0, 0, 0);
    }
	
	void FixedUpdate () {
        Camera_Controller();

    }

    void Camera_Controller()
    {
        Touch touch_one = Input.GetTouch(0);
        if (touch_one.phase != TouchPhase.Ended)
        {
            BackGround = UnityEngine.GameObject.FindGameObjectWithTag("BackGround");

            Vector2 Direction = new Vector2(
                ((touch_one.position.x / (float)Screen.width) * 320.0f - 160.0f),
                ((touch_one.position.y / (float)Screen.height) * 200.0f - 100.0f));
                
            BackGround.GetComponent<Rigidbody2D>().velocity = (Direction/Direction.magnitude) * Screen_Speed_x;
        }

        else
        {
            BackGround = UnityEngine.GameObject.FindGameObjectWithTag("BackGround");
            BackGround.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
    }
}
