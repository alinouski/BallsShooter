using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OnTriggerController : MonoBehaviour {

    public string collidedTag = "player";
    public GameEvent collideEvent;
    public UnityEvent ColliderEvent1;
    [HideInInspector]
    public GameObject obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == collidedTag)
        {
            obj = collision.transform.gameObject;
            if (collideEvent)
            {
                collideEvent.Raise();
            }
            ColliderEvent1.Invoke();
        }
    }
}
