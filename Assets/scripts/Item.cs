using UnityEngine;

public abstract class Item
{
    public string Name;
    public int Weight;

    public Item(string name, int weight)
    {
        this.Name = name;
        this.Weight = weight;
    }
}
