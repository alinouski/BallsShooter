using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "bulletCollection", menuName = "Managers/Bullet collection", order = 51)]
public class BulletCollection : RuntimeSet<BulletController>
{
    public void Resume()
    {
        for (int i = values.Count - 1; i >= 0; i--)
        {
            values[i].Resume();
        }
    }

    public void Pause()
    {
        for (int i = values.Count - 1; i >= 0; i--)
        {
            values[i].Pause();
        }
    }

    public bool Enabled()
    {
        if(values.Count == 0)
        {
            return true;
        }

        for (int i = values.Count - 1; i >= 0; i--)
        {
            if (values[i].gameObject.active)
            {
                return true;
            }
        }
        return false;
    }
}
