using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    Animator animator;
    private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("jump",false);
        
        if (Input.GetKey(KeyCode.UpArrow) && canJump){
            canJump = false;
            animator.SetBool("jump",true);
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            canJump = true;
        }
    }
}
