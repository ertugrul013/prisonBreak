﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bonus : Pickup
{
    public int points;

    protected override Item CreateItem()
    {
        return new BonusItem(name,image,weight,points);
    }
}
