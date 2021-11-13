using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Joystick joystick;
    public PhotonView pView;

    private Vector3 velocity;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [SerializeField] private float gravity;

    
    // Update is called once per frame
    void Update()
    {
        if (pView.IsMine)
        {
            Move();
        }
    }

    private void Move()
    {       

        //Y-Axis
        float horizontal = joystick.Horizontal;
       
        //Z-Axis
        float vertical = joystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        if (direction.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        }

        //Calculate Gravity
        velocity.y += gravity * Time.deltaTime;
        //Apply gravity
        controller.Move(velocity * Time.deltaTime);
    }
}

