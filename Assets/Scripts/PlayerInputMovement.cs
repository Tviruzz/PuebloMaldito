using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerInputMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;
    public Vector2 MoveInput => moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        // Actualiza el Animator con los valores de dirección
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);

        // Solo activa animaciones de caminar si hay movimiento
        animator.SetBool("IsMoving", moveInput.magnitude > 0.1f);
    }

    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
