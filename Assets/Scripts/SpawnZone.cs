using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> spawns;
    public int childCount, enemiesToSpawn, currentSpawnCount, waveCount, enemiesDestroyedThisWave;
    // Start is called before the first frame update
    void Start()
    {
        addSpawnsToArray();
        waveCount = 1;
        enemiesToSpawn = 2;
        currentSpawnCount = 0;
        enemiesDestroyedThisWave = 0;
        checkWaveIncrease();
        spawnEnemy();
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        checkWaveIncrease();
    }

    void addSpawnsToArray()
    {
        childCount = this.gameObject.transform.childCount;
        spawns = new List<GameObject>();
        for (int i = 0; i < childCount; i++)
        {
            spawns.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
    }

    GameObject randomlySelectSpawn()
    {
        GameObject spawnPoint = spawns[Random.Range(0, childCount)];
        return spawnPoint;
    }

    void checkWaveIncrease()
    {
        if (currentSpawnCount == enemiesToSpawn && enemiesDestroyedThisWave == currentSpawnCount) //If all enemies to spawn have been spawned, and all spawned enemies have been killed
        {
            nextWave();
        }
    }

    void nextWave()
    {
        waveCount++;
        enemiesToSpawn = 2 * waveCount;
        currentSpawnCount = 0;
        enemiesDestroyedThisWave = 0;
    }

    void resetSpawnFunction()
    {
        StopCoroutine("spawnEnemy");
        StartCoroutine("spawnEnemy");
    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {

            yield return new WaitForSeconds(2f);
            if (currentSpawnCount < enemiesToSpawn)
            {
                GameObject selectedSpawnPoint = randomlySelectSpawn();
                GameObject spawnedEnemy = (GameObject)Instantiate(enemy, GameObject.Find("Enemies").transform);
                spawnedEnemy.transform.position = (Random.insideUnitSphere * 3) + selectedSpawnPoint.transform.position;

                if (spawnedEnemy.transform.position.y <= 0 || spawnedEnemy.transform.position.y > 1)
                {
                    spawnedEnemy.transform.position = new Vector3(spawnedEnemy.transform.position.x, 1, spawnedEnemy.transform.position.z);
                }

                if (Physics.CheckSphere(selectedSpawnPoint.transform.position, 1))
                {
                    Debug.Log("Spawn too close. Delaying spawn.");
                    Destroy(spawnedEnemy.gameObject);
                    continue;
                }
                currentSpawnCount++;
                //spawnedEnemy.transform.LookAt(GameObject.FindWithTag("MainCamera").transform.position);
            }

        }
    }

}
