using UnityEngine;

public class RaftPart : Pickup
{
    protected override Item CreateItem()
    {
        return new RaftPartItem(name,image,weight);
    }
}
