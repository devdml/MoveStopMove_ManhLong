using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatItemBtn : MonoBehaviour
{
    public HatType hatType;
    public Button hatButton;
    public  MyDataPlayer player;

    private void Start()
    {
        player = GetComponentManager.Instance.myDataPlayer;
        hatButton.onClick.AddListener(SelectButton);
    }

    public void SelectButton()
    {
        Debug.Log(hatType.ToString());
        player.hatType = hatType;
        DataManager.Instance.changeHat(hatType);
        player.SetDataPlayer();
    }
}
