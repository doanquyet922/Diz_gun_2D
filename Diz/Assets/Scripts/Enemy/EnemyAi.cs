using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public bool shoot = true;
    public int dameAttackIfShootFalse = 20;
     Transform player;
    public float agroRange = 1f;
    public float agroMouthAndPlayer = 1f;
    
    HealthEnemy he;

    public float minMove;
    public float maxMove;
    public float moveSpeed;
    
    public bool onMove;
    bool faceRight = false;

    Rigidbody2D rb;

    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    float timeUnitFire;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        he = GetComponent<HealthEnemy>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<HealthPlayer>().gameObject.transform;
        if (onMove == true)
        {  
            Move();
            
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run",false);

            rb.velocity = Vector2.zero;
        }
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        float chechlechdocao = player.position.y - transform.position.y;
        if (distToPlayer < agroRange && he.IsDied()==false)
        {


            if (timeUnitFire < Time.time)
            {
                if (shoot == true)
                {
                    Shoot();
                }
                else
                {
                    Attack();
                }

            }
            else onMove = true;

            
        }
        //if (timeUnitFire < Time.time && m_CheckShoot == true)
        //{
        //    this.StartCoroutine(Shoot());
        //}
    }
    void Move()
    {
        if (faceRight == true)
        {

            rb.velocity = Vector2.right * moveSpeed;
            
            if (transform.localScale.x > 0)
            {
                faceRight = false;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
           

        }
        else
        {
            rb.velocity = Vector2.right * - moveSpeed;
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        if (transform.position.x > maxMove)
        {
            faceRight = false;
        }
        else if (transform.position.x < minMove)
        {
            faceRight = true;
        }
    }
    private void Shoot()
    {
        timeUnitFire = Time.time + fireRate;
        if (transform.GetChild(0).position.x < player.position.x)
        {
            faceRight = true;
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }

            

        }
        else
        {
            faceRight = false;
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);

        }
        GameObject bullet= Instantiate(bulletPrefab, this.FirePoint.position, this.FirePoint.rotation);
        Destroy(bullet,2);
        
    }
    void Attack()
    {
        Vector3 presentPos = gameObject.transform.position;
        onMove = false;
        timeUnitFire = Time.time + fireRate;
        if (transform.GetChild(0).position.x < player.position.x)
        {
            faceRight = true;
            if (transform.localScale.x > 0)
            {
                
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }

            gameObject.transform.position = (player.position);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - agroMouthAndPlayer, presentPos.y, gameObject.transform.position.z);

        }
        else
        {
            faceRight = false;
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);

            gameObject.transform.position = (player.position);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + agroMouthAndPlayer, presentPos.y, gameObject.transform.position.z);
            
        }
        animator.SetTrigger("attack");
        
        HealthPlayer healthPlayer = player.GetComponent<HealthPlayer>();
        healthPlayer.TakeDamage(dameAttackIfShootFalse);
        StartCoroutine(BackPos(presentPos));
    }
    IEnumerator BackPos(Vector3 Pos)
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = Pos;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, agroRange);
        Gizmos.DrawWireSphere(transform.position, agroMouthAndPlayer);
        

    }
}
