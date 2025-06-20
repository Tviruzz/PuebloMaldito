using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Image[] weaponSlots;
    public GameObject equippedWeaponSprite; // Imagen del arma en la mano
    public Sprite emptyHandSprite;

    private int currentWeaponIndex = -1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TryPickupWeapon();
        }

        // Switch con Q y E
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CycleWeapon(-1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CycleWeapon(1);
        }
    }

    void TryPickupWeapon()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (var hit in hits)
        {
            PickupWeapon weapon = hit.GetComponent<PickupWeapon>();
            if (weapon != null)
            {
                AssignWeaponToSlot(weapon.weaponName, weapon.weaponIcon, weapon.equippedSprite);
                Destroy(hit.gameObject); // Lo elimina del suelo
                break;
            }
        }
    }

    void AssignWeaponToSlot(string name, Sprite icon, Sprite spriteInHand)
    {
        int slotIndex = name == "Sword" ? 0 : name == "Axe" ? 1 : -1;

        if (slotIndex == -1 || weaponSlots[slotIndex].sprite == icon)
            return;

        weaponSlots[slotIndex].sprite = icon;

        currentWeaponIndex = slotIndex;
        equippedWeaponSprite.GetComponent<SpriteRenderer>().sprite = spriteInHand;
    }

    void CycleWeapon(int direction)
    {
        int total = weaponSlots.Length;
        if (total == 0) return;

        do
        {
            currentWeaponIndex = (currentWeaponIndex + direction + total) % total;
        } while (weaponSlots[currentWeaponIndex].sprite == null);

        Sprite equipped = weaponSlots[currentWeaponIndex].sprite;
        equippedWeaponSprite.GetComponent<SpriteRenderer>().sprite = equipped ?? emptyHandSprite;
    }
}
