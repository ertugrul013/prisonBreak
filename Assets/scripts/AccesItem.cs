using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesItem : Item
{

    public int id;

    public AccesItem(string objName, int Weight, int id) : base(objName, Weight)
    {
        this.id = id;
    }
}
