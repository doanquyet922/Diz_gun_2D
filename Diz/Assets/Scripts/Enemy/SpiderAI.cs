using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    public Animator animator;
    //public GameObject playerCus;
    public float agroRange = 0f;
    public float minRange = 0f;

    public float moveSpeed = 0f;
    public float maxMove = 0f;
    public float minMove = 0f;
    public bool firstFaceRight = true;
    //làm phiền
    public bool bother = false;
    Transform player;
    Rigidbody2D rb;
    HealthEnemy he;
    Shooting sh;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        he = gameObject.GetComponentInParent<HealthEnemy>();
        sh = gameObject.GetComponentInChildren<Shooting>();
        //player = playerCus.GetComponentInParent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<HealthPlayer>().gameObject.transform;
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange && distToPlayer > minRange && he.IsDied() == false)
        {

            if (animator.GetBool("isWakeup") == false)
            {
                animator.SetBool("isWakeup", true);
            }
            if (sh.m_position_lock == false)
            {
                if (firstFaceRight == true)
                {
                    ChasePlayerFaceRight();
                }
                else
                {
                    ChasePlayerFaceLeft();
                }
               
            }
            sh.SetShooting(true);
        }
        else
        {
            animator.SetBool("isWakeup", false);
            StopChasingPlayer();
            sh.SetShooting(false);
        }
    }

    private void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0, 0);
    }

    private void ChasePlayerFaceLeft()
    {
        if (transform.position.x < player.position.x)
        {
            //if (sh.GetShooted() == true) return;

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, minMove, maxMove), transform.position.y);
            rb.velocity = new Vector2(moveSpeed, 0);
            if (transform.localScale.x > 0)
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
           
        }
        else
        {


            //if (sh.GetShooted() == true) return;
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, minMove, maxMove), transform.position.y);
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }
    private void ChasePlayerFaceRight()
    {
        if (transform.position.x < player.position.x)
        {
            //if (sh.GetShooted() == true) return;

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, minMove, maxMove), transform.position.y);
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
        {


            //if (sh.GetShooted() == true) return;
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, minMove, maxMove), transform.position.y);
            rb.velocity = new Vector2(-moveSpeed, 0);
            if (transform.localScale.x > 0)
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    public void AnimationShoot()
    {
        sh.AnimationShoot();
    }
}
