using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Item
{
    public string objName;
    public int Weight;

    public Item(string objName, int weight)
    {
        this.objName = objName;
        this.Weight = weight;
    }
}
