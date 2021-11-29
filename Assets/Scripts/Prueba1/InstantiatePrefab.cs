﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour

{
    public GameObject prefab;
    public Transform point;
    public float livingTime;
    // Start is called before the first frame update
    public void Instantiate()
    {
        GameObject instantiatedObject = Instantiate(prefab, point.position, Quaternion.identity) as GameObject;
        if (livingTime > 0)
        {
            Destroy(instantiatedObject, livingTime);
        }
    }
}
