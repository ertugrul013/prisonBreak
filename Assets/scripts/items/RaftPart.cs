using UnityEngine;

public class RaftPart : Pickup
{
    public RaftPartItem.TypeOfPart Part;
    public string Credit = "Puck Onnekes";

    protected override Item CreateItem()
    {
        return new RaftPartItem(name,weight,Credit,Part);
    }

    private void Awake()
    {
        Debug.Log(Part.ToString());
    }
}