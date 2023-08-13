using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public TMPro.TMP_Text SnakeCounter;
    public Inventory inventory;
    public CannonControl snakeCannon;
    
    // Garden // grow / sell / notify on damage
    
    void Start()
    {
        // snakeCannon.Launched += OnCannonLaunchSnake;
    }

    void Update()
    {
        UpdateSnakeCounter();
    }
    
    void UpdateSnakeCounter()
    {
        SnakeCounter.text = $"Snakes: {inventory.SnakeCount}";
    }
    
    void OnCannonLaunchSnake()
    {
        
    }
}
