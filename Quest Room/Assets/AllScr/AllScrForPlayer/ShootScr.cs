using UnityEngine;

public class ShootScr : MonoBehaviour
{
    [SerializeField] Transform Shoulder;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform Muzzle;
    [SerializeField] Transform TestObject;

    [SerializeField] float MaxDistance = 10.0f;
    [SerializeField] float BulletSpeed = 10.0f;

    Move move;
    RaycastHit HitResult = new RaycastHit();
    Vector3 Target;

    float Delay = 0.5f;
    float TimeToShoot = 0.0f;

    void Start()
    {
        move = GetComponent<Move>();
    }

    void Update()
    {
        if (Physics.Raycast(move.Camera.position, move.Camera.forward, out HitResult, MaxDistance))
        {
            if (HitResult.collider != null && HitResult.collider.tag != "Bullet")
            {
                Target = HitResult.point;
            }
        }
        else
        {
            Target = move.Camera.position + move.Camera.forward * MaxDistance;
        }

        TestObject.position = Target;
        Shoulder.LookAt(Target);


        if (Input.GetKey(KeyCode.Mouse0) && TimeToShoot <= Time.time)
        {
            TimeToShoot = Time.time + Delay;
            Shoot(Target);
        }

        

    }
    
    private void Shoot(Vector3 TargetPoint)
    {
        if (TargetPoint != null)
        {
            //Shoulder.LookAt(TargetPoint);
            //Muzzle.LookAt(TargetPoint);

            GameObject NewBullet = Instantiate(BulletPrefab);

            NewBullet.transform.position = Muzzle.position;
            NewBullet.transform.eulerAngles = Shoulder.eulerAngles;
            
            Rigidbody RigBullet = NewBullet.GetComponent<Rigidbody>();
            RigBullet.AddForce(NewBullet.transform.forward * BulletSpeed, ForceMode.Impulse);

            Destroy(NewBullet, 10.0f);
        }


        
    }

}
