using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemyCollection", menuName = "Managers/Enemy collection", order = 51)]
public class EnemyCollection : RuntimeSet<EnemyController> {

    public void Resume()
    {
        for (int i = values.Count - 1; i >= 0; i--)
        {
            values[i].Resume();
        }
    }

    public void Pause()
    {
        for (int i = values.Count - 1; i >= 0; i--)
        {
            values[i].Pause();
        }
    }
}
