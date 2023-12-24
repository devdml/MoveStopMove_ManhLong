using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{
    public Button menu;

    public GameObject planeWinGame;
    public GameObject planeMainMenu;

    private void Start()
    {
        menu.onClick.AddListener(BackToMenu);
    }


    public void BackToMenu()
    {
        LevelManager.Instance.ResetPlayer();
        LevelManager.Instance.ResetEnemy();
        LevelManager.Instance.SpawnEnemy();
        GameManager.Instance.ChangeStage(GameState.MainMenu);
        planeMainMenu.SetActive(true);
        planeWinGame.SetActive(false);
    }
}