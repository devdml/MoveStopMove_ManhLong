public class AttackState : IState<Enemy>
{
    public void OnEnter(Enemy t)
    {

    }

    public void OnExcute(Enemy t)
    {
        if (t.target != null)
        {
            if (t.target == null)
            {
                t.GetTarget();
                return;
            }

            t.RotateToTarget();

            if (t.target != null && t.agent.speed == 0)
            {
                t.ShootTimer();
            }
        }
        else
        {
            t.ChangeState(new WalkState());
        }
    }

    public void OnExit(Enemy t)
    {

    }
}
