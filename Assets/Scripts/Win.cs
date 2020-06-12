using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private string currentLevel;
    [SerializeField] private string nextLevel;
    [SerializeField] private GameObject winPopup;
    
    private void Awake()
    {
        restartButton.onClick.AddListener(RestartButtonClicked);
        exitButton.onClick.AddListener(ExitButtonClicked);
        nextLevelButton.onClick.AddListener(NextLevelButtonClicked);
    }

    //Carga el siguiente nivel
    private void NextLevelButtonClicked()
    {
        SceneManager.LoadScene(nextLevel);
        Time.timeScale = 1.0f;
    }

    //reinicia el nivel actual
    private void RestartButtonClicked()
    {
        SceneManager.LoadScene(currentLevel);
        Time.timeScale = 1.0f;
        winPopup.SetActive(false);
    }
   
    //cierra la aplicacion
    private void ExitButtonClicked()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode(); 
        }
        Application.Quit();
    }
}
