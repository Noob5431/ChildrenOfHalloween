using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milk : MonoBehaviour
{
    public float healAmount;
    public GameObject player;
    public Vector3 direction;
    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        player = FindObjectOfType<PlayerHealth>().gameObject;    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerHealth>().health < other.GetComponent<PlayerHealth>().maxHealth)
            {
                audioManager.Play("DrinkAlmondMilk");
                other.GetComponent<PlayerHealth>().giveDamage(-healAmount);
                Destroy(gameObject);
            }
        }
        
    }

    void Update()
    {
        direction = (player.transform.position - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(direction);
    }

}
