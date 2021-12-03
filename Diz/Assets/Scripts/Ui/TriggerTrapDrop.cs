using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrapDrop : MonoBehaviour
{
    Animator animator;
    bool drop = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (drop == false)
            {
                
                animator.SetTrigger("Drop");
                drop = true;
            }
            
        }
    }
}
