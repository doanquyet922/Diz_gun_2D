using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomPlayer : MonoBehaviour
{
    Camera cam;
    //public int boom = 0;
    public GameObject ballprefab;
    GameObject m_ball_obj;
    Ball ball;
    public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    
    FixedJoystick fixedJoystick;
    BoomUI boomUI;
    //---------------------------------------
    void Start()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        boomUI = FindObjectOfType<BoomUI>();
        cam = Camera.main;
        //GameManager.ins.SetBoom(boom);
        //ball.DesactivateRb();
    }

    void Update()
    {
       
        //Debug.Log(fixedJoystick.Direction);
        if (boomUI.useBoom == true && boomUI.m_CurrentTimeBoom<=0 && Prefs.boom>0)
        {
            

            
            //Debug.Log("click:"+fixedJoystick.drag);
            if (fixedJoystick.pointertDown==true)
            {

                if (m_ball_obj == null)
                {
                    m_ball_obj = Instantiate(ballprefab, trajectory.transform.position, Quaternion.identity);
                    m_ball_obj.transform.parent = gameObject.transform;
                    ball = m_ball_obj.GetComponent<Ball>();
                    isDragging = true;
                    OnDragStart();
                }
                
                

            }
            if(fixedJoystick.pointertUp==true && isDragging==true)
            {
                boomUI.ReduceTime();
                isDragging = false;
                OnDragEnd();
                

            }
        }


        if (isDragging)
        {
            OnDrag();
        }
    }

    //-Drag--------------------------------------
    void OnDragStart()
    {
        ball.DesactivateRb();
        startPoint = (Vector2.zero);

        trajectory.Show();
    }

    void OnDrag()
    {
        
        endPoint = (fixedJoystick.Direction);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        //just for debug
        Debug.DrawLine(startPoint, endPoint);


        trajectory.UpdateDots(ball.pos, force);
    }
    //public void AddBoom()
    //{
    //    boom++;
    //    //GameManager.ins.SetBoom(boom);
    //}
    void OnDragEnd()
    {
        //push the ball
        ball.ActivateRb();
        ball.Push(force);
        //boom--;
        //GameManager.ins.SetBoom(boom);

        m_ball_obj.transform.parent = null;
        Destroy(m_ball_obj,2f);
        trajectory.Hide();
    }
}
