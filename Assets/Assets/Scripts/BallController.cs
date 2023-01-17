using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController Instance { get; private set; }

    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        Instance = this;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rigidbody2D.AddForce(new Vector3(Random.Range(100, 200), Random.Range(100, 200), 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            AudioManager.Instance.PlayClip("Sounds/hits/hit_1");
        }
        else if (collision.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlayClip("Sounds/jump/jump_1");
        }
    }
}
