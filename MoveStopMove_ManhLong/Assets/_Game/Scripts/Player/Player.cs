using UnityEngine;

public class Player : Character
{
    [Header("Player Setup")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform skin;

    public float rangePlayer;
    public float playerSpeed;

    public SphereCollider sphereCollider;
    private bool isMove;

    protected override void Awake()
    {
        base.Awake();
        sphereCollider = GetComponent<SphereCollider>();
    }

    protected override void Start()
    {
        base.Start();
        sphereCollider.radius = rangePlayer;
    }

    protected override void Update()
    {
        Joystick();

        base.Update();

        if (!isMove && target != null)
        {
            isAttack = true;
            RotateToTarget();
            ShootTimer();
        }
    }

    private void Joystick()
    {
        if (Input.GetMouseButton(0))
        {
            isMove = true;
            isAttack = false;
            rb.velocity = JoystickController.direct * playerSpeed + rb.velocity.y * Vector3.up;
            if (JoystickController.direct != Vector3.zero)
            {
                ChangeAnim(Constant.ANIM_RUN);
                skin.forward = JoystickController.direct;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            ChangeAnim(Constant.ANIM_IDLE);
            rb.velocity = Vector3.zero;
            isMove = false;
        }
    }

}
