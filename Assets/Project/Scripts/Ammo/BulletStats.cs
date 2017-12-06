using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bulletStat", menuName = "Bullet/Stats", order = 51)]
public class BulletStats : ScriptableObject {

    [Tooltip("Сколько пуля отнимает у противника")]
    public int power = 1;
    [Tooltip("Сколько пуля может отскакивать от врагов")]
    public int bounceEnemy = 1;
    [Tooltip("Сколько пуля может отскакивать от стен")]
    public int bounceWall = 1;
}
