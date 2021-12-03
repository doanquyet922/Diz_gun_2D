using Assets.HeroEditor.Common.CharacterScripts;
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
    
    GameObject playerCus;
    public bool isDied = false;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.GetActive() == true)
        {
            playerCus = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;
        }
        else
        {
            if (gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject.GetActive() == true)
            {
                playerCus = gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject;
            }
        }
        

        //GameObject playerCus = transform.Find("PlayerCus").gameObject;
        animator = playerCus.GetComponentInChildren<Animator>();

        currentHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.GetActive() == true)
        {
            playerCus = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;
        }
        else
        {
            if (gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject.GetActive() == true)
            {
                playerCus = gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject;
            }
        }
        animator = playerCus.GetComponentInChildren<Animator>();
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
    public void AddHeal(int percentHealing)
    {
        int heal = (int)( maxHealth * (percentHealing/100.0));
        //Debug.Log("pre:"+percentHealing+"-Heal:" +heal);
        currentHealth =currentHealth+ heal;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UltimateStatusBar.UpdateStatus("HealthPlayer", "Health", currentHealth, maxHealth);
    }
   public void Die()
    {
        isDied = true;
        int ranDie = Random.Range(0, 1);
        if (ranDie == 0)
        {

            animator.SetBool("DieBack", true);
        }
        else if (ranDie == 1)
        {
            animator.SetBool("DieFront", true);
        }
        GameManager.ins.ShowGameOver();
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
        if (collision.CompareTag("DeadZone"))
        {
            Die();
        }
    }
    
}
