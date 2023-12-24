using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour
{
    [SerializeField] private Button menu;
    [SerializeField] private GameObject canvasLose;
    [SerializeField] private GameObject mainMenu;

    public TextMeshProUGUI text;

    private int eneCount;

    private void OnEnable()
    {
        eneCount = LevelManager.Instance.textMaxEnemy + 1;

        text.text = eneCount.ToString();

        menu.onClick.AddListener(BackToMenu);
    }
    public void BackToMenu()
    {
        LevelManager.Instance.ResetPlayer();
        LevelManager.Instance.ResetEnemy();
        LevelManager.Instance.SpawnEnemy();
        LevelManager.Instance.ResetTextSpawn();
        GameManager.Instance.ChangeStage(GameState.MainMenu);
        canvasLose.SetActive(false);
        mainMenu.SetActive(true);
    }
}
