using UnityEngine;

/// <summary>
/// Co-Producer:
///     Puck Onnekes
/// </summary>
public class RaftPartItem : Item
{
       public enum TypeOfPart
       {
           wood,
           rope,
           flag
       }

       public TypeOfPart Part;
       public string credit;
       public RaftPartItem(string objName,Sprite objImage, int Weight,string credit, TypeOfPart typeOfPart) : base(objName,objImage, Weight)
       {
           this.credit = credit;
           this.Part = typeOfPart;
       }
}
