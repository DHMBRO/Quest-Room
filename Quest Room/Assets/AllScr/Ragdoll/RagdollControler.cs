using UnityEngine;
using System.Collections.Generic;

public class RagdollControler : MonoBehaviour
{
    public SetRagdoll SetRagdollDelegat;


    void Start()
    {
        List<Rigidbody> AllBones = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());

        for (int i = 0;i < AllBones.Count;i++)
        {
            AllBones[i].gameObject.AddComponent<RagdollPerformer>();
            AllBones[i].GetComponent<RagdollPerformer>().GetReferences(this);
        }

        SetRagdollDelegat += EnableAnimator;

        SetRagdollDelegat(false);
    }

    private void EnableAnimator(bool Enable)
    {
        GetComponent<Animator>().enabled = !Enable;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
            SetRagdollDelegat(true); 
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetRagdollDelegat(false);
        }
    }
}
