using Lean.Pool;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    public WeaponType Type;


    public Character character;
    private Vector3 dir;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Update()
    {
        rb.velocity = dir.normalized * speed;
    }

    public void SeekDirec(Vector3 dir)
    {
        this.dir = dir;
    }

    public void SeekAttacker(Character character)
    {
        this.character = character;
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

            if (this.character != character)
            {
                LeanPool.Despawn(gameObject);
            }
        }
    }
}
