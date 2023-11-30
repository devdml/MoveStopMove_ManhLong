using Lean.Pool;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;

    private Character attacker;
    private Vector3 dir;

    private void Update()
    {
        rb.velocity = dir.normalized * speed;
    }

    public void SeekDirec(Vector3 dir)
    {
        this.dir = dir;
    }

    public void SeekAttacker(Character attacker)
    {
        this.attacker = attacker;
    }

    public void OnDespawn(float timeDespawn)
    {
        LeanPool.Despawn(gameObject, timeDespawn);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Constant.TAG_CHARACTER))
        {
            Character character = other.GetComponent<Character>();

            if (attacker != character)
            {
                LeanPool.Despawn(gameObject);
            }
        }
    }
}
