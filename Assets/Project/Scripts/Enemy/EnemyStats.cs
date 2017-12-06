using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "enemyStat", menuName = "Enemy/Stats", order = 51)]
public class EnemyStats : ScriptableObject
{
    [Tooltip("Максимальный запас здоровья")]
    public int health = 1;
    [Tooltip("Скорость движения")]
    public float speed = 1;
    [Tooltip("Время движения")]
    public float moveTime = 1;
    [Tooltip("Время ожидания")]
    public float waitTime = 1;

    public static EnemyStats operator +(EnemyStats obj1, EnemyStats obj2)
    {
        EnemyStats arr = CreateInstance<EnemyStats>();
        arr.health = obj1.health + obj2.health;
        arr.speed = obj1.speed + obj2.speed;
        arr.moveTime = obj1.moveTime + obj2.moveTime;
        arr.waitTime = obj1.waitTime + obj2.waitTime;
        return arr;
    }

    public static EnemyStats operator *(EnemyStats obj1, int count)
    {
        EnemyStats arr = CreateInstance<EnemyStats>();
        arr.health = obj1.health * count;
        arr.speed = obj1.speed * count;
        arr.moveTime = obj1.moveTime * count;
        arr.waitTime = obj1.waitTime * count;
        return arr;
    }
}