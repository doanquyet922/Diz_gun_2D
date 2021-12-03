using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDie()
    {
        Debug.Log("Set Die");
        int ranDie = Random.Range(0, 1);
        animator = GetComponentInChildren<Animator>();
        if (animator!=null)
        {
            if (ranDie == 0)
            {

                animator.SetBool("DieBack", true);
            }
            else if (ranDie == 1)
            {
                animator.SetBool("DieFront", true);
            }
        }
        
    }
}
