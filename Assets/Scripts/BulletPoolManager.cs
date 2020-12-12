using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
    public int POOL_SIZE;
    public List<GameObject> bulletPool;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new List<GameObject>();
        for (int i=0;i<POOL_SIZE;i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet, this.gameObject.transform);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
    }

    public GameObject GetBullet()
    {
        GameObject bullet = bulletPool[0];
        bulletPool.RemoveAt(0);
        bullet.SetActive(true);
        return bullet;
    }

    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Add(bullet);
    }

 
}
