using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyGun : S_Gun
{
    [SerializeField] GameObject Master;
    [SerializeField] LayerMask Ground;
    [SerializeField] float AttackTimer;
    float ShadowAttackTimer;
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void CreateBullet()
    {
        var NewBullet = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        NewBullet.tag = "EnemyBullet";
    }
    void Update()
    {
        if(Player != null)
        {
            if (Physics.Linecast(transform.position, Player.transform.position, Ground))
            {

            }
            else
            {
                ShadowAttackTimer -= Time.deltaTime;
                if(ShadowAttackTimer <= 0)
                {
                    CreateBullet();
                    ShadowAttackTimer = AttackTimer;
                }
            }
        }
    }
}
