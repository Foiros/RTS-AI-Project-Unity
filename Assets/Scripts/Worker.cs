using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    private Brain _brain = new Brain();

    private void Awake()
    {
        _brain.Awaken();
    }

    void Update()
    {
        _brain.Update();
    }
}
