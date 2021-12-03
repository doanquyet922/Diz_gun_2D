using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{

    public bool FullHeal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (FullHeal == true) GameManager.ins.CountingFullHeal();
            else GameManager.ins.CountingHalfHeal();
            Destroy(gameObject);
        }
    }
}
