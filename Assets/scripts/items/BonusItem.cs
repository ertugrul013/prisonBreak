using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusItem : Item
{

    public int points;

    public BonusItem(string objName,Image objImage, int Weight, int points) : base(objName,objImage,Weight)
    {
        this.points = points;
    }
}
