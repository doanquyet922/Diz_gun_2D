using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioSource aus;
    // Start is called before the first frame update
    void Start()
    {
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.ins.CounttingCoin();
            AudioSource.PlayClipAtPoint(aus.clip, gameObject.transform.position, 1f);
            //aus.PlayOneShot(aus.clip);
            Destroy(gameObject);

        }
    }
}
