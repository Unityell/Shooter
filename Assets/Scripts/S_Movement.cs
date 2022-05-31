using UnityEngine;

public class S_Movement : MonoBehaviour
{
    public CharacterController Controller;
    [SerializeField] float MoveSpeed;
    [SerializeField] float Gravity;
    [SerializeField] float JumpPower;
    Vector3 Velocity;
    [SerializeField] Transform GroundCheckPoint;
    [SerializeField] float GroundCheckDistance;
    [SerializeField] LayerMask Ground;
    bool Push;
    float Timer = 0.25f;

    public void BulletPush()
    {
        Push = true;
    }

    void Move()
    {
        float PosX = Input.GetAxisRaw("Horizontal");
        float PosZ = Input.GetAxisRaw("Vertical");

        Vector3 Move = (transform.right * PosX + transform.forward * PosZ).normalized;

        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            Move = Vector3.zero;
        }

        Controller.Move(Move * MoveSpeed * Time.deltaTime);
    }

    bool DetectGround()
    {
        return Physics.CheckSphere(GroundCheckPoint.position, GroundCheckDistance, Ground);
    }
    void CastGravity()
    {
        Velocity.y += Gravity * Time.deltaTime;
        Controller.Move(Velocity * Time.deltaTime);
    }
    void Jump()
    {
        Velocity.y = JumpPower;
    }

    void Update()
    {
        if(Push)
        {
            Timer -= Time.deltaTime;
            Controller.Move(-transform.forward * MoveSpeed * 2 * Time.deltaTime);
            if(Timer <= 0)
            {
                Push = false;
                Timer = 0.25f;
            }
        }

        if(DetectGround() && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        Move();
        CastGravity();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(DetectGround())
            {
                Jump();
            }
        }
    }
}
