using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotate : MonoBehaviour
{
    public Rigidbody2D ballrb;
    public GameObject floor;
    public GameObject goal_floor;
    public GameObject pointer;
    SpriteRenderer pointer_sprenderer;

    float x_speed; // rbx값
    float y_speed; // rby값
    float cross_speed; // 최종 출력할 값
    float gravity = 9.81f;
    float distance;
    float current_distance;
    float adjusted_distance;
    bool started;

    public Text x_speedtxt;
    public Text y_speedtxt;
    public Text curr_x_speedtxt;
    public Text curr_y_speedtxt;
    public Text DFGtxt;
    void Start()
    {
        pointer_sprenderer = pointer.GetComponent<SpriteRenderer>();
        started = false;
        ballrb.gravityScale = 0f;
        distance = (goal_floor.transform.position.x - floor.transform.position.x); // R
        adjusted_distance = distance;
    }

    void Update()
    {
        current_distance = goal_floor.transform.position.x - floor.transform.position.x;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            distance = (goal_floor.transform.position.x - floor.transform.position.x); // R
            adjusted_distance = distance;
            x_speed = Mathf.Sqrt(adjusted_distance * gravity) * Mathf.Cos(this.transform.localEulerAngles.z * Mathf.Deg2Rad);
            y_speed = x_speed * Mathf.Tan(this.transform.localEulerAngles.z * Mathf.Deg2Rad);
            cross_speed = x_speed / Mathf.Cos(this.transform.localEulerAngles.z * Mathf.Deg2Rad);
            ballrb.gravityScale = 1f;
            ballrb.velocity = new Vector2(x_speed, y_speed);
            started = true;
            pointer_sprenderer.color = new Color(0, 0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.position = new Vector3(floor.transform.position.x, floor.transform.position.y + 0.6f, 0);
            ballrb.angularVelocity = 0f;
            ballrb.gravityScale = 0f;
            ballrb.velocity = new Vector2(0, 0);
            this.transform.localEulerAngles = new Vector3(0, 0, 45f);
            pointer_sprenderer.color = new Color(1, 0, 0, 1);
            started = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = new Vector3(this.transform.position.x - 0.2f, this.transform.position.y, 0);
            floor.transform.position = new Vector3(floor.transform.position.x - 0.2f, floor.transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = new Vector3(this.transform.position.x + 0.2f, this.transform.position.y, 0);
            floor.transform.position = new Vector3(floor.transform.position.x + 0.2f, floor.transform.position.y, 0);
        }

        if (started)
        {
            x_speedtxt.text = "발사순간 Vx: " + Mathf.Round(x_speed * 100f) * 0.01f;
            y_speedtxt.text = "발사순간 Vy: " + Mathf.Round(y_speed * 100f) * 0.01f;
            curr_x_speedtxt.text = "현재 Vx: " + Mathf.Round(ballrb.velocity.x * 100f) * 0.01f;
            curr_y_speedtxt.text = "현재 Vy: " + Mathf.Round(ballrb.velocity.y * 100f) * 0.01f;
        }
        if (!started)
        {
            DFGtxt.text = "골대로부터의 거리: " + Mathf.Round(current_distance * 10f) * 0.1f;
        }
    }
}
