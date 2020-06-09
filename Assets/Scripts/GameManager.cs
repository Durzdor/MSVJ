using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public bool dontDestroyOnLoad;
    public static GameManager Instance;
    public static float score;
    [SerializeField] private static int baseScore = 100;
    public GameObject playerObject; 
    private MainController playerMainController;
    private SpriteRenderer playerSpriteRenderer;
    private CapsuleCollider2D playerCapsuleCollider2D;
    public BallBehaviour ballBehaviour;
    private SpriteRenderer ballSpriteRenderer;
    [SerializeField] Sprite smallPlayer;
    [SerializeField] Sprite normalPlayer;
    [SerializeField] Sprite largePlayer;
    private float playerSize = 1f;
    private float defaultSizeMultiplier = 1f;
    public int currentLives;
    [SerializeField] private int maxLives;
    #endregion

    
    private void Awake()
    {
        //Singleton
        if (Instance == null)
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
        currentLives = maxLives;

    }
    private void Start()
    {
        //Player components
        playerMainController = playerObject.GetComponent<MainController>();
        playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        playerCapsuleCollider2D = playerObject.GetComponent<CapsuleCollider2D>();

        //Ball components
        ballBehaviour = ballBehaviour.GetComponent<BallBehaviour>();
        ballSpriteRenderer = ballBehaviour.GetComponent<SpriteRenderer>();

    }

    //propiedades de FastPowerup
    public void FastBall(float speedMultiplier, float buffDuration)
    {
        ballBehaviour.speed += speedMultiplier;
        ballBehaviour.fastBallOn = true;
        ballBehaviour.FastBallSpeedReset(buffDuration, speedMultiplier);
    }

    //propiedades de SlowPowerup
    public void SlowBall(float speedMultiplier, float buffDuration)
    {
        ballBehaviour.speed -= speedMultiplier;
        ballBehaviour.slowBallOn = true;
        ballBehaviour.SlowBallSpeedReset(buffDuration, speedMultiplier);
    }

    //propiedades de DamagePowerup
    public void DamageBall(int dmgBoost, float buffDuration)
    {
        ballBehaviour.dmg += dmgBoost;
        ballBehaviour.damageBallOn = true;
        ballBehaviour.DamageBallDmgReset(buffDuration, dmgBoost);
    }

    //propiedades de CannonPowerup
    public void CannonBall(int dmgBoost, float buffDuration)
    {
        ballBehaviour.dmg *= dmgBoost;
        ballBehaviour.cannonBallOn = true;
        ballBehaviour.CannonBallDmgReset(buffDuration, dmgBoost);
    }

    //Cuenta los puntos conseguidos
    public void ScoreCounter(int dmg)
    {
        if (dmg > 20)
        {
            dmg = 20;
        }
        score += baseScore * dmg * playerSize;
        Debug.Log(score);
    }

    //propiedades de ShrinkPowerup
    public void ShrinkPlayer(float buffDuration, float sizeMultiplier)
    {
        playerSpriteRenderer.sprite = smallPlayer;
        playerCapsuleCollider2D.size = new Vector2(0.46f, 0.256f);
        playerMainController.smallPowerOn = true;
        playerMainController.ShrinkPlayerReset(buffDuration, sizeMultiplier);
        playerSize = sizeMultiplier;
    }

    //tamaño normal de player
    public void NormalPlayer(float sizeMultiplier)
    {
        playerSpriteRenderer.sprite = normalPlayer;
        playerCapsuleCollider2D.size = new Vector2(0.97f, 0.256f);
        //playerMainController.normalPowerOn = true;
        playerSize -= sizeMultiplier;
    }

    //propiedades de EnlargePowerup
    public void EnlargePlayer(float buffDuration, float sizeMultiplier)
    {
        playerSpriteRenderer.sprite = largePlayer;
        playerCapsuleCollider2D.size = new Vector2(1.386f, 0.256f);
        playerMainController.largePowerOn = true;
        playerMainController.EnlargePlayerReset(buffDuration, sizeMultiplier);
        playerSize = sizeMultiplier;
    }

    //propiedades de TriplePowerup
    public void TripleBall(int ballAmount, int extraLives)
    {
        Vector3 offset = (Vector3.right + Vector3.up) / 3;
        currentLives += extraLives;
        for (int i = 0; i < ballAmount; i++)
        {
            BallBehaviour extraball = Instantiate(ballBehaviour, ballBehaviour.transform.position + offset, transform.rotation);
            extraball.GetComponent<SpriteRenderer>().color = Color.blue;
            extraball.direction = ballBehaviour.direction;
            BallBehaviour extraextraball = Instantiate(ballBehaviour, ballBehaviour.transform.position - offset, transform.rotation);
            extraextraball.GetComponent<SpriteRenderer>().color = Color.magenta;
            extraextraball.direction = ballBehaviour.direction;
        }
    }

    //LifeCounter
    public void LifeCounter()
    {
        currentLives--;
    }
}
