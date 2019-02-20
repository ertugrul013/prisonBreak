using UnityEngine;

public class AccesItem : Item
{

    public int Door;

    public AccesItem(string name, int weight, int door) : base(name, weight)
    {
        this.Door = door;
    }

}
