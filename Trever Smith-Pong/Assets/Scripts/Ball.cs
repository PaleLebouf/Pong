using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    //public vars
    public float speedX;
    public float speedY;
    public Boundary boundary;
    public bool p1ScoredLast = true;

    //private vars
    private GameController gc;

    void Awake()
    {
        roundStart();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void FixedUpdate()
    {
        bounce();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        speedY = -(collision.gameObject.GetComponent<Rigidbody2D>().position.y - collision.contacts[0].point.y) * 12;
        speedX *= -1;
        
    }

    //Class Functions
    private void roundStart()
    {
        transform.position = Vector3.zero;

        if (p1ScoredLast)
        {
            if (speedX > 0)
                speedX *= -1;
        }
        else
            if (speedX < 0)
            speedX *= -1;

        speedY *= -1;
    }

    private void bounce()
    {
        //I know there's a better way to do this for simplers code sake,
        //I just chose to use this for the my own understanding.
        if (transform.position.y > boundary.yMax)
        {
            transform.position = new Vector2(transform.position.x, boundary.yMax);
            speedY *= -1;
        }
        else if (transform.position.y < boundary.yMin)
        {
            transform.position = new Vector2(transform.position.x, boundary.yMin);
            speedY *= -1;
        }

        if(transform.position.x > 10.0f)
        {
            reset(1);
        }
        else if(transform.position.x < -10.0f)
        {
            reset(2);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, speedY);
    }

    private void reset(int player)
    {
        if (player == 1)
        {
            p1ScoredLast = true;
            gc.p1Score++;
        }
        else if (player == 2)
        {
            p1ScoredLast = false;
            gc.p2Score++;
        }

        gc.displayScore();

        if (gc.p1Score < gc.scoreLimit && gc.p2Score < gc.scoreLimit)
            roundStart();

    }
}
