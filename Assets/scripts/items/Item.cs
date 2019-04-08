using UnityEngine;

﻿public abstract class Item
{
    public Sprite objImage;
    public string objName;
    public int Weight;

    public Item(string objName,Sprite objImage, int weight)
    {
        this.objName = objName;
        this.objImage = objImage;
        this.Weight = weight;
    }
}
