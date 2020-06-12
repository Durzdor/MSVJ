using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private String currentLevel;
    [SerializeField] private GameObject winPopup;
    
    private void Awake()
    {
        restartButton.onClick.AddListener(RestartButtonClicked);
        exitButton.onClick.AddListener(ExitButtonClicked);
    }

    private void RestartButtonClicked()
    {
        SceneManager.LoadScene(currentLevel);
        Time.timeScale = 1.0f;
        winPopup.SetActive(false);
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
