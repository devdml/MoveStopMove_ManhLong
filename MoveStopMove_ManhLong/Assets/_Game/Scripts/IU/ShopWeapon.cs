using UnityEngine;
using UnityEngine.UI;

public class ShopWeapon : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    [SerializeField] private Character character;
    [SerializeField] private Transform pointSpawn;
    [SerializeField] private MyDataPlayer myDataPlayer;
    [SerializeField] private Button buttonNext;
    [SerializeField] private Button buttonPrevious;
    [SerializeField] private Button buttonSelect;

    private PlayerData playerData;
    private int index;

    public WeaponView item;

    private void Start()
    {
        playerData = dataManager.GetPlayerData();
        index = 0;
        buttonNext.onClick.AddListener(ChangeItemNext);
        buttonPrevious.onClick.AddListener(ChangeItemPrevious);
        buttonSelect.onClick.AddListener(SelectItem);
        SpawnItemWeapon(index);
    }

    private void ChangeItemNext()
    {
        index++;
        if (index < dataManager.weaponDataOS.weapons.Count)
        {
            Destroy(item.gameObject);
            SpawnItemWeapon(index);
        }
        else
        {
            index = 0;
            Destroy(item.gameObject);
            SpawnItemWeapon(index);
        }

    }

    private void ChangeItemPrevious()
    {
        index--;
        if (index < 0)
        {
            index = dataManager.weaponDataOS.weapons.Count - 1;
            Destroy(item.gameObject);
            SpawnItemWeapon(index);
        }
        else
        {
            Destroy(item.gameObject);
            SpawnItemWeapon(index);
        }
    }

    private void SpawnItemWeapon(int index)
    {
        item = Instantiate(dataManager.weaponDataOS.weapons[index].weaponSkin, pointSpawn);

    }

    private void SelectItem()
    {
        playerData.WeaponType = item.weaponType;
        myDataPlayer.weaponType = playerData.WeaponType;

        if (myDataPlayer.myWeapon != null)
        {
            Destroy(myDataPlayer.myWeapon.gameObject);
        }

        myDataPlayer.myWeapon = Instantiate(myDataPlayer.weaponDataOS.weapons[index].weaponSkin, myDataPlayer.pointWeapon);
        character.bulletPrefab = myDataPlayer.weaponDataOS.weapons[index].bulletPrefab;

        DataManager.Instance.ChangeWeapon(item.weaponType);
    }
}
