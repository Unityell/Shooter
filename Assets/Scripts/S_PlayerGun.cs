using UnityEngine;
using UnityEngine.UI;

public class S_PlayerGun : S_Gun
{   
    [HideInInspector] public RaycastHit hit;
    [HideInInspector] public Camera GameCamera;
    [SerializeField] Image Aim;
    [SerializeField] Color EnemyNotFound;
    [SerializeField] Color EnemyHere;
    [SerializeField] LayerMask Enemy;
    [SerializeField] LayerMask Ground;
    public float RayLenght;
    S_Movement PlayerMovement;
    void Start()
    {
        GameCamera = Camera.main;
        PlayerMovement = GetComponentInParent<S_Movement>();
    }
    public override void CreateBullet()
    {
        if(!hit.collider)
        {
            var NewBullet = Instantiate(Bullet, ShootPoint.position, Quaternion.LookRotation(GameCamera.transform.forward));
            NewBullet.GetComponent<S_Bullet>().Init(PlayerMovement.Controller.velocity.magnitude);
        }
        else
        {
            var NewBullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            NewBullet.GetComponent<S_Bullet>().Init(PlayerMovement.Controller.velocity.magnitude);
            NewBullet.transform.LookAt(hit.point);
        }
        S_Logs.SaveLogs("Выстрел");
    }
    void AimRecolor()
    {
        if(hit.collider?.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Aim.color = EnemyHere;
        }
        else
        {
            Aim.color = EnemyNotFound;
        }
    }
    void FixedUpdate()
    {
        Physics.Raycast(GameCamera.transform.position, GameCamera.transform.forward, out hit, RayLenght);

        AimRecolor();
    }
    void Update()
    {     
        if(Input.GetMouseButtonDown(0))
        {
            if(Bullet != null)
            {
                CreateBullet();
            }
        }
    }
}
