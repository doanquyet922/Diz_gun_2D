using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float timeShoot = 2f;
   
    bool m_shooting = false;
    bool m_shooted = false;
   public bool m_position_lock = false;
    public Animator animator;
    HealthEnemy he;
    GameObject childBullet;
    [SerializeField]
    bool typeShoot1 = false;
    [SerializeField]
    bool typeShoot2 = false;
    [SerializeField]
    bool attack1= false;
    [SerializeField]
    bool attack2 = false;
    //Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        he = GetComponentInParent<HealthEnemy>();
        //rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (typeShoot1==true && attack1==true)
        {
            if (m_shooting == true && m_shooted == false && he.IsDied() == false)
            {
                StartCoroutine(Shoot());
            }
        }
        if (typeShoot2 == true && attack1 == true)
        {
            if (m_shooting == true && m_shooted == false && he.IsDied() == false)
            {
                animator.SetTrigger("attack1");
            }
        }
        if (typeShoot2 == true && attack2 == true)
        {
            if (m_shooting == true && m_shooted == false && he.IsDied() == false)
            {
                animator.SetTrigger("attack2");
            }
            //if (timeUnitFire < Time.time && m_shooting == true && he.IsDied() == false)
            //{
            //    animator.SetTrigger("attack2");
            //}
        }



    }
    public void AnimationShoot()
    {
        StartCoroutine(Shoot2());
    }
    
    IEnumerator Shoot()
    {
        m_shooted = true;
        m_position_lock = true;
        animator.SetTrigger("attack1");
        GameObject bullet1 = Instantiate(bullet, this.transform, true);
        bullet1.transform.position = gameObject.transform.position;
        bullet1.transform.localScale = gameObject.transform.localScale;
        bullet1.transform.rotation = gameObject.transform.rotation;
        
        yield return new WaitForSeconds(timeShoot);
       
        Destroy(bullet1);
        yield return new WaitForSeconds(1);
        m_position_lock = false;
        yield return new WaitForSeconds(1);
        m_shooted = false;
       
        


    }
    IEnumerator Shoot2()
    {
        
        m_shooted = true;
        m_position_lock = true;
        
        GameObject bullet1 = Instantiate(bullet, this.transform, true);
        bullet1.transform.position = gameObject.transform.position;
        bullet1.transform.localScale = gameObject.transform.localScale;
        //bullet1.transform.rotation = gameObject.transform.rotation;

        yield return new WaitForSeconds(timeShoot);

        Destroy(bullet1);
        yield return new WaitForSeconds(1);
        m_position_lock = false;
        yield return new WaitForSeconds(1);
        m_shooted = false;




    }
    public void SetShooting(bool isShoot)
    {
        m_shooting = isShoot;
    }
    public GameObject GetLaze()
    {
        return childBullet;
    }
}
