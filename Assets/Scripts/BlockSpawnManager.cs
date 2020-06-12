using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    [SerializeField] private BlockBehaviour blockBehaviour;
    [SerializeField] private int level1Height;
    [SerializeField] private int level1Width;
    [SerializeField] private Vector3 level1SpawnPosition;
    [SerializeField] private string currentLevel;
    [SerializeField] private int numberOfBlocksA = 25;
    [SerializeField] private int numberOfBlocksB = 12;
    [SerializeField] private int numberOfBlocksC = 20;
    [SerializeField] private float radius = 5f;
    [SerializeField] private Vector3 level2SpawnPositionA;
    [SerializeField] private Vector3 level2SpawnPositionB;
    [SerializeField] private Vector3 level2SpawnPositionC;
    
    private void Start()
    {
        if (currentLevel == "Level1")
        {
            Level1Pattern();
        }

        if (currentLevel == "Level2")
        {
            Level2Pattern();
        }
    }

    //esta es la forma en la que los bloques salen en nivel 1
    private void Level1Pattern()
    {
        for (int y = 0; y < level1Height; ++y)
        {
            for (int x = 0; x < level1Width; ++x)
            {
                Instantiate(blockBehaviour, level1SpawnPosition + new Vector3(x, y, 0), Quaternion.identity);
            }
        } 
    }

    //esta es la forma en la que los bloques salen en nivel 2
    private void Level2Pattern()
    {
        for (int i = 0; i < numberOfBlocksA; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfBlocksA;
            float y = Mathf.Cos(angle) * radius;
            float x = Mathf.Sin(angle) * radius;
            Vector3 pos = new Vector3(x, y, 0) / 1.5f;
            Instantiate(blockBehaviour, level2SpawnPositionA + pos, Quaternion.identity, transform.parent);
            Instantiate(blockBehaviour, level2SpawnPositionB + pos, Quaternion.identity);
        }
        for (int i = 0; i < numberOfBlocksB; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfBlocksB;
            float y = Mathf.Cos(angle) * radius;
            float x = Mathf.Sin(angle) * radius;
            Vector3 pos = new Vector3(x, y, 0) / 3f;
            Instantiate(blockBehaviour, level2SpawnPositionA + pos, Quaternion.identity);
            Instantiate(blockBehaviour, level2SpawnPositionB + pos, Quaternion.identity);
        }
        for (int y = 0; y < numberOfBlocksC; ++y)
        {
            Vector3 pos = new Vector3(0,y,0) / 3f;
            Instantiate(blockBehaviour, level2SpawnPositionC + pos, Quaternion.identity);
        } 
    }
}
