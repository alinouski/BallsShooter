using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Level : FactoryElement
{
    public LevelCollection collection;
    public GameEvent lvlUpEvent;

    void Awake()
    {
        gameObject.tag = TagManager.LEVEL_UP;
        collection.Add(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TagManager.BULLET)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        lvlUpEvent.Raise();
        DestroySelf();
    }

    public override void DestroySelf()
    {
        base.DestroySelf();
    }
}
