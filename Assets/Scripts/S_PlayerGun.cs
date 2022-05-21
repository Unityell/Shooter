using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PlayerGun : S_Gun
{   
    [HideInInspector] public RaycastHit hit;
    [HideInInspector] public RaycastHit HitEnemy;
    [HideInInspector] public Camera GameCamera;
    [SerializeField] Image Aim;
    [SerializeField] Color EnemyNotFound;
    [SerializeField] Color EnemyHere;
    [SerializeField] LayerMask Enemy;
    [SerializeField] LayerMask Ground;
    public float RayLenght;
    void Start()
    {
        GameCamera = Camera.main;
    }
    public override void CreateBullet()
    {
        if(!hit.collider)
        {
            Instantiate(Bullet, ShootPoint.position, Quaternion.LookRotation(GameCamera.transform.forward));
        }
        else
        {
            var NewBullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            NewBullet.transform.LookAt(hit.point);
        }
        S_Logs.SaveLogs("Выстрел");
    }
    void FixedUpdate()
    {
        Physics.Raycast(GameCamera.transform.position, GameCamera.transform.forward, out hit, RayLenght);

        Physics.Raycast(GameCamera.transform.position, GameCamera.transform.forward, out HitEnemy, RayLenght, Enemy);

        if(HitEnemy.collider)
        {
            if(!Physics.Linecast(transform.position, HitEnemy.collider.gameObject.transform.position, Ground))
            {
                Aim.color = EnemyHere;
            }
            else
            {
                Aim.color = EnemyNotFound;
            }
        }
        else
        {
            Aim.color = EnemyNotFound;
        }
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Bullet != null)
            {
                CreateBullet() ;
            }
        }
    }
}
