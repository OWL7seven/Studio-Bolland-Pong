using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetMenuButtons();
    }

    private void SetMenuButtons()
    {
        UIManager.Instance.singlePlayerButton.onClick.AddListener(SetDiffculty);
        UIManager.Instance.multiplayerButton.onClick.AddListener(GameManager.Instance.StartMultiplayer);
        UIManager.Instance.demoButton.onClick.AddListener(GameManager.Instance.StartDemo);
        UIManager.Instance.multiplayerButton.onClick.AddListener(SetBackToMenu);
        UIManager.Instance.demoButton.onClick.AddListener(SetBackToMenu);    
        UIManager.Instance.exitButton.onClick.AddListener(() => Application.Quit());
        UIManager.Instance.easyButton.onClick.AddListener(() => GameManager.Instance.StartSingleplayer(10));
        UIManager.Instance.mediumButton.onClick.AddListener(() => GameManager.Instance.StartSingleplayer(20));
        UIManager.Instance.hardButton.onClick.AddListener(() => GameManager.Instance.StartSingleplayer(30));
        UIManager.Instance.easyButton.onClick.AddListener(() => UIManager.Instance.difficultyMenu.SetActive(false));
        UIManager.Instance.mediumButton.onClick.AddListener(() => UIManager.Instance.difficultyMenu.SetActive(false));
        UIManager.Instance.hardButton.onClick.AddListener(() => UIManager.Instance.difficultyMenu.SetActive(false));
        UIManager.Instance.difficultyMenu.SetActive(false);
    }

    private void SetBackToMenu()
    {
        UIManager.Instance.exitButton.onClick.RemoveAllListeners();
        UIManager.Instance.exitButton.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        ResetExitButton();
        UIManager.Instance.mainMenu.SetActive(true);
        UIManager.Instance.difficultyMenu.SetActive(false);

        GameManager.Instance.EndGame();
    }

    private void ResetExitButton()
    {
        UIManager.Instance.exitButton.onClick.RemoveAllListeners();
        UIManager.Instance.exitButton.onClick.AddListener(() => Application.Quit());
    }

    private void SetDiffculty()
    {
        SetBackToMenu();

        UIManager.Instance.mainMenu.SetActive(false);
        UIManager.Instance.difficultyMenu.SetActive(true);
    }
}
