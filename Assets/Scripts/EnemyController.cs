using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject player, enemyBullet, bulletSpawn, playerRig;
    SpawnZone spawnZone;
    private Vector3 bulletPath;
    public float bulletSpeed, enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
        playerRig = GameObject.Find("XR Rig");
        spawnZone = GameObject.Find("Spawn").GetComponent<SpawnZone>();
        StartCoroutine(fireTime());
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardPlayer();
    }

    void fireBullet()
    {
        GameObject obj = (GameObject)Instantiate(enemyBullet);
        obj.transform.SetParent(this.gameObject.transform);
        obj.transform.position = bulletSpawn.transform.position;

        Vector3 bulletPath = Vector3.Normalize((player.transform.position) - (bulletSpawn.transform.position));

        obj.GetComponent<Rigidbody>().AddForce(bulletPath * bulletSpeed, ForceMode.Force);
        //Debug.Log(bulletPath);
    }

    IEnumerator fireTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            fireBullet();
        }
    }

    void moveTowardPlayer()
    {
        //this.transform.LookAt(playerRig.transform);
        //this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.Normalize(player.transform.position - this.transform.position * enemySpeed), ForceMode.Force);
        this.transform.position += (Vector3.Normalize(player.transform.position - this.transform.position) * enemySpeed * Time.deltaTime);
    }

    void OnDestroy()
    {
        spawnZone.enemiesDestroyedThisWave++;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
