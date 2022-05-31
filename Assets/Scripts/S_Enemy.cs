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

    public void Die(GameObject Obj)
    {
        if(Obj.CompareTag("Bullet"))
        {
            S_Logs.SaveLogs("Попадание");
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider Other)
    {   
        if(Other.CompareTag("Ground"))
        {
            MoveDirection = !MoveDirection;
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
