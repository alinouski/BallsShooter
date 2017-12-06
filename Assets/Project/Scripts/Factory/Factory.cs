using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "factory", menuName = "Factory/default", order = 51)]
public class Factory : ScriptableObject {

    public Transform parent;
    public FactoryElement cloneObject;

    private List<FactoryElement> onScecne = new List<FactoryElement>();
    private List<FactoryElement> hidden = new List<FactoryElement>();

    public List<FactoryElement> OnScene
    {
        get
        {
            return onScecne;
        }
    }

    public List<FactoryElement> Hidden
    {
        get
        {
            return hidden;
        }
    }

    void Avake() {
        InitFactory();  
	}

    private void OnEnable()
    {
        InitFactory();
    }

    [EasyButtons.Button]
    public void InitFactory()
    {
        onScecne.Clear();
        hidden.Clear();
        //Debug.Log("Create bullets");
        //for (int i = 0; i < startBulletCount; i++)
        //{
        //    FactoryElement o = Instantiate(cloneObject);
        //    o.gameObject.SetActive(false);
        //    hidden.Add(o);
        //}
    }

    public void RemoveAll()
    {
        for (int i = onScecne.Count-1; i >=0;i--)
        {
            RemoveObject(onScecne[i]);
        }
    }

    public void AddHidden(FactoryElement fe)
    {
        if (!hidden.Contains(fe))
            hidden.Add(fe);
    }
	
    public FactoryElement CreateObject()
    {
        FactoryElement bullet;
        if (hidden.Count > 0)
        {
            bullet = hidden[hidden.Count - 1];
            onScecne.Add(bullet);
            hidden.Remove(bullet);
        }
        else
        {
            if (parent)
            {
                bullet = Instantiate(cloneObject, parent);
            }
            else
            {
                bullet = Instantiate(cloneObject);
            }
            bullet.gameObject.SetActive(false);
        }
        return bullet;
    }

    public void RemoveObject(FactoryElement o)
    {
        //if (onScecne.Contains(o))
        {
            onScecne.Remove(o);
            AddHidden(o);
            o.gameObject.SetActive(false);
        }
    }

    public void AddObject(FactoryElement o)
    {
        Hidden.Remove(o);
        if (!OnScene.Contains(o))
        {
            OnScene.Add(o);
        }
    }
}
