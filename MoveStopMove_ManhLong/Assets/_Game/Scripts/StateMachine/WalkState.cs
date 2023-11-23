using UnityEngine;
using UnityEngine.AI;

public class WalkState : IState<Enemy>
{
    private float timer;
    Vector3 newPos;
    public void OnEnter(Enemy t)
    {
        timer = t.wanderTimer;
        t.agent.speed = 10f;
    }

    public void OnExcute(Enemy t)
    {
        if (t.target != null)
        {
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
