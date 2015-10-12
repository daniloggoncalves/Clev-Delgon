using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public float Screen_speed;
    static public int VillagerCountPlayer;

    private GameObject Castle;
    private float screen_speed;

    void Start()
    {
        Castle = GameObject.FindGameObjectWithTag("Castle");
        transform.position = Castle.transform.position;
    }

    void FixedUpdate()
    {
        Debug.Log(VillagerCountPlayer);
        IsCloseToCastle(Castle);
        screen_speed = Screen_speed * (10 - 1.5f * VillagerCountPlayer) / 10;
        Debug.Log(screen_speed);
        Camera_Controller();
        PlayerDirection();

    }

    void IsCloseToCastle(GameObject Castle)
    {
        if (Vector2.Distance(transform.position, Castle.transform.position) <= 30)
        {
            ScoreScript.PlayerScore = ScoreScript.PlayerScore + VillagerCountPlayer;
            VillagerCountPlayer = 0;
        }
    }

    void PlayerDirection()
    {
        Touch touch_one = Input.GetTouch(0);
        if (touch_one.phase != TouchPhase.Ended)
        {
            float angle = Mathf.Atan2(
                ((touch_one.position.y / (float)Screen.height) * 200.0f - 100.0f),
                ((touch_one.position.x / (float)Screen.width) * 320.0f - 160.0f)
              ) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle - 90);
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

            GetComponent<Rigidbody2D>().velocity = (Direction / Direction.magnitude) * screen_speed;
        }

        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}