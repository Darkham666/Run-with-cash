﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingPool : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> PoolNotUsed;

    [HideInInspector]
    public List<GameObject> PoolUsed;

    public GameObject ToGenerate;
    public List<GameObject> ListToGenerate;
    public int NumberOfObjects = 50;

    void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < NumberOfObjects; ++i)
        {
            int rnd = Random.Range(0, 100);
            GameObject togen = null;

            if (rnd > 90)
                togen = ListToGenerate[ListToGenerate.Count - 1];
            else
            {
                togen = ListToGenerate[Random.Range(0, ListToGenerate.Count - 1)];
            }

            GameObject newObject = GameObject.Instantiate(togen) as GameObject;
            newObject.SetActive(false);

            PoolNotUsed.Add(newObject);
        }
    }

    public GameObject AskOneObject()
    {
        if (PoolNotUsed.Count > 0)
        {
            GameObject objectUsed = PoolNotUsed[Random.Range(0, PoolNotUsed.Count - 1)];
            PoolUsed.Add(objectUsed);
            PoolNotUsed.Remove(objectUsed);
            objectUsed.SetActive(true);
            return objectUsed;
        }

        GenerateMoreObjects();

        if (PoolNotUsed.Count > 0)
        {
            GameObject objectUsed = PoolNotUsed[Random.Range(0, PoolNotUsed.Count - 1)];
            PoolUsed.Add(objectUsed);
            PoolNotUsed.Remove(objectUsed);
            objectUsed.SetActive(true);
            return objectUsed;
        }

        return null;
    }

    public void FreeObject(GameObject toFree)
    {
        if (PoolUsed.Contains(toFree))
        {
            PoolNotUsed.Add(toFree);
            PoolUsed.Remove(toFree);
            toFree.SetActive(false);
        }
    }

    private void GenerateMoreObjects()
    {
        for (int i = 0; i < m_numberToGenerate; ++i)
        {
            GameObject newObject = GameObject.Instantiate(ToGenerate) as GameObject;
            newObject.SetActive(false);

            PoolNotUsed.Add(newObject);
        }
    }

    private int m_numberToGenerate = 5;
}
