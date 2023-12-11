using System.Collections.Generic;
using UnityEngine;

public class MyDataPlayer : MonoBehaviour
{
    public List<WeaponView> weaponList = new List<WeaponView>();
    public HatDataSO hatDataSO;
    public Transform pointWeapon;
    public Transform pointHat;
    private Character character;
    public WeaponType weaponType;
    public HatType hatType;
    public GameObject myHat;
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
        PlayerData newPlayerData = new PlayerData(weaponType, hatType , character.moveSpeed, character.range);
        DataManager.Instance.SavePlayerData(newPlayerData);
    }

    public void SetDataPlayer()
    {
        WeaponItemData weaponItemData = DataManager.Instance.GetWeaponData(weaponType);

        hatType = playerData.HatType;
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

        for (int i = 0; i < hatDataSO.hatItemDatas.Count; i++)
        {
            if (hatType == hatDataSO.hatItemDatas[i].HatType)
            {
                if (myHat != null)
                {
                    Destroy(myHat.gameObject);
                }

                myHat = Instantiate(hatDataSO.hatItemDatas[i].hatObj, pointHat);
            }
        }
    }
}
