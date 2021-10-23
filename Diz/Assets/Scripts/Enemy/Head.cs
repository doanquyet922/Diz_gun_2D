using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    HealthEnemy he;
    // Start is called before the first frame update
    void Start()
    {
        he = gameObject.GetComponentInParent<HealthEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       foreach(Bullets b in GameManager.ins.bullets){

            if (collision.collider.name.Contains(b.NameBullet))
            {
                he.TakeDamage(b.Dame*2);
            }
        }
    }
}
