using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public Legs _legs;
    
    private Brain _brain = new Brain();

    private void Awake()
    {
        _brain.Awaken(_legs);
    }

    void Update()
    {
        _brain.Update();
    }
}
