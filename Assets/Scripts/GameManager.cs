using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool dontDestroyOnLoad;
    public static GameManager Instance;
    public GameObject playerObject;
    public GameObject ballObject;
    private MainController playerMainController;
    private SpriteRenderer playerSpriteRenderer;
    private CapsuleCollider2D playerCapsuleCollider2D;
    private BallBehaviour ballBehaviour;
    private SpriteRenderer ballSpriteRenderer;

    
    //Singleton
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //Player components
        playerMainController = playerObject.GetComponent<MainController>();
        playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        playerCapsuleCollider2D = playerObject.GetComponent<CapsuleCollider2D>();

        //Ball components
        ballBehaviour = ballObject.GetComponent<BallBehaviour>();
        ballSpriteRenderer = ballObject.GetComponent<SpriteRenderer>();

    }
    
    //propiedades de FastPowerup
    public void FastBall(float speedMultiplier, float buffDuration)
    {
        ballBehaviour.speed *= speedMultiplier;
        ballBehaviour.fastBallOn = true;
        ballBehaviour.FastBallSpeedReset(buffDuration);      
    }
   
    //propiedades de SlowPowerup
    public void SlowBall(float speedMultiplier, float buffDuration)
    {
        ballBehaviour.speed /= speedMultiplier;
        ballBehaviour.slowBallOn = true;
        ballBehaviour.SlowBallSpeedReset(buffDuration);       
    }

    //propiedades de DamagePowerup
    public void DamageBall(int dmgBoost, float buffDuration)
    {
        ballBehaviour.dmg *= dmgBoost;
        ballBehaviour.damageBallOn = true;
        ballBehaviour.DamageBallDmgReset(buffDuration);
        ballSpriteRenderer.color = Color.red;
    }

    //propiedades de DamagePowerup
    public void CannonBall(int dmgBoost, float buffDuration)
    {
        ballBehaviour.dmg *= dmgBoost;
        ballBehaviour.cannonBallOn = true;
        ballBehaviour.CannonBallDmgReset(buffDuration);
        ballSpriteRenderer.color = Color.green;
    }
}
