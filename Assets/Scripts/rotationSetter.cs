﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationSetter : MonoBehaviour
{
    public Vector3 constRotation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.localRotation = Quaternion.Euler(constRotation);
    }
}
