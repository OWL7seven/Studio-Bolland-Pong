using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private KeyCode moveUp = KeyCode.W;
    private KeyCode moveDown = KeyCode.S;

    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float lerpSpeed = 0.15f;

    [SerializeField]
    private bool boundLimit = true;
    private float boundY = 3f;

    private bool AIControlled;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (boundLimit)
        {
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

        var velocity = rigidbody2D.velocity;
        if (Input.GetKey(moveUp))
        {
            velocity.y += speed;
        }
        else if (Input.GetKey(moveDown))
        {
            velocity.y -= speed;
        }
        else
        {
            velocity.y = 0;
        }

        if (AIControlled)
        {
            if (BallController.Instance.lastHit != this)
            {
                if (BallController.Instance.transform.position.y > transform.position.y)
                {
                    if (rigidbody2D.velocity.y < 0) rigidbody2D.velocity = Vector2.zero;
                    rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, Vector2.up * speed, lerpSpeed * Time.deltaTime);
                }
                else if (BallController.Instance.transform.position.y < transform.position.y)
                {
                    if (rigidbody2D.velocity.y > 0) rigidbody2D.velocity = Vector2.zero;
                    rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, Vector2.down * speed, lerpSpeed * Time.deltaTime);
                }
                else
                {
                    rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, Vector2.zero * speed, lerpSpeed * Time.deltaTime);
                }
            }
            else
            {
                rigidbody2D.velocity = Vector2.zero;
                // move to the center of the map
            }
        }
        else
        {
            rigidbody2D.velocity = velocity;
        }    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            spriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f), 1);
        }
    }

    public void SetAIControl(bool value)
    {
        AIControlled = value;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void SetBound(float value)
    {
        boundY = value;
    }

    public void SetInputKeys(KeyCode up, KeyCode down)
    {
        moveUp = up;
        moveDown = down;
    }
}
