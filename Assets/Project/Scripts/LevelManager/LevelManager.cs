using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    public LevelCollection collection;
    public Transform lvlParent;
    public Factory lvlFactory;
    public Vector2 generateCircle;
    public float generateSpeed = 5;
    public GenerateType generateType = GenerateType.Custom;
    public IntReference gameSteps;
    public AnimationCurve generateChance;

    private void Start()
    {
        lvlFactory.parent = lvlParent;
        collection.values.Clear();
    }

    public void StartGame()
    {
        if (generateType == GenerateType.Auto)
        {
            StartCoroutine(Generate());
        }
    }

    public void PauseGame()
    {
        if (generateType == GenerateType.Auto)
        {
            StopAllCoroutines();
        }
    }

    public void ResumeGame()
    {
        if (generateType == GenerateType.Auto)
        {
            StartCoroutine(Generate());
        }
    }

    public void StopGame()
    {
        StopAllCoroutines();
        RemoveAll();
    }

    public void RemoveAll()
    {
        for (int i = collection.values.Count - 1; i >= 0; i--)
        {
            collection.values[i].DestroySelf();
        }
    }

    IEnumerator Generate()
    {
        while (true)
        {
            yield return new WaitForSeconds(generateSpeed);

            CreateLevelUp();
        }
    }

    public void CreateLevelUp()
    {
        if (Random.Range(0,100) <= generateChance.Evaluate(gameSteps.Value))
        {
            GameObject lvl = lvlFactory.CreateObject().gameObject;
            lvl.transform.position = RandomPos();
            lvl.SetActive(true);
        }
    }

    private Vector2 RandomPos()
    {
        Vector2 pos;
        float ang = Random.value * 360;
        float radius = Random.Range(generateCircle.x, generateCircle.y);

        pos.x = radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = radius * Mathf.Cos(ang * Mathf.Deg2Rad);

        return pos;
    }
}
