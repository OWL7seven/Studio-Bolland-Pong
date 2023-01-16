using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rigidbody2D.AddForce(new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), 0));
    }
}
