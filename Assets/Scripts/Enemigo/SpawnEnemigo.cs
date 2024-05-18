using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public float spawnInterval = 5f;  

    public GameObject punto1;
    public GameObject punto2;
    private int punto;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            punto = Random.Range(1,3);

            if(punto == 1)
            {
                Instantiate(enemyPrefab, punto1.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyPrefab, punto2.transform.position, Quaternion.identity);
            }
        }
    }
}
