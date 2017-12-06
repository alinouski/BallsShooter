using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour {

    public PlayerLevelController levelContr;
    public Transform target;
    public Transform bulletParent;
    public Factory bulletFactory;

    public float smallShootDelay = 0.01f;
    public float shootSpeed = 15;
    public ShootType shootType = ShootType.User;

    [Header("Events")]
    public GameEvent shootEnded;
    //public GameEvent blockRotate;
   // public GameEvent unblockRotate;
    
    private PlayerStats stats;

    private Collider2D body;
    private bool shootState = true;

    private void Start()
    {
        bulletFactory.parent = bulletParent;
        body = GetComponent<CircleCollider2D>();
        InitTag();
    }

    private void InitTag()
    {
        //gameObject.tag = TagManager.PLAYER;
    }

    public void EnableShoot()
    {
        if (bulletFactory.OnScene.Count == 0 && bulletFactory.Hidden.Count != 0 && !shootState)
        {
            shootState = true;
            shootEnded.Raise();
        }
    }

    public void DisableShoot()
    {
        shootState = false;
    }

    public void StartGame()
    {
        LevelUp();
        if (shootType == ShootType.Auto)
        {
            StartCoroutine(ShootAuto());
        }
    }

    public void StopGame()
    {
        StopAllCoroutines();
    }

    public void PauseGame()
    {
        StopAllCoroutines();
    }

    public void ResumeGame()
    {
        if (shootType == ShootType.Auto)
        {
            StartCoroutine(ShootAuto());
        }
    }

    public void LevelUp()
    {
        levelContr.LevelUp();
        stats = levelContr.GetStats();
    }    


    private void Update()
    {
        Vector3 diff = target.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        
        EnableShoot();
    }

    public void Shoot()
    {
        if (shootState)
        {
            DisableShoot();
            StartCoroutine(UserShoot());
        }
    }

    public void HideBullets()
    {
        foreach (BulletController bullet in bulletFactory.OnScene)
        {
            Vector2 direction = (transform.position - bullet.transform.position).normalized;
            bullet.Hide(direction * shootSpeed);
        }

        foreach (BulletController bullet in bulletFactory.Hidden)
        {
            if (bullet.gameObject.activeSelf)
            {
                Vector2 direction = (transform.position - bullet.transform.position).normalized;
                bullet.Hide(direction * shootSpeed);
            }
        }
    }

    IEnumerator ShootAuto()
    {
        while (true)
        {
            //unblockRotate.Raise();
            shootState = true;
            yield return new WaitForSeconds(stats.shootFrequency);
            //blockRotate.Raise();
            shootState = false;

            body.enabled = false;
            for (int i = 0; i < stats.shootCount;i++)
            {
                CreateBullet();
                yield return new WaitForSeconds(smallShootDelay);
            }
            yield return new WaitForSeconds(smallShootDelay * 5);
            body.enabled = true;
        }
    }

    IEnumerator UserShoot()
    {
        //blockRotate.Raise();
        gameObject.layer = 5;
        for (int i = 0; i < stats.shootCount; i++)
        {
            CreateBullet();
            yield return new WaitForSeconds(smallShootDelay);
        }
        //unblockRotate.Raise();
        yield return new WaitForSeconds(smallShootDelay * 5);
        //body.enabled = true;        
        gameObject.layer = 0;
    }

    private void CreateBullet()
    {
        GameObject bullet = bulletFactory.CreateObject().gameObject;
        bullet.transform.position = transform.position;
        bullet.SetActive(true);
        BulletStats bs = ScriptableObject.CreateInstance<BulletStats>();

        bs.power = stats.power;
        bs.bounceEnemy = stats.enemyBounce;
        bs.bounceWall = stats.wallBounce;

        bullet.GetComponent<BulletController>().stats = bs;        

        Vector2 direction = target.position - transform.position;
        direction = direction.normalized;

        bullet.GetComponent<BulletController>().Collider2d.isTrigger = false;
        bullet.GetComponent<BulletController>().AddForce(direction * shootSpeed);
    }
}

public enum ShootType
{
    Auto,
    User
}
