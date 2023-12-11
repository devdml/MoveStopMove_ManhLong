using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public HatDataSO hatDataSO;
    public WeaponDataOS weaponDataOS;
    public PlayerData playerData;


    string userPlayerDataKey = "userPlayerDataKey";


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        playerData = GetPlayerData();
    }

    public void ChangeWeapon(WeaponType weaponType)
    {
        playerData.WeaponType = weaponType;
        SavePlayerData(playerData);
    }

    public void changeHat(HatType hatType)
    {
        playerData.HatType = hatType;
        SavePlayerData(playerData);
    }

    public void SavePlayerData(PlayerData playerData)
    {
        string playerDataString = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString(userPlayerDataKey, playerDataString);
    }

    public PlayerData GetPlayerData()
    {
        string playerDataString = PlayerPrefs.GetString(userPlayerDataKey);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(playerDataString);
        return playerData;
    }

    public WeaponItemData GetWeaponData(WeaponType weaponType)
    {
        for (int i = 0; i < weaponDataOS.weapons.Count; i++)
        {
            if (weaponDataOS.weapons[i].Type == weaponType)
            {
                return weaponDataOS.weapons[i];
            }
        }
        return null;
    }

    public HatItemData GetHatItemData(HatType hatType)
    {
        for (int i = 0; i < hatDataSO.hatItemDatas.Count; i++)
        {
            if (hatDataSO.hatItemDatas[i].HatType == hatType)
            {
                return hatDataSO.hatItemDatas[i];
            }
        }
        return null;
    }
}
