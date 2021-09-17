using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCenter
{
    public void ChooseAction(Node action_node)
    {
        if(action_node.state == States.GoGather){

            Go_Gather_Ingredients();
        }
        else if(action_node.state == States.Gather){

            Gather_Ingredient();
        }
        else if(action_node.state == States.ReturnToBase){

            Go_Back_To_Base();
        }
        else if(action_node.state == States.Cook){

            Cook_Ingredients();
        }
    }

    private void Go_Gather_Ingredients()
    {
        Debug.Log("Leaving the base to gather ingredients!");
    }

    private void Gather_Ingredient()
    {
        Debug.Log("Gathering Ingredients!");
    }

    private void Go_Back_To_Base()
    {
        Debug.Log("Returning to the base with the ingredient!");
    }

    private void Cook_Ingredients()
    {
        Debug.Log("Cooking the ingredient!");
    }
}