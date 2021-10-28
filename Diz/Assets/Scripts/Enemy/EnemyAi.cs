using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
     GameObject player;
    public float agroRange = 0f;
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        he = GetComponent<HealthEnemy>();
        player = GameManager.ins.parentPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (onMove == true)
        {
            Move();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer < agroRange && he.IsDied() == false)
        {
           
            
            if (timeUnitFire < Time.time)
            {
                Shoot();
            }

            
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
            rb.velocity = Vector2.right * -moveSpeed;
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
        GameObject bullet= Instantiate(bulletPrefab, this.FirePoint.position, this.FirePoint.rotation);
        Destroy(bullet,2);
        
    }
}
