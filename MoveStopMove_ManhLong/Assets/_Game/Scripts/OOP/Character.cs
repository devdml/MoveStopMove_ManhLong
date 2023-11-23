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
    [SerializeField] private GameObject bulletPrefab;

    public GameObject target;

    private float fireCountdown = 0f;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        GetTarget();

        if (listTarget.Count <= 0)
        {
            Debug.Log("3");
            target = null;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            listTarget.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            listTarget.Remove(other.gameObject);
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
                Debug.Log("1");
            }
        }


        return target;
    }


    public void ShootTimer()
    {
        if (fireCountdown <= 0)
        {
            Shoot();
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

    private void Shoot()
    {
        GameObject bulletGo = Instantiate(bulletPrefab, pointShooting.position, pointShooting.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            if (target != null)
            {
                bullet.Seek(target.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}