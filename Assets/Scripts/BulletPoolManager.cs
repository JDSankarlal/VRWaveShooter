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
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
