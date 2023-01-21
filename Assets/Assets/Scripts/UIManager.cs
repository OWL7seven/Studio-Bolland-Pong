using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject mainMenu;
    public GameObject difficultyMenu;

    // Menu Items
    public Button singlePlayerButton;
    public Button multiplayerButton;
    public Button demoButton;

    // Difficulty buttons
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    public Button exitButton;

    // Gameplay items
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
