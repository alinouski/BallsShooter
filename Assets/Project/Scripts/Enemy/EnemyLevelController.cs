using UnityEngine;
using System.Collections;

public class EnemyLevelController : MonoBehaviour
{
    [Header("Level settings")]
    public IntReference level;

    [Header("Enemy settings")]
    public EnemyStats defaultStat;

    public EnemyStats[] levels;
    public EnemyStats step;

    [Header("Generate speed settings")]
    public float defaultGenerate = 1;
    public float[] levelsGenerate;
    public float generateStep;

    public ProgressType progress = ProgressType.TurnBased;
    
    private EnemyStats currentStats;
    private float generateFrecuency = 0;
    
    public void LevelUp()
    {
        switch (progress)
        {
            case ProgressType.TurnBased:
                currentStats = TurnBasedStats();
                generateFrecuency = TurnBasedGenerateSpeed();
                break;
            case ProgressType.Linear:
                currentStats = LinearStats();
                generateFrecuency = LinearGenerateSpeed();
                break;
            default:
                currentStats = defaultStat;
                generateFrecuency = LinearGenerateSpeed();
                break;
        }
    }

    public EnemyStats GetStats()
    {
        if (currentStats == null)
        {
            LevelUp();
        }
        return currentStats;
    }

    public void StartGame()
    {
        LevelUp();
    }

    public float GetGenerateSpeed()
    {
        return generateFrecuency;
    }

    private float TurnBasedGenerateSpeed()
    {
        if (level.Value == 0)
        {
            return defaultGenerate;
        }
        else if (level.Value > levels.Length)
        {
            return levelsGenerate[levelsGenerate.Length - 1];
        }
        else
        {
            return levelsGenerate[level.Value - 1];
        }
    }

    private float LinearGenerateSpeed()
    {
        return defaultGenerate + (generateStep * level.Value);
    }

    private EnemyStats TurnBasedStats()
    {
        if (level.Value == 0)
        {
            return defaultStat;
        }
        else if (level.Value <= levels.Length)
        {
            return levels[level.Value - 1];
        }
        else
        {
            return levels[levels.Length];
        }
    }

    private EnemyStats LinearStats()
    {
        return defaultStat + (step * level.Value);
    }
}

public enum ProgressType
{
    TurnBased,
    Linear
}
