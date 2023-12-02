using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataOS")]
public class WeaponDataOS : ScriptableObject
{
    public List<WeaponItemData> weapons;
}

public enum WeaponType
{
    axe_0 = 0,
    axe_1 = 1,
    candy_1 = 2,
}