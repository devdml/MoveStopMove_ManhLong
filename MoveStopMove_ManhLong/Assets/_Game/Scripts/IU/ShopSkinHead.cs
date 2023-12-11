using UnityEngine;
using UnityEngine.UI;

public class ShopSkinHead : MonoBehaviour
{
    [Header("Btn")]
    public Button hatBtn;
    public Button pantBtn;
    public Button shieldBtn;
    public Button setBtn;

    [Header("Panel")]
    public GameObject hatPanel;
    public GameObject pantPanel;
    public GameObject shieldPanel;
    public GameObject setPanel;

    [Header("Data")]
    public HatDataSO hatDataSO;
    public Transform HatPoint;
    

    private void Start()
    {
        LoadItemHatBtn();
        hatBtn.onClick.AddListener(Hatbtn);
        pantBtn.onClick.AddListener(PanBtn);
        shieldBtn.onClick.AddListener(ShieldBtn);
        setBtn.onClick.AddListener(SetBtn);
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
}
