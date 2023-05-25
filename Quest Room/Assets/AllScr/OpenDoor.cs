using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] List<Transform> Points = new List<Transform>();

    public bool RedKey;
    public bool BlueKey;
    

   

    void Update()
    {
        if (RedKey && BlueKey)
        {
            transform.position = Points[0].position;  
        }
        else
        {
            transform.position = Points[1].position;
        }
        Debug.Log("RedKey" + RedKey);
        Debug.Log("BlueKey" + BlueKey);
    }
}
