using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    public Image[] weaponSlots;
    public RectTransform selectorFrame;

    private int currentIndex = 0;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();

        inputActions.Player.equipNext.performed += ctx => NextSlot();
        inputActions.Player.equipPrev.performed += ctx => PrevSlot();
    }

    private void NextSlot()
    {
        currentIndex = (currentIndex + 1) % weaponSlots.Length;
        UpdateSelector();
    }

    private void PrevSlot()
    {
        currentIndex = (currentIndex - 1 + weaponSlots.Length) % weaponSlots.Length;
        UpdateSelector();
    }

    private void UpdateSelector()
    {
        selectorFrame.position = weaponSlots[currentIndex].transform.position;
    }
}
