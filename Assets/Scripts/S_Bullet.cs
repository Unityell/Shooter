using UnityEngine;

public class S_Bullet : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float DestroyDistance;
    [SerializeField] float FlightSpeed;
    [SerializeField] GameObject Effect;
    [SerializeField] LayerMask Ground;
    Vector3 StartPosition;
    float StartSpeed;
    public void Init(float Speed)
    {
        StartPosition = transform.position;
        StartSpeed = Speed;
    }
    void Move()
    {
        transform.position += transform.forward * (FlightSpeed + StartSpeed) * Time.deltaTime;
    }
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, FlightSpeed * Time.deltaTime))
        {
            CheckCollision(hit.collider.gameObject);
        }

        Move();
        
        if(Vector3.Distance(StartPosition, transform.position) > DestroyDistance)
        {
            Delete(transform.position);
        }
    }
    void CheckCollision(GameObject obj)
    {
        if(obj?.layer == LayerMask.NameToLayer("Ground"))
        {
            Delete(hit.point);
        }
        if(obj?.layer == LayerMask.NameToLayer("Enemy"))
        {
            obj?.GetComponent<S_Enemy>().Die(gameObject);
            Delete(hit.point);
        }
        if(obj?.layer == LayerMask.NameToLayer("Player"))
        {
            if(tag == "EnemyBullet")
            {
                obj?.GetComponent<S_Movement>().BulletPush();
                Delete(hit.point);
            }
        }
    }
    public void Delete(Vector3 Point)
    {
        if(Effect)
        {
            Instantiate(Effect,Point,Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
