using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShopSkinHead : MonoBehaviour
{
    [Header("Btn")]
    public Button hatBtn;
    public Button pantBtn;
    public Button shieldBtn;
    public Button setBtn;
    public Button buy;

    [Header("Panel")]
    public GameObject hatPanel;
    public GameObject pantPanel;
    public GameObject shieldPanel;
    public GameObject setPanel;

    [Header("Data")]
    public int index;
    public HatDataSO hatDataSO;
    public Transform HatPoint;
    public MyDataPlayer player;
    public TextMeshProUGUI textPrice;
    public PlayerData playerData;
    public HatType hatTypebtn;


    private void Start()
    {
        playerData = DataManager.Instance.playerData;

        LoadItemHatBtn();
        hatBtn.onClick.AddListener(Hatbtn);
        pantBtn.onClick.AddListener(PanBtn);
        shieldBtn.onClick.AddListener(ShieldBtn);
        setBtn.onClick.AddListener(SetBtn);
        buy.onClick.AddListener(BuyItem);
    }


    private void Hatbtn()
    {
        hatPanel.SetActive(true);
        pantPanel.SetActive(false);
        shieldPanel.SetActive(false);
        setPanel.SetActive(false);
    }

    private void PanBtn()
    {
        hatPanel.SetActive(false);
        pantPanel.SetActive(true);
        shieldPanel.SetActive(false);
        setPanel.SetActive(false);
    }

    private void ShieldBtn()
    {
        hatPanel.SetActive(false);
        pantPanel.SetActive(false);
        shieldPanel.SetActive(true);
        setPanel.SetActive(false);
    }

    private void SetBtn()
    {
        hatPanel.SetActive(false);
        pantPanel.SetActive(false);
        shieldPanel.SetActive(false);
        setPanel.SetActive(true);
    }

    public void LoadItemHatBtn()
    {
        for (int i = 0; i < hatDataSO.hatItemDatas.Count; i++)
        {
            Instantiate(hatDataSO.hatItemDatas[i].hatBtn, HatPoint);
        }
    }

    public void BuyItem()
    {
        hatTypebtn = playerData.HatType;    

        for (int i = 0; i < player.hatDataSO.hatItemDatas.Count; i++)
        {
            if (hatTypebtn == player.hatDataSO.hatItemDatas[i].HatType)
            {
                Debug.Log(hatTypebtn);

                if (PlayerPrefs.GetInt(CacheString.TAG_COIN, Money.Instance.myMonet) >= player.hatDataSO.hatItemDatas[i].price)
                {
                    if (player.hatDataSO.hatItemDatas[i].isUnlock == false)
                    {
                        if (player.myHat != null)
                        {
                            Destroy(player.myHat.gameObject);
                        }

                        player.myHat = Instantiate(player.hatDataSO.hatItemDatas[i].hatView, player.pointHat);
                        PlayerPrefs.SetInt(CacheString.TAG_COIN, (PlayerPrefs.GetInt(CacheString.TAG_COIN, Money.Instance.myMonet) - player.hatDataSO.hatItemDatas[i].price));
                        Money.Instance.SetTextCoin();
                        player.hatDataSO.hatItemDatas[i].isUnlock = true;
                    }      
                }

                DataManager.Instance.changeHat(hatTypebtn);
            }
        }
    }
}
