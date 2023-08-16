using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public TMPro.TMP_Text SnakeCounter;
    public Inventory inventory;
    public CannonControl snakeCannon;
    public float AddSnakeTime = 5f;
    
    public float snakeGrowTimer;
    private IEnumerator countup;
    private int waitCounter;
    
    // Garden // grow / sell / notify on damage
    
    void Start()
    {
        // snakeCannon.Launched += OnCannonLaunchSnake;
        StartCoroutine(countup = Countup());
        snakeGrowTimer = waitCounter;
    }

    private IEnumerator Countup() {
        while(true) {
            yield return new WaitForSeconds(1);
            waitCounter += 1;
        }
    }
    
    void Update()
    {
        UpdateSnakeCounter();
        
        if ((waitCounter - snakeGrowTimer) > AddSnakeTime)
        {
            AddMoreSnake();
            snakeGrowTimer = waitCounter;
        }
    }
    
    void UpdateSnakeCounter()
    {
        SnakeCounter.text = $"Snakes: {inventory.SnakeCount}";
    }
    
    void OnCannonLaunchSnake()
    {
        
    }
    
    void AddMoreSnake()
    {
        inventory.AddSnake();
    }
}
