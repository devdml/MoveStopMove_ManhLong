using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 30f;
    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Shoot();
    }

    private void Shoot()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        dir.y = 0f;
        float speedFrame = moveSpeed * Time.deltaTime;

        if (dir.magnitude <= speedFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * speedFrame, Space.World);
        
    }


    private void HitTarget()
    {
        //Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
