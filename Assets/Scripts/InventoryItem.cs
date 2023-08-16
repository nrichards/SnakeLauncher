using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem 
{

    public enum InventoryKind {
        None,
        SnakeItem,
        RatItem,
        CornItem
    }
    
    public InventoryKind inventoryKind; 
}
