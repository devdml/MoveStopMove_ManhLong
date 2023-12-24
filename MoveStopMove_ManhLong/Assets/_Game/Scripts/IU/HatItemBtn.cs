using UnityEngine;
using UnityEngine.UI;

public class HatItemBtn : MonoBehaviour
{
    public HatType hatType;
    public HatType hatTypebtn;
    public Button hatButton;
    public MyDataPlayer player;
    public PlayerData playerData;
    public ShopSkinHead shopSkinHead;

    private void Start()
    {
        playerData = DataManager.Instance.playerData;

        shopSkinHead = GetComponentManager.Instance.shopSkinHead;
        player = GetComponentManager.Instance.myDataPlayer;
        hatButton.onClick.AddListener(SelectPriceItem);
    }

    public void SelectPriceItem()
    {
        if (playerData != null)
        {
            playerData.HatType = hatType;
        }
        
        for (int i = 0; i < player.hatDataSO.hatItemDatas.Count; i++)
        {
            if (hatType == player.hatDataSO.hatItemDatas[i].HatType)
            {
                if (player.hatDataSO.hatItemDatas[i].isUnlock == false)
                {
                    shopSkinHead.textPrice.text = player.hatDataSO.hatItemDatas[i].price.ToString();
                } 
                shopSkinHead.index = player.hatDataSO.hatItemDatas[i].id;
            }
        }
    }
}
