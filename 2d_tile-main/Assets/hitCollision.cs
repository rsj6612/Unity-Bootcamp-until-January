using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitCollision : MonoBehaviour
{
    [NonSerialized]public Rigidbody2D parentRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        parentRigidbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}