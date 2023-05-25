using UnityEngine;

public class TrgContr02 : MonoBehaviour
{
    [SerializeField] OpenDoor Door;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "KeyRed")
        {
            Door.BlueKey = true;
        }
    }
}
