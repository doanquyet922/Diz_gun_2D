using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    Rigidbody2D rb;
    GameObject player;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<HealthPlayer>().gameObject;
        Transform childPlayer = player.transform.GetChild(0);
        moveDirection = (childPlayer.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x,moveDirection.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
