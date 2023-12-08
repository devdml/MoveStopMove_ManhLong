using UnityEngine;

public class Money : MonoBehaviour
{
    public int myMonet = 100;

    private void Start()
    {
        PlayerPrefs.SetInt("MyMoney", myMonet);
    }

    //public void AddCurrency(Type gold, int quantity)
    //{
    //    PlayerPrefs.SetInt(gold.ToString, quantity);

    //}
}
