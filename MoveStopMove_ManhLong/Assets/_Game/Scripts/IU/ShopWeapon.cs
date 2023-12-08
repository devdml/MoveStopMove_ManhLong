using UnityEngine;
using UnityEngine.UI;

public class ShopWeapon : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    [SerializeField] private Transform pointSpawn;
    [SerializeField] private MyDataPlayer myDataPlayer;
    [SerializeField] private Button buttonNext;
    [SerializeField] private Button buttonPrevious;
    [SerializeField] private Button buttonSelect;

    private int index;

    public WeaponView item;

    private void Start()
    {
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
        myDataPlayer.weaponType = item.weaponType;
        myDataPlayer.SetDataPlayer();
        DataManager.Instance.ChangeWeapon(item.weaponType);
    }
}
