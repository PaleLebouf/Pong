using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public vars
    public KeyCode upControl;
    public KeyCode downControl;
    public float speed;
    public Boundary boundary;

    //private vars
    private float direction;

    //Unity functions
	void FixedUpdate ()
    {

        if (Input.GetKey(upControl))
            direction = 1;
        else if (Input.GetKey(downControl))
            direction = -1;
        else
            direction = 0;

        if (Input.GetKey(downControl))
            direction = -1;

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        transform.position = new Vector2(transform.position.x, transform.position.y + direction * speed);

        checkBounds();

    }

    //Class functions
    private void checkBounds()
    {
        if (transform.position.y > boundary.yMax)
            transform.position = new Vector2(transform.position.x, boundary.yMax);
        if (transform.position.y < boundary.yMin)
            transform.position = new Vector2(transform.position.x, boundary.yMin);
    }
}
