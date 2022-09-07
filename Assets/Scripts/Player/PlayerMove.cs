using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6f;
    Vector3 Movement;

    Animator anim;
    Rigidbody PlayerRigidBody;
    
    float currentX, currentY;
    public Quaternion rotation;

    Vector3 direction;

    void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerRigidBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, -25, 17);

        Move(h, v);
        Rotate();
        Animating(h, v);
    }
    void Move(float h, float v)
    {
        Movement.Set(h, 0f, v);

        Movement = Movement.normalized * speed * Time.deltaTime;

        Movement = Quaternion.Euler(0, 40, 0) * Movement;

        Movement = rotation * Movement;

        Movement.y = 0f;

        PlayerRigidBody.MovePosition(transform.position + Movement);
    }
    void Rotate()
    {
        rotation = Quaternion.Euler(-currentY, currentX, 0);
        PlayerRigidBody.MoveRotation(rotation);
    }

    void Animating(float h, float v)
    {
        bool walking;

        if (h != 0 || v != 0) walking = true;
        else walking = false;
            anim.SetBool("IsWalking", walking);
    }
}
