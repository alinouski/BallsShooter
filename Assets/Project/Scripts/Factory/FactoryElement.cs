using UnityEngine;
using System.Collections;

public abstract class FactoryElement : MonoBehaviour
{
    public Factory factory;

    private void OnDisable()
    {
        DestroySelf();
    }

    private void OnEnable()
    {
        factory.AddObject(this);
    }

    public virtual void DestroySelf()
    {
        factory.RemoveObject(this);
        factory.AddHidden(this);
    }
}
