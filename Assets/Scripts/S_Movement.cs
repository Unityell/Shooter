using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Movement : MonoBehaviour
{
    [SerializeField] CharacterController Controller;
    [SerializeField] float Speed;
    [SerializeField] float Gravity;
    [SerializeField] Vector3 Velocity;
    [SerializeField] Transform GroundCheck;
    [SerializeField] float GroundDistance;
    [SerializeField] LayerMask Ground;
    bool IsGrounded;
    bool Push;
    float Timer = 0.25f;

    public void BulletPush()
    {
        Push = true;
    }

    void FixedUpdate()
    {
        if(Push)
        {
            Timer -= Time.deltaTime;
            Controller.Move(-transform.forward * Speed * 2 * Time.deltaTime);
            if(Timer <= 0)
            {
                Push = false;
                Timer = 0.25f;
            }
        }

        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, Ground);

        if(IsGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        float PosX = Input.GetAxisRaw("Horizontal");
        float PosZ = Input.GetAxisRaw("Vertical");

        Vector3 Move = (transform.right * PosX + transform.forward * PosZ).normalized;

        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            Move = Vector3.zero;
        }

        Controller.Move(Move * Speed * Time.deltaTime);

        Velocity.y += Gravity * Time.deltaTime;

        Controller.Move(Velocity * Time.deltaTime);
    }
}
