using UnityEngine.UI;

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
       public RaftPartItem(string objName, int Weight,string credit, TypeOfPart typeOfPart) : base(objName, Weight)
       {
           this.credit = credit;
           this.Part = typeOfPart;
       }
}
