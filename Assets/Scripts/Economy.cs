using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    /*
    
    - [ ] Rat production - currently is infinite, turn it down. Use waves. Each wave, rats are stronger.
    - [ ] Rat evolution, the more corn they eat, the longer it lives. The less, the shorter.
    - [ ] Snake production, how many can I afford? 
    - [ ] Snake genetic evolution, the more rats it eats, the stronger it gets. The less, the weaker.
    - [ ] Corn production
    - [ ] Corn consumption
    - [ ] Corn destruction
    - [ ] Get money from corn consumption - aka selling
    - [ ] Get fatter snakes from killing rats

    */
    
    public int BankAccountBalance;
    public float RatStrength;
    public float SnakeStrength;
    public float CornProductionRate;
    
    
    
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
