using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    [SerializeField] Transform CheckGroundR;
    [SerializeField] Transform CheckGroundL;
    [SerializeField] bool IsMovable;
    [SerializeField] float MoveSpeed;
    [SerializeField] LayerMask Ground;
    bool IsGround;
    bool MoveDirection;

    void OnTriggerEnter(Collider Other)
    {   
        if(Other.CompareTag("Ground"))
        {
            MoveDirection = !MoveDirection;
        }
        
        if(Other.CompareTag("Bullet"))
        {
            S_Logs.SaveLogs("Попадание");
            Destroy(Other.gameObject);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if(IsMovable)
        {
            if(MoveDirection)
            {
                if(Physics.CheckSphere(CheckGroundL.position, 0.1f, Ground))
                {
                    transform.position += transform.right * MoveSpeed * Time.deltaTime;
                }
                else
                {
                    MoveDirection = false;
                }
            }
            else
            {
                if(Physics.CheckSphere(CheckGroundR.position, 0.1f, Ground))
                {
                    transform.position += -transform.right * MoveSpeed * Time.deltaTime;
                }
                else
                {
                    MoveDirection = true;
                }
            }
        }
    }
}
