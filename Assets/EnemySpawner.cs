using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 1.5f;

    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    // Update is called once per frame
    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
        time -= 0.01f;
        if (time < 0.5f)
        {
            time = 0.5f;
        }
    }
}
