using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public TypeData.WallSide side;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Ball")
        {
            GameManager.Instance.Score(side);
        }
    }
}
