using UnityEngine;

public enum WeaponType { None, Sword, Axe, Pickaxe }

[CreateAssetMenu(fileName = "NewWeapon", menuName = "PuebloMaldito/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public WeaponType type;
    public Sprite weaponSprite;
    public RuntimeAnimatorController animatorOverride;
}
