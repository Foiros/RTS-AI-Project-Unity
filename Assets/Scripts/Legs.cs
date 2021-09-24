using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    public float movement_speed = 5;
    public Transform _transform;
    public Rigidbody _rigidbody;
    public Vector3[] _destinations;

    private bool go_to_base, go_to_mushrooms;
    
    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (go_to_base)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _destinations[0], movement_speed * Time.deltaTime);

            if (_transform.position == new Vector3(_destinations[0].x, _destinations[0].y, _destinations[0].z))
                go_to_base = false;
        }
        else if (go_to_mushrooms)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _destinations[1], movement_speed * Time.deltaTime);
            
            if (_transform.position == new Vector3(_destinations[1].x, _destinations[1].y, _destinations[1].z))
                go_to_mushrooms = false;
        }
    }
    
    public void Change_Destination_From_Outside(int id)
    {
        switch (id)
        {
            case 0: go_to_base = true;
                break;
            
            case 1: go_to_mushrooms = true;
                break;
        }
    }

    public bool Get_Go_To_Base()
    {
        return go_to_base;
    }
    
    public bool Get_Go_To_Mushrooms()
    {
        return go_to_mushrooms;
    }
}
