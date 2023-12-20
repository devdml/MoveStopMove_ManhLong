using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [Header("Setup Enemy")]
    public NavMeshAgent agent;
    public Transform skin;
    public float wanderTimer = 5;
    public float wanderRadius;
    private IState<Enemy> currentState;
    

    void OnEnable()
    {
        target = null;
        agent = GetComponent<NavMeshAgent>();
        isDeath = false;
    }

    protected override void Start()
    {
        base.Start();

        moveSpeed = agent.speed;
        ChangeState(new WalkState());
    }

    protected override void Update()
    {
        if (GameManager.Instance.IsStage(GameState.GamePlay))
        {
            if (isDeath == true)
            {
                agent.isStopped = true;
                ChangeAnim(CacheString.ANIM_DEAD);
                return;
            }
            base.Update();

            if (currentState != null)
            {
                currentState.OnExcute(this);
            }
        }
    }

    public void ChangeState(IState<Enemy> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void SetDestination(Vector3 position)
    {
        agent.SetDestination(position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
    }

    private void OnDisable()
    {
        LevelManager.Instance.textMaxEnemy -= 1;
        LevelManager.Instance.enemyList.Remove(this);
    }
}
