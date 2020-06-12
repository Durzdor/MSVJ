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
    [SerializeField] private string currentLevel;
    [SerializeField] private GameObject gameOverPopup;

    private void Awake()
    {
        tryAgainButton.onClick.AddListener(TryAgainButtonClicked);
        exitButton.onClick.AddListener(ExitButtonClicked);
    }

   //Reinicia el nivel actual
    private void TryAgainButtonClicked()
    {
        SceneManager.LoadScene(currentLevel);
        Time.timeScale = 1.0f;
        gameOverPopup.SetActive(false);
    }
    
    //Cierra la aplicacion
    private void ExitButtonClicked()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode(); 
        }
        Application.Quit();
    }
}
