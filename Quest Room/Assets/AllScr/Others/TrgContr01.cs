using UnityEngine;

public class TrgContr01 : MonoBehaviour
{
    [SerializeField] OpenDoor Door;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "KeyBlue")
        {
            Door.RedKey = true;
        }
    }
}
