using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int SnakeCount;
    public Dictionary<string, int> realInventory = new Dictionary<string, int>();

    void Start()
    {
        realInventory.Add("snake", 0);
        realInventory.Add("rat", 0);
    }

    void Update()
    {
    }
    
    public void AddSnake() { AddItem(InventoryItem.InventoryKind.SnakeItem, 1); }
    public void RemoveSnake() { RemoveItem(InventoryItem.InventoryKind.SnakeItem, 1); }
    
    public void AddItem(InventoryItem.InventoryKind kind, int count)
    {
        if (kind == InventoryItem.InventoryKind.SnakeItem)
        {
            SnakeCount += count;
        }
    }
        
    
    public void RemoveItem(InventoryItem.InventoryKind kind, int count)
    {
        if (kind == InventoryItem.InventoryKind.SnakeItem)
        {
            SnakeCount -= count;
            
            if (SnakeCount < 0)
            {
                Debug.LogWarning($"Invalid SnakeCount {SnakeCount}");
            }
        }
    }
    
    public int ItemCount(InventoryItem.InventoryKind kind) 
    {
        if (kind == InventoryItem.InventoryKind.SnakeItem)
        {
            return SnakeCount;
        }
        
        return 0;
    }
    
}
