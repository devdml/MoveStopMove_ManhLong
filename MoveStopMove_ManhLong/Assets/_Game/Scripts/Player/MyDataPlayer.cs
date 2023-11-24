using UnityEngine;

public class MyDataPlayer : MonoBehaviour
{
    public WeaponType weaponType;
    private Player player;
    private PlayerData playerData;
    private Transform weaponView;

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
        
    }
}
