using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private int enemyCount;
    
    private int maxEnemy = 25;
    private int minEnemy;

    public List<Enemy> enemyList = new List<Enemy>();
    public int textMaxEnemy = 25;

    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        CheckMinMaxEnemy();
    }

    public void CheckWinGame()
    {
        if (textMaxEnemy == 0)
        {

        }
    }

    public void SpawnEnemy()
    {
        minEnemy = 10;
        enemyCount = 0;
        for (int i = 0; i < minEnemy; i++)
        {
            Enemy enemySpawm = LeanPool.Spawn(enemy, RandomNavSphere(Vector3.zero, 40f, -1), Quaternion.identity);
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

    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
