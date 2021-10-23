using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCheck : MonoBehaviour
{
    public Animator animator;
    bool m_insideCol = false;
    float m_TimeInsideCol = 0f;
    public GameObject golem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_insideCol == true && m_TimeInsideCol==0f)
        {
            if (animator.GetBool("isWakeup") == false)
            {
                animator.SetBool("isWakeup", true);
            }
            var scale = golem.transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            Debug.Log(scale);
            golem.transform.localScale = scale;
            m_TimeInsideCol++;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            m_insideCol = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_TimeInsideCol = 0f;
    }
}
