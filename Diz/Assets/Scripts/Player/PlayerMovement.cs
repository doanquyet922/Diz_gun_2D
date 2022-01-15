using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : Photon.MonoBehaviour
{
    
    public CharacterController2D controller;
    public float runSpeed = 40f;
     Animator animator;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch=false;

    
    //public Rigidbody2D rb;
    public GameObject playerCamera;
    //public SpriteRenderer sr;
    public Text playerNameText;

    public int layerPlayer;
    public int layerGrounding;
    public int layerCeilling;

    Transform myGround;
    public PhotonView photonView;
    GameObject playerCus;
    
    private void Awake()
    {
        
        if (gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.GetActive() == true)
        {
            playerCus = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;
        }
        else
        {
            if (gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject.GetActive() == true)
            {
                playerCus = gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject;
            }
        }
        animator = playerCus.GetComponentInChildren<Animator>();
        photonView = GetComponent<PhotonView>();
        Physics2D.IgnoreLayerCollision(this.layerPlayer, this.layerCeilling, true);

        //cameraFollow.SetTarget(transform);
        //cameraFollow.SetPhotonView(photonView);
        //if (photonView.isMine)
        {
            playerCamera.SetActive(true);
        Collider2D collider2D = GameObject.FindGameObjectWithTag("BoundMap").GetComponent<Collider2D>();
        Cinemachine.CinemachineConfiner cinemachineConfiner = playerCamera.GetComponent<Cinemachine.CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = collider2D;
        }

    }
   
    void Update()
    {
        if (gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.GetActive() == true)
        {
            playerCus = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;
        }
        else
        {
            if (gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject.GetActive() == true)
            {
                playerCus = gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject;
            }
        }
        animator = playerCus.GetComponentInChildren<Animator>();
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
        //Debug.Log("layer: "+hit.transform.gameObject.layer);
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
    [PunRPC]
    void CheckInput()
    {
        if (gameObject.GetComponent<HealthPlayer>().isDied == false)
        {
            horizontalMove = MoveInput.ins.GetHozirontal() * runSpeed;
            if (MoveInput.ins.GetHozirontal() == 1)
            {
                if (animator)
                    animator.SetBool("Run", true);
                var scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            if (MoveInput.ins.GetHozirontal() == -1)
            {
                if (animator)
                    animator.SetBool("Run", true);
                var scale = transform.localScale;
                if (scale.x >= 0)
                    scale.x *= -1;
                transform.localScale = scale;
            }
            if (MoveInput.ins.GetHozirontal() == 0)
            {
                if(animator)
                animator.SetBool("Run", false);
            }
            if (MoveInput.ins.GetJump())
            {
                jump = true;
                animator.SetBool("Jump", true);
            }
            if (MoveInput.ins.GetCrouch())
            {
                crouch = true;
            }
            else
            {
                crouch = false;
            }
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                if (horizontalMove == 0)
                {
                    if (animator)
                        animator.SetBool("Run", false);
                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    if (animator)
                        animator.SetBool("Run", true);
                    var scale = transform.localScale;
                    scale.x = Mathf.Abs(scale.x);
                    transform.localScale = scale;
                }
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    if (animator)
                        animator.SetBool("Run", true);
                    var scale = transform.localScale;
                    if (scale.x >= 0)
                        scale.x *= -1;
                    transform.localScale = scale;
                }

            }

            
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                if (animator)
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
        }
        //Debug.Log("Crouch" + crouch);
    }
    // kiểm  tra chạm đất thì dừng nhảy
    public void OnLanding()
    {
        if (animator)
            animator.SetBool("Jump", false);
    }
    public void OnCrouching(bool Crouch)
    {
        if (animator)
            animator.SetBool("Crouch", Crouch);
    
   
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer==layerGrounding) {
            collision.gameObject.layer = layerCeilling;
        }
    }
}
