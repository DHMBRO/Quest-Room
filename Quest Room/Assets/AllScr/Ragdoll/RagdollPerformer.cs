using UnityEngine;

public class RagdollPerformer : MonoBehaviour
{
    public void GetReferences(RagdollControler ControlerRagdoll)
    {
        ControlerRagdoll.SetRagdollDelegat += SetRigidboby;
        ControlerRagdoll.SetRagdollDelegat += SetColision;
    }

    public void SetRigidboby(bool EnableRagdoll)
    {
        Rigidbody LocalRigidbody = GetComponent<Rigidbody>();

        LocalRigidbody.isKinematic = !EnableRagdoll;
    }

    public void SetColision(bool EnableRagdoll)
    {
        Collider LocalCollider = GetComponent<Collider>();

        LocalCollider.enabled = EnableRagdoll;
        LocalCollider.isTrigger = !EnableRagdoll;
    }

}
