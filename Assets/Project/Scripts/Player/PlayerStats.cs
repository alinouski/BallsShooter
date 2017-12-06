using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerStat", menuName = "Player/Stats", order = 51)]
public class PlayerStats : ScriptableObject
{
    [Tooltip("Скорость выстрела")]
    public float shootFrequency = 1;
    [Tooltip("Количество шариков за выстрел")]
    public float shootCount = 1;
    [Tooltip("Отскоков от стены")]
    public int wallBounce = 1;
    [Tooltip("Отскоков от врагов")]
    public int enemyBounce = 1;
    [Tooltip("Урон по врагам")]
    public int power = 1;

    public static PlayerStats operator +(PlayerStats obj1, PlayerStats obj2)
    {
        PlayerStats arr = CreateInstance<PlayerStats>();
        arr.shootFrequency = obj1.shootFrequency + obj2.shootFrequency;
        arr.shootCount = obj1.shootCount + obj2.shootCount;
        arr.wallBounce = obj1.wallBounce + obj2.wallBounce;
        arr.enemyBounce = obj1.enemyBounce + obj2.enemyBounce;
        arr.power = obj1.power  + obj2.power;
        return arr;
    }

    public static PlayerStats operator *(PlayerStats obj1, int count)
    {
        PlayerStats arr = CreateInstance<PlayerStats>();
        arr.shootFrequency = obj1.shootFrequency * count;
        arr.shootCount = obj1.shootCount * count;
        arr.wallBounce = obj1.wallBounce * count;
        arr.enemyBounce = obj1.enemyBounce * count;
        arr.power = obj1.power * count;
        return arr;
    }

}
