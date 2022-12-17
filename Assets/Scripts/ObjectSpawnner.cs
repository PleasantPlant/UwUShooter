using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemySpawn;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnSpacing = 3f;
    [SerializeField] private float spawned;
    [SerializeField] private int spawnLimit;



    public void spawnEnemy()
    {
        GameObject spawnedEnemy = GameObject.Instantiate(
            enemy,
            enemySpawn.transform.position,
            Quaternion.identity,
            transform
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnSpacing && spawned < spawnLimit)
        {
            spawned += 1;
            spawnEnemy();
            spawnTimer = 0f;

        }

    }
}
