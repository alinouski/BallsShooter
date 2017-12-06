using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public IntReference level;

    public void StartGame()
    {
        level.Value = 0;
    }

    public void LevelUp()
    {
        level.Value++;
    }
}
