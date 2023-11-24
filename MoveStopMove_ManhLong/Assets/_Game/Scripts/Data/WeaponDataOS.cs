using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataOS")]
public class WeaponDataOS : ScriptableObject
{
    public List<WeaponItemData> weapons;
}

public enum WeaponType
{
    Knife = 0,
    Hammer = 1,
    Boomerang = 2,
}