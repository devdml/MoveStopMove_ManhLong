using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject weaponShopCanvas;

    public Button weaponShopBtn;
    public Button startBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(ButtonStart);
        weaponShopBtn.onClick.AddListener(ButtonWeaponShop);
    }

    private void ButtonStart()
    {
        GameManager.Instance.ChangeStage(GameState.GamePlay);
        mainMenuCanvas.SetActive(false);
    }

    private void ButtonWeaponShop()
    {
        mainMenuCanvas.SetActive(false);
        weaponShopCanvas.SetActive(true);

    }
}
