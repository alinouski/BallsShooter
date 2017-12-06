using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public EnemyLevelController levelsController;
    public EnemyCollection collection;
    public IntReference destroyedEnemy;
    public Transform enemyParent;
    public Factory enemyFactory;
    [Header("Generate settings")]
    public GenerateType generateType = GenerateType.Custom;
    public EnemyGenerateShapeType generateShapeType = EnemyGenerateShapeType.RandomBox;
    public GenerateDirection generateDirection = GenerateDirection.Both;
    public Vector2 generateCircle;
    public Vector2 generateBox;
    public int enemyCount = 3;

    [Space(5)]
    [Header("Generator settings")]
    public LevelGenerator generator;
    public float convertPosX = 1;

    private int steps = 0;

    private void Start()
    {
        enemyFactory.parent = enemyParent;
        collection.values.Clear();
    }

    public void StartGame()
    {
        levelsController.StartGame();
        destroyedEnemy.Value = 0;
        steps = 0;
        if (generateType == GenerateType.Auto)
        {
            StartCoroutine(Generate());
            StartCoroutine(Move());
        }
        else
        {
            Step();
        }
    }

    public void PauseGame()
    {        
        if (generateType == GenerateType.Auto)
        {
            collection.Pause();
            StopAllCoroutines();
        }
    }

    public void ResumeGame()
    {
        if (generateType == GenerateType.Auto)
        {
            StartCoroutine(Generate());
            StartCoroutine(Move());
            collection.Resume();
        }
    }

    public void StopGame()
    {
        StopAllCoroutines();
        RemoveAll();
    }

    public void RemoveAll()
    {
        for (int i = collection.values.Count - 1; i >= 0; i--)
        {
            collection.values[i].DestroySelf();
        }
    }

    IEnumerator Generate()
    {
        while (true)
        {
            GenerateEnemys();
            yield return new WaitForSeconds(levelsController.GetGenerateSpeed());
        }
    }

    void GenerateEnemys()
    {       
        CreateEnemy();
    }

    IEnumerator Move()
    {
        while (true)
        {
            StartCoroutine(MoveEnemy());
            yield return new WaitForSeconds(levelsController.GetStats().waitTime);
        }
    }

    public void Step()
    {
        GenerateEnemys();
        StartCoroutine(MoveEnemy());
        steps++;
    }

    IEnumerator MoveEnemy()
    {
        for (int i = collection.values.Count - 1; i >= 0; i--)
        {
            collection.values[i].Resume();
        }
        yield return new WaitForSeconds(levelsController.GetStats().moveTime);
        for (int i = collection.values.Count - 1; i >= 0; i--)
        {
            collection.values[i].Pause();
        }
    }

    private void CreateEnemy()
    {
        if(generateShapeType == EnemyGenerateShapeType.RandomBox)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                RandomBoxGenerate();
            }
        }
        else if (generateShapeType == EnemyGenerateShapeType.RandomCircle)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                RandomCircleGenerate();
            }
        }       
        else if (generateShapeType == EnemyGenerateShapeType.CustomShape)
        {
            CustomShapeGenerate();
        }
    }

    void RandomBoxGenerate()
    {
        if (generateDirection == GenerateDirection.Top)
        {
            CreateEnemy(RandomBoxPos(), Vector2.down);
        }
        else if (generateDirection == GenerateDirection.Bottom)
        {
            CreateEnemy(RandomBoxPos(false), Vector2.up);
        }
        else
        {
            CreateEnemy(RandomBoxPos(), Vector2.down);
            CreateEnemy(RandomBoxPos(false), Vector2.up);
        }
    }

    void RandomCircleGenerate()
    {
        if (generateDirection == GenerateDirection.Top)
        {
            CreateEnemy(RandomCirclePos(90, 45), Vector2.down);
        }
        else if (generateDirection == GenerateDirection.Bottom)
        {
            CreateEnemy(RandomCirclePos(90, 45, false), Vector2.up);
        }
        else
        {
            CreateEnemy(RandomCirclePos(90, 45), Vector2.down);
            CreateEnemy(RandomCirclePos(90, 45, false), Vector2.up);
        }
    }

    void CustomShapeGenerate()
    {
        List<int> positions = generator.GetPositions(steps);
        if (generateDirection == GenerateDirection.Top)
        {            
            foreach (int x in positions)
            {
                CreateEnemy(new Vector2(x * convertPosX + convertPosX / 2.0f, generateBox.y), Vector2.down);
            }
        }
        else if (generateDirection == GenerateDirection.Bottom)
        {
            foreach (int x in positions)
            {
                CreateEnemy(new Vector2(x * convertPosX + convertPosX / 2.0f, -generateBox.y), Vector2.up);
            }
        }
        else
        {
            foreach (int x in positions)
            {
                CreateEnemy(new Vector2(x * convertPosX + convertPosX / 2.0f, generateBox.y), Vector2.down);
            }
            foreach (int x in positions)
            {
                CreateEnemy(new Vector2(x * convertPosX + convertPosX / 2.0f, -generateBox.y), Vector2.up);
            }
        }
    }

    private void CreateEnemy(Vector2 pos, Vector2 direction)
    {
        GameObject enemy = enemyFactory.CreateObject().gameObject;
        EnemyController enemyContr = enemy.GetComponent<EnemyController>();
        SetStats(ref enemyContr);
        enemy.transform.position = pos;
        enemyContr.SetDirection(direction);
        enemy.SetActive(true);
    }

    private void SetStats(ref EnemyController ec)
    {
        ec.stats = EnemyStat();
    }

    private EnemyStats EnemyStat()
    {
        return levelsController.GetStats();
    }

    private Vector2 RandomCirclePos(float degrees = 360.0f, float minDegrees = 0.0f, bool top = true)
    {
        Vector2 pos;
        float ang = Random.value * degrees - minDegrees;
        float radius = Random.Range(generateCircle.x, generateCircle.y);

        pos.x = radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        if (!top)
            pos = -pos;
        return pos;
    }

    private Vector2 RandomBoxPos(bool top = true)
    {
        Vector2 pos;

        pos.x = Random.Range(-generateBox.x, generateBox.x);
        pos.y = generateBox.y;
        if (!top)
            pos = -pos;
        return pos;
    }
}

public enum EnemyGenerateShapeType
{
    RandomCircle,
    RandomBox,
    CustomShape
}

public enum GenerateDirection
{
    Top,
    Bottom,
    Both
}

public enum GenerateType
{
    Auto,
    Custom
}
