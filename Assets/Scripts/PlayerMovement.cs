using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    private float speed = 6f;
    //For rotation
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    //For Gravity & Jumping
    private float gravity = 9.8f;
    private float jumpSpeed = 3f;
    private float vSpeed = 0f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) //If moving --> rotate to direction of movement
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        //Jump
        if (controller.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetButtonDown("Jump"))
            {
                vSpeed = jumpSpeed;
            }
        }
        vSpeed -= gravity * Time.deltaTime;
        direction.y = vSpeed;

        //Move Player
        controller.Move(direction * speed * Time.deltaTime);
    }
}
