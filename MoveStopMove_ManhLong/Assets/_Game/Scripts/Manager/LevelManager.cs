using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private int enemyCount;
    [SerializeField] private Player player;
    [SerializeField] LevelDataSO levelDataSO;
    [SerializeField] Button nextLevel;
    [SerializeField] Transform playerSpawn;
    [SerializeField] GameObject disJoyStick;
    [SerializeField] private float rangeSpawnEnemy;
    
    private int maxEnemy;
    private int minEnemy;

    public List<Enemy> enemyList = new List<Enemy>();
    public int textMaxEnemy;
    public GameObject canvasWin;
    public GameObject canvasLose;
    public int indexLevel;
    public GameObject spawnMap;
    public bool playerIsDead;

    private void Start()
    {
        SpawnEnemy();
        Oninit();
        nextLevel.onClick.AddListener(SpawnMapLevel);
    }

    private void Update()
    {
        if (GameManager.Instance.IsStage(GameState.GamePlay))
        {
            if (enemyList.Count <= 0)
            {
                disJoyStick.SetActive(false);
                CheckWinGame();
            }
        }
        
        if (playerIsDead == true)
        {
            disJoyStick.SetActive(false);
            player.ChangeAnim(CacheString.ANIM_DEAD);
            CheckLoseGame();
        }

       StartCoroutine(DelaySpwanEnemy());
    }

    public void CheckWinGame()
    {
        GameManager.Instance.ChangeStage(GameState.MainMenu);
        canvasWin.SetActive(true);
    }

    public void CheckLoseGame()
    {
        GameManager.Instance.ChangeStage(GameState.MainMenu);
        canvasLose.SetActive(true);
    }

    public void SpawnEnemy()
    {
        minEnemy = 5;
        enemyCount = 0;
        for (int i = 0; i < minEnemy; i++)
        {
            Enemy enemySpawm = LeanPool.Spawn(enemy, RandomNavSphere(Vector3.zero, rangeSpawnEnemy, -1), Quaternion.identity);
            enemyList.Add(enemySpawm);
            enemyCount++;
        }
    }

    public void CheckMinMaxEnemy()
    {
        if (enemyCount == maxEnemy)
        {
            return;
        }

        if (enemyList.Count < minEnemy)
        {
            for (int i = enemyList.Count; i < minEnemy; i++)
            {
                Enemy enemySpawm = LeanPool.Spawn(enemy, RandomNavSphere(Vector3.zero, 40f, -1), Quaternion.identity);
                enemyList.Add(enemySpawm);
                enemyCount++;
            }
        }
    }

    IEnumerator DelaySpwanEnemy()
    {
        yield return new WaitForSeconds(3);
        CheckMinMaxEnemy();
    }

    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void Oninit()
    {
        playerIsDead = false;
        indexLevel = 0;
        spawnMap = Instantiate(levelDataSO.levelData[indexLevel].mapLevel, transform.position, transform.rotation);
        maxEnemy = levelDataSO.levelData[indexLevel].maxEnemy;
        player.transform.position = playerSpawn.position;
        textMaxEnemy = maxEnemy;
    }

    public void ResetPlayer()
    {
        player.target = null;
        player.listTarget.Clear();
        player.isDeath = false;
        playerIsDead = false;
        player.ChangeAnim(CacheString.ANIM_IDLE);
        player.transform.position = playerSpawn.position;
    }

    public void ResetEnemy()
    {
        enemy.isDeath = false;
        enemyList.Clear();
        enemy.ChangeAnim(CacheString.ANIM_IDLE);
        LeanPool.DespawnAll();
    }

    public void ResetTextSpawn()
    {
        textMaxEnemy = levelDataSO.levelData[indexLevel].maxEnemy;
    }

    public void SpawnMapLevel()
    {
        canvasWin.SetActive(false);
        if (indexLevel < levelDataSO.levelData.Count - 1    )
        {
            indexLevel++;     
        } else
        {
            indexLevel = 0;            
        }

        if (spawnMap != null)
        {
            Destroy(spawnMap.gameObject);
        }
        spawnMap = Instantiate(levelDataSO.levelData[indexLevel].mapLevel, transform.position, transform.rotation);
        maxEnemy = levelDataSO.levelData[indexLevel].maxEnemy;
        textMaxEnemy = levelDataSO.levelData[indexLevel].maxEnemy;
        ResetEnemy();
        ResetPlayer();
        SpawnEnemy();
        GameManager.Instance.ChangeStage(GameState.GamePlay);
    }
}
