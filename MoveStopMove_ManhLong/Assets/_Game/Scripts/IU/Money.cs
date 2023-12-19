using TMPro;
using UnityEngine;

public class Money : Singleton<Money>
{
    public int myMonet;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        myMonet = PlayerPrefs.GetInt(CacheString.TAG_COIN, myMonet);
        PlayerPrefs.SetInt(CacheString.TAG_COIN, myMonet);
        coinText.text = myMonet.ToString();

    }

    public void SetTextCoin()
    {
        myMonet = PlayerPrefs.GetInt(CacheString.TAG_COIN, myMonet);
       coinText.text = myMonet.ToString();
    }

    //private void Update()
    //{
    //    myMonet = PlayerPrefs.GetInt(CacheString.TAG_COIN, myMonet);
    //    coinText.text = myMonet.ToString();
    //}

    //public void AddCurrency(Type gold, int quantity)
    //{
    //    PlayerPrefs.SetInt(gold.ToString, quantity);

    //}
}
