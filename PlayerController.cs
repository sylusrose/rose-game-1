using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 4f;
    float rotSpeed = 80f;
    float rot = 0f;
    float gravity = 8;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("param_idletorunning", true);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("param_idletorunning", false);
                moveDir = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.K))
            {
                anim.SetBool("param_idletojump", true);
            }

            if (Input.GetKeyUp(KeyCode.K))
            {
                anim.SetBool("param_idletojump", false);
                moveDir = new Vector3(0, 0, 0);
            }

           
            if (Input.GetKey(KeyCode.J))
            {
                anim.SetBool("param_idletohit03", true);
            }

            if (Input.GetKeyUp(KeyCode.J))
            {
                anim.SetBool("param_idletohit03", false);
                moveDir = new Vector3(0, 0, 0);
            }

        }
        rot += Input.GetAxisRaw("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
        
    }
}
