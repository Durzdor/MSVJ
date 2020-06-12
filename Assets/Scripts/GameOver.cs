using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private String currentLevel;
    [SerializeField] private GameObject gameOverPopup;

    private void Awake()
    {
        tryAgainButton.onClick.AddListener(TryAgainButtonClicked);
        exitButton.onClick.AddListener(ExitButtonClicked);
    }

    private void TryAgainButtonClicked()
    {
        SceneManager.LoadScene(currentLevel);
        Time.timeScale = 1.0f;
        gameOverPopup.SetActive(false);
    }
    private void ExitButtonClicked()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode(); 
        }
        Application.Quit();
    }
}
