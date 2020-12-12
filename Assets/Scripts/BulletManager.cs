using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletSpeed = 1000f;
    public BulletPoolManager bulletPoolManager;
    public InputManager inputScript;

    // Start is called before the first frame update
    void Start()
    {
        bulletPoolManager = GameObject.FindWithTag("Manager").GetComponent<BulletPoolManager>();
        inputScript = GameObject.Find("InputManager").GetComponent<InputManager>();     
        
         StartCoroutine(CheckReset());
         
    }

    // Update is called once per frame
    void Update()
    {
       MoveBullet();
       CheckReset();        
    }

    IEnumerator CheckReset()
    {
        yield return new WaitForSeconds(2.0f);
        bulletPoolManager.ResetBullet(this.gameObject);
    }

    void MoveBullet()
    {
        this.GetComponent<Rigidbody>().AddForce(inputScript.leftControllerObject.transform.forward * bulletSpeed, ForceMode.Force);

    }
    
}

