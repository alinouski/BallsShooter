using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "gameEvent", menuName ="GameEvent")]
public class GameEvent : ScriptableObject {

    private List<GameEventListener> listeners = new List<GameEventListener>();

	public void Raise()
    {
        for(int i = listeners.Count-1; i >= 0; i--)
        {
            listeners[i].Raise();
        }
    }

    public void AddListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener)) listeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        if (listeners.Contains(listener)) listeners.Remove(listener);

    }
}
