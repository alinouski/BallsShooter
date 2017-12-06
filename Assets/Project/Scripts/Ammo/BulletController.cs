using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : FactoryElement {

    public BulletCollection collection;
    public GameObject avatar;
    public BulletStats stats;

    private Rigidbody2D m_body;
    private Collider2D collider2d;
    private int m_bounceEnemy = 0;
    private int m_bounceWall = 0;

    public Collider2D Collider2d
    {
        get { return collider2d; }
    }

    private Vector2 cashedVelocity;

    void Awake () {
        gameObject.tag = TagManager.BULLET;
        collider2d = GetComponent<Collider2D>();
        m_body = GetComponent<Rigidbody2D>();
        collection.Add(this);
	}
	
    public void SetStats(BulletStats stats)
    {
        this.stats = stats;
    }

	public void AddForce(Vector2 dir, ForceMode2D fType = ForceMode2D.Impulse)
    {
        if (m_body == null)
        {
            m_body = GetComponent<Rigidbody2D>();
        }
        m_body.AddForce(dir, fType);
    }

    public void Pause()
    {
        cashedVelocity = m_body.velocity;
        m_body.velocity = Vector2.zero;        
    }

    public void Resume()
    {
        AddForce(cashedVelocity);
    }

    private void Hit()
    {
        m_bounceEnemy++;

        if (m_bounceEnemy > stats.bounceEnemy)
        {
            DestroySelf();
        }
    }

    private void Bounce()
    {
        m_bounceWall++;

        if (m_bounceWall > stats.bounceWall)
        {
            DestroySelf();
        }
    }

    public void Hide(Vector2 dir)
    {
        collider2d.isTrigger = true;
        m_body.inertia = 0;
        m_body.velocity = Vector2.zero;
        AddForce(dir);
    }

    public override void DestroySelf()
    {
        base.DestroySelf();
        m_bounceWall = 0;
        m_bounceEnemy = 0; 
        transform.position = Vector2.zero;
    }

    private void OnDestroy()
    {
        collection.Remove(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == TagManager.END_ZONE)
        {
            collider2d.isTrigger = false;
            DestroySelf();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == TagManager.END_ZONE)
        {
            DestroySelf();
        }
        if (collision.gameObject.tag == TagManager.ENEMY)
        {
            Hit();
            collision.gameObject.GetComponent<EnemyController>().Hit(stats.power);
        }
        else if (collision.gameObject.tag == TagManager.WALL)
        {
            Bounce();
        }
    }
}
