using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bullet : MonoBehaviour
{
    [SerializeField] float DestroyDistance;
    [SerializeField] float Speed;
    [SerializeField] GameObject Effect;
    [SerializeField] LayerMask Ground;
    Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
        
        if(Vector3.Distance(StartPosition, transform.position) > DestroyDistance)
        {
            Delete();
        }
    }

    void OnTriggerEnter(Collider Other)
    {
        if(Other.CompareTag("Ground"))
        {
            Delete();
        }
        if(Other.CompareTag("Player"))
        {
            if(tag == "EnemyBullet")
            {
                Other.GetComponent<S_Movement>().BulletPush();
            }
            Delete();
        }
    }

    public void Delete()
    {
        if(Effect)
        {
            Instantiate(Effect,transform.position,Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
