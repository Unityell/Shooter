using UnityEngine;

public abstract class S_Gun : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShootPoint;
    public abstract void CreateBullet();
}
