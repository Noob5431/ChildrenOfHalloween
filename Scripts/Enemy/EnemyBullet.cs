using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage,delay;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "debug" || other.tag == "Enemy" || other.tag == "bullet")
            return;
        if (other.tag == "Player")
            other.GetComponent<PlayerHealth>().giveDamage(damage);
        
        if (other.CompareTag("Player"))
            Destroy(gameObject);
        else
        {
            GetComponent<AudioSource>().Play();
            GetComponent<VisualEffect>().SetFloat("isHit", 2f);
            Destroy(gameObject, delay);
        }
    }
}
