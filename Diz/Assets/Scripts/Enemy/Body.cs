using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    HealthEnemy he;

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
        foreach (Bullets b in GameManager.ins.bullets)
        {

            if (collision.collider.name.Contains(b.NameBullet))
            {
                Debug.Log("Body - "+b.NameBullet + "-" + b.Dame);
                he.TakeDamage(b.Dame);
            }
        }
    }
}
