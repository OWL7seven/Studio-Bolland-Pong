using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;

    public float speed = 10.0f;
    public float boundY = 2.25f;

    [SerializeField]
    private bool AIControlled;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (AIControlled)
        {
            rigidbody2D.velocity = new Vector2(0, (BallController.Instance.transform.position.y - transform.position.y) * speed);
        }
        else
        {
            rigidbody2D.velocity = velocity;
        }

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            spriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f), 1);
        }
    }
}
