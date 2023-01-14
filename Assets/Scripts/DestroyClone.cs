using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClone : MonoBehaviour
{
    public float time;

    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject, time);
    }
}
