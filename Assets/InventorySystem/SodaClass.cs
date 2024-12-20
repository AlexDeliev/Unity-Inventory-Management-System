using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "new Soda Class", menuName = "Item/Soda")]
public class SodaClass :ItemClass
{
    [Header("Soda")]

    public SodaType sodaType;

    
    public enum SodaType
    {
        Large,
        Medium,
        
        Small

    }
    
    public override ItemClass GetItem(){return this;}
    public override SodaClass GetSoda(){return this;}
}
