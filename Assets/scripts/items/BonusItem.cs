using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item
{

    public int points;

    public BonusItem(string objName, int Weight, int points) : base(objName, Weight)
    {
        this.points = points;
    }
}
