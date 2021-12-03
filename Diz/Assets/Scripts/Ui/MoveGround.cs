using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public GameObject[] point;
    int currentPoint = 0;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(point[currentPoint].transform.position, transform.position) < 0.1f)
        {
            currentPoint++;
        }
        if (currentPoint >= point.Length)
        {
            currentPoint = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position,point[currentPoint].transform.position,Time.deltaTime*speed);
    }
}
