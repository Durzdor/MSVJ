using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    [HideInInspector]public bool dontDestroyOnLoad;
    public static GameManager Instance;
    public static float score;
    [SerializeField] private static int baseScore = 100;
    public GameObject playerObject; 
    private MainController playerMainController;
    private SpriteRenderer playerSpriteRenderer;
    private CapsuleCollider2D playerCapsuleCollider2D;
    public BallBehaviour ballBehaviour;
    public BlockBehaviour blockBehaviour;
    private SpriteRenderer ballSpriteRenderer;
    [SerializeField] Sprite smallPlayer;
    [SerializeField] Sprite normalPlayer;
    [SerializeField] Sprite largePlayer;
    private float playerSize = 1f;
    public int currentLives;
    [SerializeField] private int maxLives;
    public List<BallBehaviour> ballList = new List<BallBehaviour>();
    public List<BlockBehaviour> blockList = new List<BlockBehaviour>();
    [SerializeField] private int blockHeight;
    [SerializeField] private int blockWidth;
    [SerializeField] private Vector3 blockSpawnPosition;
    public List<Drops> dropList = new List<Drops>();
    private int blockCount;
    private bool notDone = true;
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
        BlockSpawner();
    }
    private void Start()
    {
        //Player components
        playerMainController = playerObject.GetComponent<MainController>();
        playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        playerCapsuleCollider2D = playerObject.GetComponent<CapsuleCollider2D>();
        blockCount = blockList.Count / 2;
        BallRespawner();
    }

    //propiedades de FastPowerup
    public void FastBall(float speedMultiplier, float buffDuration)
    {
        for (int i = 0; i < ballList.Count; i++)
        {
            ballList[i].speed += speedMultiplier;
            ballList[i].fastBallOn = true;
            ballList[i].FastBallSpeedReset(buffDuration, speedMultiplier);
        }
    }

    //propiedades de SlowPowerup
    public void SlowBall(float speedMultiplier, float buffDuration)
    {
        for (int i = 0; i < ballList.Count; i++)
        {
            ballList[i].speed -= speedMultiplier;
            ballList[i].slowBallOn = true;
            ballList[i].SlowBallSpeedReset(buffDuration, speedMultiplier);
        }
    }

    //propiedades de DamagePowerup
    public void DamageBall(int dmgBoost, float buffDuration)
    {
        for (int i = 0; i < ballList.Count; i++)
        {
            ballList[i].dmg += dmgBoost;
            ballList[i].damageBallOn = true;
            ballList[i].DamageBallDmgReset(buffDuration, dmgBoost);
        }
    }

    //propiedades de CannonPowerup
    public void CannonBall(int dmgBoost, float buffDuration)
    {
        for (int i = 0; i < ballList.Count; i++)
        {
            ballList[i].dmg += dmgBoost;
            ballList[i].cannonBallOn = true;
            ballList[i].CannonBallDmgReset(buffDuration, dmgBoost);
        }
    }

    //Cuenta los puntos conseguidos por bloques
    public void ScoreCounter(int dmg)
    {
        if (dmg > 20)
        {
            dmg = 20;
        }
        score += baseScore * dmg * playerSize;
        Debug.Log(score);
    }

    //Cuenta los puntos conseguidos por drop
    public void ScoreBonus(int bonusScore)
    {
        score += bonusScore;
        Debug.Log(score);
    }

    //propiedades de ShrinkPowerup
    public void ShrinkPlayer(float buffDuration, float sizeMultiplier)
    {
        playerSpriteRenderer.sprite = smallPlayer;
        playerCapsuleCollider2D.size = new Vector2(0.46f, 0.256f);
        playerMainController.smallPowerOn = true;
        playerMainController.ShrinkPlayerReset(buffDuration, sizeMultiplier);
        playerSize += sizeMultiplier;
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
        playerSize += sizeMultiplier;
    }

    //propiedades de TriplePowerup
    public void TripleBall(int ballAmount, int extraLives)
    {
        Vector3 offset = (Vector3.right + Vector3.up) / 3;
        currentLives += extraLives;
        for (int i = 0; i < ballAmount; i++)
        {
            BallBehaviour extraball = Instantiate(ballBehaviour, ballList[0].transform.position + offset, transform.rotation); 
            extraball.direction = ballList[0].direction.normalized;
            BallBehaviour extraextraball = Instantiate(ballBehaviour, ballList[0].transform.position - offset, transform.rotation);
            extraextraball.direction = ballList[0].direction.normalized;
        }
    }

    //propiedades de MagnetPowerup
    public void MagnetPlayer(float buffDuration)
    {
        playerMainController.magnetPowerOn = true;
        playerMainController.MagnetPlayerReset(buffDuration);
    }

    //Ball respawner
    public void BallRespawner()
    {
        if (ballList.Count != 0 || currentLives <= 0) return;
        Transform spawnLocation = playerMainController.transform.Find("StartPoint");
        Vector3 position = spawnLocation.position;
        BallBehaviour newBall = Instantiate(ballBehaviour, position, Quaternion.identity);
    }
    //Ball Remover
    public void BallRemover(BallBehaviour ball)
    {
        ballList.Remove(ball);
    }
    //Ball Add
    public void BallAdd(BallBehaviour ball)
    {
        ballList.Add(ball);
    }

    //Block spawner
    private void BlockSpawner()
    {
        for (int y = 0; y < blockHeight; ++y)
        {
            for (int x = 0; x < blockWidth; ++x)
            {
                Instantiate(blockBehaviour, blockSpawnPosition + new Vector3(x,y,0), Quaternion.identity);
            }
        }
    }

    private void Instantiate()
    {
        throw new System.NotImplementedException();
    }

    //Block add
    public void BlockAdd(BlockBehaviour block)
    {
        blockList.Add(block);
    }
    //Block Remove
    public void BlockRemover(BlockBehaviour block)
    {
        blockList.Remove(block);
        if (blockList.Count <= 0)
        {
            WinGame();
        }
        if (blockList.Count > blockCount || ballList.Count <= 0 || !notDone) return;
        foreach (var ball in ballList)
        {
            ball.speed += 2;
        }
        ballBehaviour.speed += 2;
        notDone = false;
    }
    
    //Block Drops
    public void DropAssign(BlockBehaviour block, int dropNumber)
    {
        //Checkea vidas y cantidad de bloques es divisible por 3
        if (currentLives > 0 && blockList.Count % 3 == 0)
        {
                Instantiate(dropList[dropNumber], block.transform.position, transform.rotation);
        }
    }
    //LifeCounter
    public void LifeCounter()
    {
        currentLives--;
        LoseCondition();
    }

    //Lose conditions
    private void LoseCondition()
    {
        if (currentLives <= 0)
        {
            GameOver();
        }
    }
    
    //Gameover stuff
    private void GameOver()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0.0f;
        //(esto es un reload)SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    // Win game
    private void WinGame()
    {
        Debug.Log("You Win");
        Time.timeScale = 0.0f;  
    }
}
