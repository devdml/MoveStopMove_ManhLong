using System.Collections.Generic;
using UnityEngine;

public class MyDataPlayer : MonoBehaviour
{
    public List<WeaponView> weaponList = new List<WeaponView>();
    public Transform pointWeapon;
    private Character character;
    public WeaponType weaponType;
    private PlayerData playerData;

    private void Awake()
    {
        character = GetComponent<Character>();
    }
    private void OnEnable()
    {
        GetPlayerData();
        SetDataPlayer();
    }

    [ContextMenu("GetPlayerData")]
    public void GetPlayerData()
    {
        playerData = DataManager.Instance.GetPlayerData();
    }

    [ContextMenu("SavePlayerData")]
    public void SavePlayerData()
    {
        PlayerData newPlayerData = new PlayerData(weaponType, character.moveSpeed, character.range);
        DataManager.Instance.SavePlayerData(newPlayerData);
    }

    public void SetDataPlayer()
    {
        WeaponItemData weaponItemData = DataManager.Instance.GetWeaponData(weaponType);

        playerData.WeaponType = weaponType;
        character.range = weaponItemData.rangeWeapon;
        character.bulletPrefab = weaponItemData.bulletPrefab;

        for (int i = 0; i < weaponList.Count; i++)
        {
            if (weaponType == weaponList[i].weaponType)
            {
                Instantiate(weaponList[i], pointWeapon);
            }
        }
    }
}
