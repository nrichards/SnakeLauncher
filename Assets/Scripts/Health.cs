using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Health : MonoBehaviour
{
    public TextMeshPro HealthLabel;
    public float Value = 100f;
    public string Prefix = "h";
    public string EnemyTag = "Enemy";
    public float DamageOverTime = 0.01f;
    public ParticleSystem deathParticle;
    public ParticleSystem damageParticle;
    
    Vector2 headPosition;
    bool Dying = false;
    List<Collision2D> collisionInfos = new List<Collision2D>();
    
    void Start()
    {
        if (deathParticle != null)
        {
            var main = deathParticle.main;
            main.stopAction = ParticleSystemStopAction.Callback;
        }
    }

    void Update()
    {
        UpdateHealthLabel();
        
        if (Value <= 0f)
        {
            OnDie();
        }
    }
    
    void UpdateHealthLabel()
    {
        if (HealthLabel != null) 
        {
            HealthLabel.text = $"{Prefix}: {Value}";
        }
    }
    
    void OnDie()
    {
        if (!Dying )
        {
            Dying = true;
            if (deathParticle != null)
            {
                deathParticle.Play();
            }
            else
            {
                OnParticleSystemStoppedFromChild();
            }
        }
    }
    
    void FixedUpdate()
    {
        if (collisionInfos.Count > 0)
        {
            foreach (Collision2D ci in collisionInfos)
            {
                OnCollisionEnter2D(ci);
            }
            
            collisionInfos.RemoveRange(0, collisionInfos.Count);
        }
    }
    
    public void OnCollisionEnter2DFromChild(Collision2D collisionInfo, Transform child)
    {
        collisionInfos.Add(collisionInfo);
    }
    
    protected void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == EnemyTag) 
        {
            // TakeDamage
            Value -= DamageOverTime;
            if (damageParticle)
            {
                DoBurst(damageParticle);
            }
        }
    }
    
    void DoEmit(ParticleSystem ps)
    {
        // NOTE: Unused
        //
        
        
        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the start color and size.
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = Color.red;
        emitParams.startSize = 0.2f;
        ps.Emit(emitParams, 10);
        ps.Play(); // Continue normal emissions
    }
    
    void DoBurst(ParticleSystem ps)
    {
        var em = ps.emission;
        em.enabled = true;
        em.rateOverTime = 0;
        em.SetBursts(
            new ParticleSystem.Burst[]
            {
                new ParticleSystem.Burst(0.0f, 1),
            });
            
        ps.Play();
    }

    public void OnParticleSystemStoppedFromChild()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 0.1f);
    }
}
