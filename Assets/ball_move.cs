using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball_move : MonoBehaviour
{
    int random_x;
    public int deg;
    bool started;
    float current_distance;

    public GameObject ball;
    Rigidbody2D ballrb;
    GameObject pointer;
    SpriteRenderer pointer_sprenderer;
    public Text angletxt;
    public Text DFGtxt;


    void Start()
    {
        pointer = GameObject.Find("pointer");
        ballrb = ball.GetComponent<Rigidbody2D>();
        pointer_sprenderer = pointer.GetComponent<SpriteRenderer>();
        random_x = Random.Range(-34, 24);
        this.transform.position = new Vector3(random_x, -10, 0);
        ball.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.6f, 0);
        ball.transform.localEulerAngles = new Vector3(0, 0, deg);
    }

    void Update()
    {
        current_distance = this.transform.position.x - ball.transform.position.x;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
        }

            if (Input.GetKeyDown(KeyCode.R))
        {
            random_x = Random.Range(-34, 24);
            this.transform.position = new Vector3(random_x, -10, 0);
            ball.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.6f, 0);
            ballrb.angularVelocity = 0f;
            ballrb.gravityScale = 0f;
            ballrb.velocity = new Vector2(0, 0);
            ball.transform.localEulerAngles = new Vector3(0, 0, 45f);
            pointer_sprenderer.color = new Color(1, 0, 0, 1);
            started = false;
        }

        angletxt.text = "현재 각도: " + Mathf.Round(ball.transform.localEulerAngles.z) + "°";

        if (!started)
        {
            DFGtxt.text = "골대로부터의 거리: " + Mathf.Round(current_distance * 10f) * 0.1f;
        }
    }
}
