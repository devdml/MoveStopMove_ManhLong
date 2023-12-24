using System.Collections.Generic;
using UnityEngine;

public class MyDataPlayer : MonoBehaviour
{
    public List<WeaponView> weaponList = new List<WeaponView>();
    public HatDataSO hatDataSO;
    public WeaponDataOS weaponDataOS;
    public Transform pointWeapon;
    public Transform pointHat;
    private Character character;
    public WeaponType weaponType;
    public HatType hatType;
    public HatView myHat;
    public WeaponView myWeapon;
    private PlayerData playerData;
    public ShopWeapon shopWeapon;
    public ShopSkinHead shopSkinHead;

    private void Awake()
    {
        character = GetComponent<Character>();
        playerData = DataManager.Instance.playerData;

        if (playerData == null)
        {
            OnInit(); 
        }
    }

    private void Start()
    {
        GetPlayerData();
        SetDataPlayer();
    }

    [ContextMenu("GetPlayerData")]

    public void OnInit()
    {
        weaponType = WeaponType.axe_0;
        hatType = HatType.arrow;
        SavePlayerData();
    }

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
        weaponType = playerData.WeaponType;
        hatType = playerData.HatType;

        for (int i = 0; i < weaponDataOS.weapons.Count; i++)
        {
            if (weaponType == weaponDataOS.weapons[i].Type)
            {
                myWeapon = Instantiate(weaponDataOS.weapons[i].weaponSkin, pointWeapon);
                character.bulletPrefab = weaponDataOS.weapons[i].bulletPrefab;
            }
        }

        for (int i = 0; i < hatDataSO.hatItemDatas.Count; i++)
        {
            if (hatType == hatDataSO.hatItemDatas[i].HatType)
            {
                myHat = Instantiate(hatDataSO.hatItemDatas[i].hatView, pointHat);
            }
        }
    }

    //public void SetDataPlayer()
    //{
    //    WeaponItemData weaponItemData = DataManager.Instance.GetWeaponData(weaponType);
    //    playerData.WeaponType = weaponType;
    //    character.range = weaponItemData.rangeWeapon;
    //    character.bulletPrefab = weaponItemData.bulletPrefab;
       
    //    for (int i = 0; i < weaponList.Count; i++)
    //    {
    //        if (weaponType == weaponList[i].weaponType)
    //        {
    //            Instantiate(weaponList[i], pointWeapon);
    //        }
    //    }
    //}

    //public void ChangeHat()
    //{
    //    for (int i = 0; i < hatDataSO.hatItemDatas.Count; i++)
    //    {
    //        if (hatType == hatDataSO.hatItemDatas[i].HatType)
    //        {
    //            if (myHat != null)
    //            {
    //                Destroy(myHat.gameObject);
    //            }

    //            myHat = Instantiate(hatDataSO.hatItemDatas[i].hatObj, pointHat);
    //            hatType = playerData.HatType;
    //        }
    //    }
    //}
}
