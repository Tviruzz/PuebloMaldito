using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    public SpriteRenderer weaponRenderer;
    public Sprite[] weaponSprites;

    // Puedes usar un �ndice o un enum m�s adelante
    public int currentWeaponIndex = 0;

    void Start()
    {
        EquipWeapon(currentWeaponIndex);
    }

    public void EquipWeapon(int index)
    {
        if (index >= 0 && index < weaponSprites.Length)
        {
            weaponRenderer.sprite = weaponSprites[index];
            currentWeaponIndex = index;
        }
    }
}