using UnityEngine;
using System.Collections;

public abstract class FactoryElement : MonoBehaviour
{
    public Factory factory;

    private void OnDisable()
    {
        factory.OnScene.Remove(this);
    }

    public virtual void DestroySelf()
    {
        factory.RemoveObject(this);
        factory.AddHidden(this);
    }
}
