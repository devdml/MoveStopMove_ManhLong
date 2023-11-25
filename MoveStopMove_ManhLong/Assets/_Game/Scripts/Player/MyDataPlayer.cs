using System.Collections.Generic;
using UnityEngine;

public class MyDataPlayer : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    public Transform pointWeapon;

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

        int index = weapons.Count;
        for (int i = 0; i < index; i++)
        {
            if (weapons[i] == DataManager.Instance.weaponDataOS)
            {
                Instantiate(weapons[i], pointWeapon);
            }
        }
    }
}
