using UnityEngine;

public class Player : Character
{
    [Header("Player Setup")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform skin;
    [SerializeField] private float playerSpeed;

    private bool isMove;

    protected override void Update()
    {
        Joystick();

        base.Update();

        if (!isMove && target != null)
        {
            RotateToTarget();
            ShootTimer();
        }
    }

    private void Joystick()
    {
        if (Input.GetMouseButton(0))
        {
            isMove = true;
            rb.velocity = JoystickController.direct * playerSpeed + rb.velocity.y * Vector3.up;
            if (JoystickController.direct != Vector3.zero)
            {
                skin.forward = JoystickController.direct;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.zero;
            isMove = false;
        }
    }

}
