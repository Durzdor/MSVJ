using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperTools : MonoBehaviour
{
    private bool godModeOn = false;
    private bool timeUp = false;
    private void Update()
    {
        //prende los permisos de GodMode
        if (Input.GetKeyDown(KeyCode.P))
        {
            godModeOn = !godModeOn;
        }
        if (!godModeOn) return;
        //Cambia el numero de vidas a 1000
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.currentLives = 1000;
        }
        //Activa el powerup TripleBall
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.TripleBall(1, 2);
        }
        //Activa el powerup FastBall
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.Instance.FastBall(5,5);
        }
        //Activa el powerup SlowBall
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.Instance.SlowBall(3,5);
        }
        //activa el powerup Damage
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameManager.Instance.DamageBall(5,5);
        }
        //activa el powerup Cannon
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GameManager.Instance.CannonBall(20,5);
        }
        //activa el powerup Shrink
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            GameManager.Instance.ShrinkPlayer(5,0.5f);
        }
        //Activa el powerup Enlarge
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            GameManager.Instance.EnlargePlayer(5,-0.5f);
        }
        //Activa el Gameover
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.Instance.GameOver();
        }
        //Activa el win
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.Instance.WinGame();
        }
        //Aumenta la velocidad general del juego
        if (Input.GetKeyDown(KeyCode.I))
        {
            timeUp = !timeUp;
            Time.timeScale = timeUp ? 2.0f : 1.0f;
        }
    }
}
