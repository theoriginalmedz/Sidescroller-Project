using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroy : MonoBehaviour
{
    public float timeBeforeDestroy;
    void Awake()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }
}