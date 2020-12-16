using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health, currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        currentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") //If enemy touches player
        {
            Debug.Log("Trigger");
            currentHealth -= 10;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "enemyBullet")
        {
            Debug.Log("Bullet hit player");
            currentHealth -= 20;
            Destroy(other.gameObject);
        }
    }
}
