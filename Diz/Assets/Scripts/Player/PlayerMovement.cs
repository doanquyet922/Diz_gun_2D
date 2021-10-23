using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch=false;

    //public PhotonView photonView;
    //public Rigidbody2D rb;
    public GameObject playerCamera;
    //public SpriteRenderer sr;
    public Text playerNameText;

    

    
    private void Awake()
    {


        //cameraFollow.SetTarget(transform);
        //cameraFollow.SetPhotonView(photonView);
        //if (photonView.isMine)
        //{
        playerCamera.SetActive(true);
        
        //}
        
    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        

        //if (photonView.isMine)
        {
            //PhotonView.RPC("CheckInput", PhotonTargets.All);
            CheckInput();
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
    //[PunRPC]
    void CheckInput()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Horizontal"))
        {
            animator.SetBool("Run", true);
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("Run", false);
        }


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            
            crouch = true;

        }
        else if (Input.GetButtonUp("Crouch"))
        {

            crouch = false;

        }
        //Debug.Log("Crouch" + crouch);
    }
    // kiểm  tra chạm đất thì dừng nhảy
    public void OnLanding()
    {
        
        animator.SetBool("Jump", false);
    }
    public void OnCrouching(bool Crouch)
    {
        
        animator.SetBool("Crouch", Crouch);
    }
    public void moveRightDown()
    {
        horizontalMove= runSpeed;
        animator.SetBool("Run", true);
        var scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
    public void moveRightUp()
    {
        horizontalMove = 0;
        animator.SetBool("Run", false);
    }
    public void moveLeftDown()
    {
        horizontalMove= -runSpeed;
        animator.SetBool("Run", true);
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale= scale;
        
    }
    public void movelefttUp()
    {
        horizontalMove = 0;
        animator.SetBool("Run", false);
    }
    public void ClickJump()
    {
        jump = true;
        animator.SetBool("Jump", true);
    }
}
