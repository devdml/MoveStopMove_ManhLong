using UnityEngine;

public class GetColliderRadius : MonoBehaviour
{
    public SphereCollider sphereCollider;

    private void Awale()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }
}
