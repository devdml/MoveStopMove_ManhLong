using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character Attributes")]
    [SerializeField] private float range = 8f;
    [SerializeField] protected float fireRate = 1f;
    [SerializeField] private List<GameObject> listTarget = new List<GameObject>();
    [SerializeField] private Transform skinRotate;
    [SerializeField] private Transform pointShooting;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Animator anim;

    protected Bullet bulletOjb;
    protected string currentAnimName = Constant.ANIM_IDLE;
    protected Vector3 dir;
    public bool isOut;
    public bool isAttack;

    public GameObject target;

    private float fireCountdown = 0f;

    protected virtual void Start()
    {
        OnInit();
    }

    protected virtual void Update()
    {
        if (isOut == true)
        {
            GetTarget();
        } else
        {
            target = null;
            GetTarget();
        }
    }

    public virtual void OnInit()
    {
        isAttack = false;
        ChangeAnim(Constant.ANIM_IDLE);
    }

    private void SpawnBullet()
    {
        if (target != null)
        {
            dir = target.transform.position - transform.position;

            Bullet spawnBullet = LeanPool.Spawn(bulletPrefab, pointShooting.position, pointShooting.rotation);
            bulletOjb = spawnBullet.GetComponent<Bullet>();
            bulletOjb.SeekAttacker(this);
            bulletOjb.SeekDirec(dir);
            bulletOjb.OnDespawn(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            listTarget.Add(other.gameObject);
            isOut = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
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
            Debug.Log(animName);
            anim.ResetTrigger(currentAnimName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }

    public IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(2);
        ChangeAnim(Constant.ANIM_NULL);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
