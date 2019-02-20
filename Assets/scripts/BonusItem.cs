using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class BonusItem : Item
{

    public int Points;

    public BonusItem(string name, int weight, int points) : base(name, weight)
    {
        this.Points = points;
    }
}
