using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject weaponShopCanvas;
    public GameObject skinShopCanvas;
    public GameObject backHome;

    public Button weaponShopBtn;
    public Button startBtn;
    public Button skinBtn;
    public Button backHomeBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(ButtonStart);
        weaponShopBtn.onClick.AddListener(ButtonWeaponShop);
        skinBtn.onClick.AddListener(ButtonSkinShop);
        backHomeBtn.onClick.AddListener(ButtonBackHome);
    }

    private void ButtonStart()
    {
        GameManager.Instance.ChangeStage(GameState.GamePlay);
        backHome.SetActive(false);
        mainMenuCanvas.SetActive(false);
    }

    private void ButtonWeaponShop()
    {
        mainMenuCanvas.SetActive(false);
        backHome.SetActive(true);
        weaponShopCanvas.SetActive(true);
    }

    private void ButtonSkinShop()
    {
        backHome.SetActive(true);
        mainMenuCanvas.SetActive(false);
        skinShopCanvas.SetActive(true);
    }

    private void ButtonBackHome()
    {
        backHome.SetActive(false);
        mainMenuCanvas.SetActive(true);
        skinShopCanvas.SetActive(false);
        weaponShopCanvas.SetActive(false);
    }
}
