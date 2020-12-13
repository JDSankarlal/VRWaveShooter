using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletSpeed;
    public BulletPoolManager bulletPoolManager;
    public InputManager inputScript;

    // Start is called before the first frame update
    void Start()
    {
       bulletSpeed = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
       CheckReset();        
    }

    IEnumerator CheckReset()
    {
        yield return new WaitForSeconds(2.0f);
        bulletPoolManager.ResetBullet(this.gameObject);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }

    void OnEnable()
    {
       StartCoroutine(CheckReset());
       this.GetComponent<Rigidbody>().AddForce(GameObject.Find("LeftHand Controller").transform.forward * bulletSpeed);
    }
    
    void OnDisable()
    {
        StopCoroutine(CheckReset());
    }
}

