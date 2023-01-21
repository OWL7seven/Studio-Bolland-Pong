using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private BallController ball;

    private int player1Score;
    private int player2Score;

    [SerializeField]
    private PaddleController playerOne;
    [SerializeField]
    private PaddleController playerTwo;

    void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        CreateBall(true);
        UIManager.Instance.mainMenu.SetActive(false);
        UIManager.Instance.SetScore(0, 0);
    }

    public void CreateBall(bool value)
    {
        if (ball != null)
        {
            Destroy(ball.gameObject);
        }
        ball = Instantiate(Resources.Load<BallController>("Prefabs/Ball"));
        ball.launchRight = value;
    }


    public void StartSingleplayer(float difficultySpeed)
    {
        StartGame();
        CreatePlayer(TypeData.Player.One, new Vector3(-7.7f, 0, 0), new quaternion(), 0.5f, false, KeyCode.W, KeyCode.S);
        CreatePlayer(TypeData.Player.Two, new Vector3(7.7f, 0, 0), new quaternion(0, 0, 180, 0), difficultySpeed, true, KeyCode.UpArrow, KeyCode.DownArrow);
    }


    public void StartMultiplayer()
    {
        StartGame();
        CreatePlayer(TypeData.Player.One, new Vector3(-7.7f, 0, 0), new quaternion(), 0.5f, false, KeyCode.W, KeyCode.S);
        CreatePlayer(TypeData.Player.Two, new Vector3(7.7f, 0, 0), new quaternion(0, 0, 180, 0), 0.5f, false, KeyCode.UpArrow, KeyCode.DownArrow);
    }

    public void StartDemo()
    {
        StartGame();
        CreatePlayer(TypeData.Player.One, new Vector3(-7.7f, 0, 0), new quaternion(), 30f, true, KeyCode.W, KeyCode.S);
        CreatePlayer(TypeData.Player.Two, new Vector3(7.7f, 0, 0), new quaternion(0, 0, 180, 0), 10f, true, KeyCode.UpArrow, KeyCode.DownArrow);
    }


    private void CreatePlayer(TypeData.Player player, Vector3 position, quaternion rotation, float speed, bool ai, KeyCode up, KeyCode down)
    {
        if (player == TypeData.Player.One)
        {
            playerOne = Instantiate(Resources.Load<PaddleController>("Prefabs/Player"), SceneItemManager.Instance.players.transform);
            playerOne.transform.position = position;
            playerOne.transform.rotation = rotation;
            playerOne.SetSpeed(speed);
            playerOne.SetAIControl(ai);
            playerOne.SetInputKeys(up, down);
        }
        else
        {
            playerTwo = Instantiate(Resources.Load<PaddleController>("Prefabs/Player"), SceneItemManager.Instance.players.transform);
            playerTwo.transform.position = position;
            playerTwo.transform.rotation = rotation;
            playerTwo.SetSpeed(speed);
            playerTwo.SetAIControl(ai);
            playerTwo.SetInputKeys(up, down);
        }
    }

    public void Score(TypeData.WallSide wall)
    {
        bool launchRight = false;
        if (wall == TypeData.WallSide.Left)
        {
            player1Score++;
            launchRight = true;
        }
        else if (wall == TypeData.WallSide.Right)
        {
            player2Score++;
        }

        AudioManager.Instance.PlayClip("Sounds/beep/beep_1");
        UIManager.Instance.SetScore(player1Score, player2Score);

        CreateBall(launchRight);
    }

    public void EndGame()
    {
        if(playerOne)
        Destroy(playerOne.gameObject);
        if(playerTwo)
        Destroy(playerTwo.gameObject);
        if(ball)
        Destroy(ball.gameObject);
        UIManager.Instance.scoreText.text = string.Empty;
    }
}
