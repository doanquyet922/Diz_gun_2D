using System;
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

    public int layerPlayer;
    public int layerGrounding;
    public int layerCeilling;

    Transform myGround;
    
    private void Awake()
    {
        
        
        Physics2D.IgnoreLayerCollision(this.layerPlayer, this.layerCeilling, true);

        //cameraFollow.SetTarget(transform);
        //cameraFollow.SetPhotonView(photonView);
        //if (photonView.isMine)
        //{
        playerCamera.SetActive(true);
        
        //}
        
    }
   
    void Update()
    {

        this.GroundFinding();

        //if (photonView.isMine)
        {
            //PhotonView.RPC("CheckInput", PhotonTargets.All);
            CheckInput();
        }
    }

    private void GroundFinding()
    {
        Vector3 direction = Vector3.down;
        Vector3 position = this.transform.position;
        //Physics.Raycast(position,direction,out RaycastHit hit);
        RaycastHit2D hit = Physics2D.Raycast(position, direction);
        if (hit.transform == null || hit.transform.gameObject.layer==10) return;
        Ground ground = hit.transform.GetComponent<Ground>();
        if (ground == null) return;
        if (this.myGround == hit.transform && hit.transform.gameObject.layer != layerCeilling) return;
        
        ground.Changelayer(this.layerGrounding);
        this.myGround = hit.transform;
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer==layerGrounding) {
            collision.gameObject.layer = layerCeilling;
        }
    }
}
