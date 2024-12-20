using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string ItemName;
    public Sprite ItemIcon;

    public bool isStackable = true;

    public GameObject ItemPrefab;

    public abstract ItemClass GetItem();
    public abstract SodaClass GetSoda();
 

 
}
