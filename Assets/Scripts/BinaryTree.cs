using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle, 
    GatherActions,
    CookActions,
    GoGather,
    Gather,
    ReturnToBase,
    Cook
}

public class Node
{
    public int data;
    public States state;
    public Node left_child;
    public Node right_child;
}

public class BinaryTree
{
    public Node root;

   public bool Insert(int data, States state)
    {
        Node before = null, after = this.root;

        while (after != null)
        {
            before = after;

            if (data < after.data)
                after = after.left_child;
            else if (data > after.data)
                after = after.right_child;
            else
            {
                return false;
            }
        }

        Node newNode = new Node();
        newNode.data = data;
        newNode.state = state;

        if (this.root == null)
            this.root = newNode;
        else
        {
            if (data < before.data)
                before.left_child = newNode;
            else
            {
                before.right_child = newNode;
            }
        }

        return true;
    }

    public Node Search(int data)
    {
        return Find(data, this.root);
    }
    
    private Node Find(int value, Node parent)
    {
        if (parent != null)
        {
            if (value == parent.data) return parent;
            if (value < parent.data)
                return Find(value, parent.left_child);
            else
                return Find(value, parent.right_child);
        }
 
        return null;
    }

    public void PreOrderTraversal(Node _root)
    {
        if (_root != null)
        {
            Debug.Log(_root.data + " ");
            PreOrderTraversal(_root.left_child);
            PreOrderTraversal(_root.right_child);
        }
    }

    public void InOrderTraversal(Node _root)
    {
        if (_root != null)
        {
            InOrderTraversal(_root.left_child);
            Debug.Log(_root.data + " ");
            InOrderTraversal(_root.right_child);
        }
    }

    public void PostOrderTraversal(Node _root)
    {
        if (_root != null)
        {
            PostOrderTraversal(_root.left_child);
            PostOrderTraversal(_root.right_child);
            Debug.Log(_root.data + " ");
        }
    }
}
