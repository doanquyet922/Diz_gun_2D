using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    Animator animator;
    public int dameEnemyLaze;
    public int dameEnemybullet;
   
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerCus = transform.Find("PlayerCus").gameObject;
        animator = playerCus.GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void TakeDamage(int dame)
    {
        currentHealth -= dame;
        UltimateStatusBar.UpdateStatus("HealthPlayer", "Health", currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        int ranDie = Random.Range(0, 1);
        if(ranDie == 0)
        {
            animator.SetBool("DieBack", true);
        }else if (ranDie == 1)
        {
            animator.SetBool("DieFront", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LazeBullet"))
        {
            TakeDamage(dameEnemyLaze);
        }
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(dameEnemybullet);
            Destroy(collision.gameObject);
        }
    }
    
}
