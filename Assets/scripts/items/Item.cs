using UnityEngine.UI;

﻿public abstract class Item
{
    public Image objImage;
    public string objName;
    public int Weight;

    public Item(string objName,Image objImage, int weight)
    {
        this.objName = objName;
        this.objImage = objImage;
        this.Weight = weight;
    }
}
