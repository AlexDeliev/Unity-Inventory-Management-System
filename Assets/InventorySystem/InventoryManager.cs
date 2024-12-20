using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject itemCursor;
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private ItemClass ItemToAdd;
    [SerializeField] private ItemClass itemRemove;
    [SerializeField] private SlotClass[] startingItems;

    private SlotClass[] items;

    private GameObject[] slots;

    private SlotClass movingSlot;
    private SlotClass tempSlot;
    private SlotClass originalSlot;
    bool isMovingItem;
    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];
        for(int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }

        for(int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }



        for(int i = 0; i<slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();

        Add(ItemToAdd, 1);
        Remove(itemRemove);
    }

    private void Update()
{
    itemCursor.SetActive(isMovingItem);
    itemCursor.transform.position = Input.mousePosition;
    
    if (isMovingItem)
    {
        itemCursor.GetComponent<Image>().sprite = movingSlot.GetItem().ItemIcon;
        
        // Проверка за отпускане на бутона
        if (Input.GetMouseButtonUp(0)) // отпускаме бутона
        {
            EndItemMove();
        }
    }
    else
    {
        // Проверка за натискане на бутона
        if (Input.GetMouseButtonDown(0)) // натискаме бутона
        {
            BeginItemMove();
        }
    }
}



    #region Inventory Utils
    public void RefreshUI()
    {
        for(int i = 0; i<slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().ItemIcon;
                
                if(items[i].GetItem().isStackable)
                {
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].GetQuantity() + "";
                }
                else
                {
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                }
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }
        }
    }
    public bool Add(ItemClass item, int quantity)
    {
        //items.Add(item);

        SlotClass slot = Contains(item);
        if(slot != null && slot.GetItem().isStackable)
        {
            slot.AddQuantity(1);
        }
        else{
            for(int i = 0; i< items.Length; i++)
            {
                if(items[i].GetItem() == null) //this is empty slot
                {
                    items[i].AddItem(item, quantity);
                    break;
                } 
            }
        }

        RefreshUI();
        return true;
    }
    
    public bool Remove(ItemClass item)
    {
        SlotClass temp = Contains(item);
        if(temp != null)
        {
            if(temp.GetQuantity() > 1)
            temp.SubQuantity(1);
        
            else
            {
                int slotToRemoveIndex = 0;


                for(int i = 0; i < items.Length; i++)
                {
                    if(items[i].GetItem() == item)
                    {
                        slotToRemoveIndex =i;
                        break;
                    }
                }
                items[slotToRemoveIndex].Clear();
            }
        }
        else
        {
            return false;
        }
        
        RefreshUI();
        return true;
    }
    
    public SlotClass Contains(ItemClass item)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i].GetItem() == item)
            {
                return items[i];
            }
        }
        return null;
    }
    #endregion Inventory Utils

    #region Moving Stuff
    
    private bool BeginItemMove()
    {
        originalSlot = GetClosestSlot();

        if(originalSlot == null || originalSlot.GetItem() == null)
        {
            
            return false; //there is not item to move!
        }

        

        movingSlot = new SlotClass(originalSlot);
        originalSlot.Clear();
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool EndItemMove()
    {
        originalSlot = GetClosestSlot();
        if(originalSlot == null)
        {
            Add(movingSlot.GetItem(), movingSlot.GetQuantity());
            movingSlot.Clear();
        }
        else
        {
            if(originalSlot.GetItem() != null)
            {
                if(originalSlot.GetItem() == movingSlot.GetItem())//they are the same items
                {
                    if(originalSlot.GetItem().isStackable)
                    {
                        originalSlot.AddQuantity(movingSlot.GetQuantity());
                        movingSlot.Clear();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    tempSlot = new SlotClass(originalSlot);
                    originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity());
                    movingSlot.AddItem(tempSlot.GetItem(), tempSlot.GetQuantity());

                    RefreshUI();
                    return true;
                }
            }
            else // place tem as usual
            {
                originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity());
                movingSlot.Clear();
            }
            
            
        }
        isMovingItem = false;
        RefreshUI();
        return true;
        
    }
    private SlotClass GetClosestSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            // Преобразуваме позицията на слота в екранни координати
            Vector2 slotScreenPos = RectTransformUtility.WorldToScreenPoint(null, slots[i].GetComponent<RectTransform>().position);
            
           

            // Проверка дали мишката е достатъчно близо до слота
            if (Vector2.Distance(slotScreenPos, Input.mousePosition) <= 32)
            {
                
                return items[i];
            }
        }
        
        return null;
    }


    #endregion
}
