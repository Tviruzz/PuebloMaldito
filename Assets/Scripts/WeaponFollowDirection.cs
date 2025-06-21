using UnityEngine;

public class WeaponFollowDirection : MonoBehaviour
{
    public Transform player; // Asigna el personaje
    public Vector3 offsetRight = new Vector3(0.2f, -0.1f, 0); // Posición al caminar a la derecha
    public Vector3 offsetLeft = new Vector3(-0.2f, -0.1f, 0); // Posición al caminar a la izquierda

    private SpriteRenderer weaponRenderer;

    void Start()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontal = player.GetComponent<PlayerInputMovement>().MoveInput.x;

        if (horizontal > 0)
        {
            transform.localPosition = offsetRight;
            weaponRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            transform.localPosition = offsetLeft;
            weaponRenderer.flipX = true;
        }
    }
}
