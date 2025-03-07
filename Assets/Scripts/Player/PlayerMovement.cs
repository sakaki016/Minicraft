using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    //移動速度、ジャンプ力、重力
    public float speed = 7.0f;
    public float jumpSpeed = 5.5f;
    public float gravity = 15.0f;

    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Playerの移動
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection.z = z * speed;
            moveDirection.x = x * speed;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        if (!controller.isGrounded)
        {
            moveDirection.z = z * speed / 1.5f;
            moveDirection.x = x * speed / 1.5f;
            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
