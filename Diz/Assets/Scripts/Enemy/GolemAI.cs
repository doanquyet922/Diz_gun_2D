using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAI : MonoBehaviour
{
    
    public Animator animator;
    //public GameObject playerCus;
    public float agroRange=0f;
    public float moveSpeed=0f;
    public float maxMove=0f;
    public float minMove=0f;
    public Shooting shooting;
    Transform player;
     Rigidbody2D rb;
    HealthEnemy he;
    Shooting sh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.ins.parentPlayer.transform;
        rb = GetComponent<Rigidbody2D>();
        he = gameObject.GetComponentInParent<HealthEnemy>();
        sh = gameObject.GetComponentInChildren<Shooting>();
        //player = playerCus.GetComponentInParent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distToPlayer < agroRange && distToPlayer> 1.6f && he.IsDied()==false )
        {
            
            if (animator.GetBool("isWakeup") == false)
            {
                animator.SetBool("isWakeup", true);
            }
            GameObject laze = sh.GetLaze();
            if (sh.m_position_lock==false)
            {
                ChasePlayer();
            }
            
            shooting.SetShooting(true) ;
        }
        else
        {
           
            StopChasingPlayer();
            if(distToPlayer > agroRange)
            {
                StartCoroutine(SetSleep());
                shooting.SetShooting(false);
            }
            


        }
    }

    private void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0,0);
    }

    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //if (sh.GetShooted() == true) return;
           
            transform.position = new Vector2(Mathf.Clamp(transform.position.x,minMove,maxMove), transform.position.y);
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale=new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else 
        {
            

            //if (sh.GetShooted() == true) return;
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, minMove, maxMove), transform.position.y);
            rb.velocity = new Vector2(-moveSpeed, 0);
            if(transform.localScale.x>0)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    IEnumerator SetSleep()
    {
        yield return new WaitForSeconds(3);
        if (animator.GetBool("isWakeup") == true)
        {
            animator.SetBool("isWakeup", false);
        }
    }
    //public void SetPlayer(Transform player1)
    //{
    //    player = player1;
    //}
   
}
