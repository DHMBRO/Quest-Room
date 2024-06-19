using UnityEngine;

public class BulletScr : MonoBehaviour
{
    [SerializeField] float BulletDamage = 10.0f;


    private void OnTriggerEnter(Collider other)
    {
        HpScr TargetHpScr = other.GetComponent<HpScr>();
        if (!TargetHpScr) return;

        TargetHpScr.Health -= BulletDamage;
        TargetHpScr.CheckStateHealth();

        Destroy(gameObject);
    }
}
