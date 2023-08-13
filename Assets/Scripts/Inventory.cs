using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int SnakeCount;

    void Start()
    {
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
