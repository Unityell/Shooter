using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Gun : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShootPoint;

    public virtual void CreateBullet()
    {
        Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
    }
}
