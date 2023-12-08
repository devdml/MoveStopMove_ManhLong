using System;
using UnityEngine;

[Serializable]
public class WeaponItemData
{
    public WeaponType Type;
    public int price;
    public float speedWeapon;
    public float rangeWeapon;
    public Bullet bulletPrefab;
    public WeaponView weaponSkin;
}
