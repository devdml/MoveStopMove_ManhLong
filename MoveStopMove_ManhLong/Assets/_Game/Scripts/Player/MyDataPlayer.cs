using System.Collections.Generic;
using UnityEngine;

public class MyDataPlayer : MonoBehaviour
{
    public List<WeaponView> weaponList = new List<WeaponView>();
    public Transform pointWeapon;
    public Transform holderWeapons;

    public WeaponType weaponType;
    private Player player;
    private PlayerData playerData;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        GetPlayerData();
        SavePlayerData();
        GetWeaponData();
        if (holderWeapons.childCount > 9)
        {
            Debug.Log(holderWeapons.childCount.ToString());
        }
    }

    [ContextMenu("GetPlayerData")]
    public void GetPlayerData()
    {
        playerData = DataManager.Instance.GetPlayerData();
    }

    [ContextMenu("SavePlayerData")]
    public void SavePlayerData()
    {
        PlayerData newPlayerData = new PlayerData(weaponType, player.playerSpeed, player.rangePlayer);
        DataManager.Instance.SavePlayerData(newPlayerData);
    }

    public void GetWeaponData()
    {
        WeaponItemData weaponItemData = DataManager.Instance.GetWeaponData(weaponType);
        playerData.WeaponType = weaponType;
        player.rangePlayer = weaponItemData.rangeWeapon;

        for (int i = 0; i < weaponList.Count; i++)
        {
            if (weaponType == weaponList[i].WeaponType)
            {
                Instantiate(weaponList[i], pointWeapon);
            }
        }
    }
}
