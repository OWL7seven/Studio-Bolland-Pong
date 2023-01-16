using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var velocity = rigidbody2D.velocity;
        if (Input.GetKey(moveUp))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0;
        }
        rigidbody2D.velocity = velocity;

        var position = transform.position;
        if (position.y > boundY)
        {
            position.y = boundY;
        }
        else if (position.y < -boundY)
        {
            position.y = -boundY;
        }
        transform.position = position;
    }
}
