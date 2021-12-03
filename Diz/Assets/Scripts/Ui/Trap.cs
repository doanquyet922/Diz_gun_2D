using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    
    Rigidbody2D rb;
    bool droptrap = false;
    public float speed = 2f;
    
    bool check = false;
    private void Start()
    {
        rb = gameObject.transform.parent.GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthPlayer healthPlayer = collision.gameObject.GetComponent<HealthPlayer>();
            healthPlayer.Die();
        }
        
    }
    public void DropTrap()
    {
        //    droptrap = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        //Debug.Log("Trap drop:" + droptrap);
        
    }
}
