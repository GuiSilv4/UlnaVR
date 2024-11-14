using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Capacity = 20; // Limite de itens que o inventário pode conter
    private List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (items.Count >= Capacity)
        {
            Debug.Log("Inventário cheio!");
            return false;
        }
        items.Add(item);
        return true;
    }

    public bool RemoveItem(Item item)
    {
        return items.Remove(item);
    }

    public void DisplayInventory()
    {
        foreach (Item item in items)
        {
            Debug.Log("Item: " + item.ItemName);
        }
    }

    public List<Item> GetItems()
    {
        return items;
    }
}
