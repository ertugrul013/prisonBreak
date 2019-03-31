using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccesItem : Item
{
    public int id;

    public AccesItem(string objName,Sprite objImage ,int Weight, int id) : base(objName,objImage ,Weight)
    {
        this.id = id;
    }
}
