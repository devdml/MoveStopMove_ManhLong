using Lean.Pool;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] LevelManager levelManager;
    
    private Vector3 dir;

    public WeaponType Type;
    public Character character;

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
        if(other.CompareTag(CacheString.TAG_CHARACTER))
        {
            Character charc = other.GetComponent<Character>();

            if (this.character != charc)
            {
                LeanPool.Despawn(gameObject);
                LeanPool.Despawn(charc.gameObject, 5f);
                charc.isDeath = true;
                character.listTarget.Remove(character.target);
                character.target = null;
            }
        }
    }
}
