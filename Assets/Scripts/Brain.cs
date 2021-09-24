using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain
{
    private Legs _legs;
    private BinaryTree _binaryTree = new BinaryTree();
    private ActionCenter _actionCenter = new ActionCenter();
    
    private int[] array = { 20, 10, 25, 23, 7, 8, 9 };
    private States[] _statesArray =
    {
        States.Idle, States.GatherActions, States.CookActions, States.Cook, States.GoGather, States.Gather,
        States.ReturnToBase
    };
    
    private Node action_node;
    private bool has_ingredient, in_base;
    
    // Start is called before the first frame update
    public void Awaken(Legs legs)
    {
        _legs = legs;
        has_ingredient = false;
        in_base = true;

        for (int i = 0; i < 7; i++)
        {
            _binaryTree.Insert(array[i], _statesArray[i]);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if(!_legs.Get_Go_To_Base()&& !_legs.Get_Go_To_Mushrooms())
            Update_Information();
    }

    void Update_Information()
    {
        if(!has_ingredient && in_base){

            action_node = _binaryTree.Search(7);
            _legs.Change_Destination_From_Outside(1);;
        }
        else if(!has_ingredient && !in_base){

            action_node = _binaryTree.Search(8);
        }
        else if(has_ingredient && !in_base){

            action_node = _binaryTree.Search(9);
            _legs.Change_Destination_From_Outside(0);
        }
        else if(has_ingredient && in_base){

            action_node = _binaryTree.Search(23);
        }
        
        Use_Information();
        Change_Information();
    }
    
    
    void Use_Information()
    {
        _actionCenter.ChooseAction(action_node);
    }
    
    void Change_Information()
    {
        if(action_node.state == States.GoGather){

            in_base = false;
        }
        else if(action_node.state == States.Gather){
            
            has_ingredient = true;
        }
        else if(action_node.state  == States.ReturnToBase){

            in_base = true;
        }
        else if(action_node.state == States.Cook){

            has_ingredient = false;
        }
    }
}
