using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthEnemy : MonoBehaviour
{
    
    public int maxHealth = 100;
    public int currentHealth;
     Animator animator;
     Collider2D collider;
    bool m_died = false;
    public UltimateStatusBar healthBar;
   

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        currentHealth = maxHealth;
        
        
    }
    public void TakeDamage(int dam)
    {
        if (animator.GetBool("isWakeup") == false)
        {
            return;
        }
        currentHealth -= dam;
        healthBar.UpdateStatus(currentHealth,maxHealth);
        if (currentHealth < 0)
        {
            Die();
        }

    }
    void Die()
    {
        if (m_died == false)
        {
            
            
            int rand = Random.Range(0,4);
            if (rand==0)
            {
                GameObject Item_FullHealing = (GameObject)Resources.Load("Prefab/Item/Item_FullHealing");
                Instantiate(Item_FullHealing,transform.position,Quaternion.identity);
            }
            else if (rand == 1)
            {
                GameObject Item_HalfHealing = (GameObject)Resources.Load("Prefab/Item/Item_HalfHealing");
                Instantiate(Item_HalfHealing, transform.position, Quaternion.identity);
            }
            m_died = true;
            animator.SetBool("isWakeup", false);
            animator.SetTrigger("died");

            collider.isTrigger = true;
            Destroy(gameObject, 1);
        }
        
    }
   
   public bool IsDied()
    {
        return m_died;
    }
    
    
}
