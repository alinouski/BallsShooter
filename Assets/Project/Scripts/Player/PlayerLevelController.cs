using UnityEngine;
using System.Collections;

public class PlayerLevelController : MonoBehaviour
{
    [Header("Level settings")]
    public IntReference level;

    public PlayerStats defaultStat;

    public PlayerStats[] levels;
    public PlayerStats step;

    public ProgressType progress = ProgressType.TurnBased;
    
    private PlayerStats currentStats;

    public void LevelUp()
    {
        switch (progress)
        {
            case ProgressType.TurnBased:
                currentStats = TurnBasedStats();
                break;
            case ProgressType.Linear:
                currentStats = LinearStats();
                break;
            default:
                currentStats = defaultStat;
                break;
        }
    }
    
    public void StartGame()
    {
        LevelUp();
    }

    public PlayerStats GetStats()
    {
        if (currentStats == null)
        {
            return defaultStat;
        }
        return currentStats;
    }

    private PlayerStats TurnBasedStats()
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

    private PlayerStats LinearStats()
    {
        return defaultStat + (step * level.Value);
    }
}
