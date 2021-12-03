using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour
{
    public static MoveInput ins;
    float click = 0f;
    bool crouch = false;
    bool Jump = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Ins();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Ins()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
    public void MoveRightDown()
    {
        click = 1;
    }
    public void MoveLeftDown()
    {
        click = -1;
    }
    public void MoveUpRightOrLeft()
    {
        click = 0;
    }
    public float GetHozirontal()
    {
        return click;
    }
    public void CrouchDown()
    {
        crouch=true;
    }
    public void CrouchUp()
    {
        crouch = false;
    }
    public bool GetCrouch()
    {
        return crouch;
    }
    public void JumpDown()
    {
        Jump = true;
    }
    public void JumpUp()
    {
        Jump = false;
    }
    public bool GetJump()
    {
        return Jump;
    }
}
