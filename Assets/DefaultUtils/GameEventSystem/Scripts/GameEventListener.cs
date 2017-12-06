using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

	public GameEvent gameEvent;
    public UnityEvent action;

    public void Raise()
    {
        if (action != null)
        {
            action.Invoke();
        }
    }

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);

    }
}
