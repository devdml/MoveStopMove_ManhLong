using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character Attributes")]
    [SerializeField] public float range = 8f;
    [SerializeField] protected float fireRate = 1f;
    [SerializeField] private Transform skinRotate;
    [SerializeField] private Transform pointShooting;
    [SerializeField] private Animator anim;
    [SerializeField] private WeaponItemData weaponItemData;

    public GetColliderRadius colliderRadius;
    public SphereCollider sphereCollider;
    public float moveSpeed;
    public GameObject offWeaponView;
    public List<GameObject> listTarget = new List<GameObject>();
    protected Bullet bulletOjb;
    protected string currentAnimName = CacheString.ANIM_IDLE;
    protected Vector3 dir;
    public Bullet bulletPrefab;
    public bool isOut;
    public bool isAttack;
    public bool isDeath;

    public GameObject target;

    private float fireCountdown = 0f;


    protected virtual void Awake()
    {
        GameManager.Instance.ChangeStage(GameState.MainMenu);
    }

    protected virtual void Start()
    {
        OnInit();
    }

    protected virtual void Update()
    {
        if (GameManager.Instance.IsStage(GameState.GamePlay))
        {
            if (isOut == true)
            {
                GetTarget();
            }
            else
            {
                target = null;
                GetTarget();
            }
        }
    }

    public virtual void OnInit()
    {
        isAttack = false;
        isDeath = false;
        ChangeAnim(CacheString.ANIM_IDLE);
        //colliderRadius.sphereCollider = GetComponent<GetColliderRadius>().sphereCollider;
        //sphereCollider = colliderRadius.sphereCollider;
        //sphereCollider.radius = range;
    }

    private void SpawnBullet()
    {
        if (target != null)
        {
            dir = target.transform.position - transform.position;

            Bullet spawnBullet = LeanPool.Spawn(bulletPrefab, pointShooting.position, pointShooting.rotation);
            bulletOjb = spawnBullet.GetComponent<Bullet>();
            bulletOjb.SeekDirec(dir);
            bulletOjb.SeekAttacker(this);
            bulletOjb.OnDespawn(1.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CacheString.TAG_CHARACTER))
        {
            Character character = other.GetComponent<Character>();
            if (character.isDeath == false)
            {
                listTarget.Add(other.gameObject);
                isOut = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(CacheString.TAG_CHARACTER))
        {
            listTarget.Remove(other.gameObject);
            isOut = false;
        }
    }

    public virtual GameObject GetTarget()
    {
        for (int i = 0; i < listTarget.Count; i++)
        {
            if (listTarget[i] != null)
            {
                target = DistanceToTarget(listTarget[i]);
                if (target.activeInHierarchy == false)
                {
                    listTarget.Remove(target);
                }
            }

            if (listTarget.Count == 0)
            {
                target = null;
            }
        }


        return target;
    }


    public void ShootTimer()
    {
        if (fireCountdown <= 0)
        {
            SpawnBullet();
            Attack();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    public void RotateToTarget()
    {
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;
            if (dir != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(skinRotate.rotation, lookRotation, 15f * Time.deltaTime).eulerAngles;
                skinRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        }
    }

    private GameObject DistanceToTarget(GameObject target)
    {
        float shortDis = Mathf.Infinity;
        foreach (GameObject list in listTarget)
        {
            float distanceToTarget = Vector3.Distance(transform.position, list.transform.position);
            if (distanceToTarget < shortDis)
            {
                shortDis = distanceToTarget;
                target = list;
            }
        }
        return target;

    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(currentAnimName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }

    private void Attack()
    {
        isAttack = true;
        offWeaponView.SetActive(false);
        ChangeAnim(CacheString.ANIM_ATTACK);
        Invoke(nameof(ResetAttack), 0.7f);
    }

    private void ResetAttack()
    {
        isAttack = false;
        offWeaponView.SetActive(true);
        ChangeAnim(CacheString.ANIM_IDLE);
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
