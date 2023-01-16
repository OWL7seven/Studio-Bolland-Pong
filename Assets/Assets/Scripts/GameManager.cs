using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private BallController ball;

    private int player1Score;
    private int player2Score;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CreateBall();
        UIManager.Instance.SetScore(0, 0);
    }

    public void CreateBall()
    {
        if (ball != null)
        {
            Destroy(ball.gameObject);
        }
        ball = Instantiate(Resources.Load<BallController>("Prefabs/Ball"));
    }

    public void Score(TypeData.WallSide wall)
    {
        if (wall == TypeData.WallSide.Left)
        {
            player1Score++;
        }
        else if (wall == TypeData.WallSide.Right)
        {
            player2Score++;
        }

        UIManager.Instance.SetScore(player1Score, player2Score);

        CreateBall();
    }
}
