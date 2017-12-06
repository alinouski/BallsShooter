using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public IntReference score;
    public IntReference bestScore;
    [Space(10)]
    [Header("Event")]
    public GameEvent newBest;

    private void Awake()
    {
        score.Value = 0;
        bestScore.Value = BestScore;
    }

    private void FixedUpdate()
    {
        if (score.Value > bestScore.Value)
        {
            bestScore.Value = score.Value;
            BestScore = bestScore.Value;
            newBest.Raise();
        }
    }

    public static int BestScore
    {
        get { return PlayerPrefs.GetInt("bestScore"); }
        set { PlayerPrefs.SetInt("bestScore", value); }
    }
}
