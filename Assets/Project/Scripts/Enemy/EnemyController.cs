using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : FactoryElement {

    public IntReference destroyedCount;
    public EnemyCollection collection;
    public Transform target;
    public EnemyStats stats;
    public GameEvent enemyDown;
    public TextMesh text;

    private int health;
    private Rigidbody2D rb;
    private Vector2 dir;

    private void Awake()
    {
        gameObject.tag = TagManager.ENEMY;
        rb = GetComponent<Rigidbody2D>();
        collection.Add(this);
    }

    public void Hit(int power)
    {
        health -= power;
        UpdateText();
        if (health <=0)
        {
            enemyDown.Raise();
            destroyedCount.Value++;
            DestroySelf();
        }
    }

    public void Pause()
    {
        rb.velocity = Vector2.zero;
    }

    public void Resume()
    {
        rb.velocity = dir;
    }

    public void SetDirection(Vector2 d)
    {
        dir = d * stats.speed;
    }

    public override void DestroySelf()
    {
        base.DestroySelf();
        health = stats.health;
        UpdateText();
    }

    private void OnEnable()
    {
        health = stats.health;
        UpdateText();
    }
    
    private void OnDestroy()
    {
        collection.Remove(this);
    }

    private void UpdateText()
    {
        text.text = health.ToString();
    }
}
