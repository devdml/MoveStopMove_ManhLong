using UnityEngine;
using UnityEngine.AI;

public class WalkState : IState<Enemy>
{
    private float timer;
    public Vector3 newPos;

    public void OnEnter(Enemy t)
    {
        timer = t.wanderTimer;
        t.agent.speed = 7f;
        t.agent.isStopped = false;
    }

    public void OnExcute(Enemy t)
    {
        if (t.target != null)
        {
            t.ChangeAnim(CacheString.ANIM_IDLE);
            t.agent.isStopped = true;
            t.agent.speed = 0;
            t.ChangeState(new AttackState());
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= t.wanderTimer)
            {
                newPos = RandomNavSphere(t.transform.position, t.wanderRadius, -1);
                t.agent.SetDestination(newPos);
                timer = 0;

            }
        }

        if (Vector3.Distance(t.agent.transform.position, newPos) < 1.1f)
        {
            t.ChangeAnim(CacheString.ANIM_IDLE);
        } else
        {
            t.ChangeAnim(CacheString.ANIM_RUN);
        }

    }

    public void OnExit(Enemy t)
    {

    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

}
