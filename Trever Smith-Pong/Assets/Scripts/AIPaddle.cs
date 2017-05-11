using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    //Public Vars
    public float speed;
    public Boundary boundary;

    //Private Vars
    private GameObject ball;
    private float direction;

    //Unity Functions
    void Update ()
    {

        ball = GameObject.FindGameObjectWithTag("Ball");

        if (ball.transform.position.x > 7)
        {
            if (ball.transform.position.y > transform.position.y && (ball.transform.position.y - transform.position.y) > 0.5f)
                direction = 1;
            else if (ball.transform.position.y < transform.position.y && (transform.position.y - ball.transform.position.y) > 0.5f)
                direction = -1;
            else
                direction = 0;
        }
        else
            direction = 0;

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        transform.position = new Vector2(transform.position.x, transform.position.y + direction * speed);

        checkBounds();
	}

    //Class Functions
    private void checkBounds()
    {
        if (transform.position.y > boundary.yMax)
            transform.position = new Vector2(transform.position.x, boundary.yMax);
        if (transform.position.y < boundary.yMin)
            transform.position = new Vector2(transform.position.x, boundary.yMin);
    }
}
