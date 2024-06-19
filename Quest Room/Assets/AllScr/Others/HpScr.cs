using UnityEngine;

public class HpScr : MonoBehaviour
{
    [SerializeField] public float Health = 100.0f;

    public void CheckStateHealth()
    {
        if(Health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

}
