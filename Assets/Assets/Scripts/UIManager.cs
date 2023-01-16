using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TMP_Text scoreText;

    void Awake()
    {
        Instance = this;
    }

    public void SetScore(int player1Score, int player2Score)
    {
        scoreText.text = $"{player1Score} - {player2Score}";
    }
}
