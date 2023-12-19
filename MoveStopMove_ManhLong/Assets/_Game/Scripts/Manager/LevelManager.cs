using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<Enemy> enemyList = new List<Enemy>();
    [SerializeField] private Enemy enemy;
    [SerializeField] private int enemyCount;
    
    private int maxEnemy;
    private int minEnemy;

    private void Start()
    {
        SpawnEnemy();
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

    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
