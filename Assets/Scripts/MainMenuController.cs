using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private Button helpBackButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject helpMenu;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayButtonClicked);
        helpButton.onClick.AddListener(HelpButtonClicked);
        exitButton.onClick.AddListener(ExitButtonClicked);
        helpBackButton.onClick.AddListener(HelpBackButtonClicked);
        ShowMainMenu();
    }

    private void PlayButtonClicked()
    {
        SceneManager.LoadScene("Level1");
    }

    private void HelpButtonClicked()
    {
        helpMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    private void HelpBackButtonClicked()
    {
        ShowMainMenu();
    }

    private void ExitButtonClicked()
    {
        if (Application.isEditor)
        {
           EditorApplication.ExitPlaymode(); 
        }
        Application.Quit();
    }

    private void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
    }
}
