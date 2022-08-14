using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage,delay;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "debug" || other.tag == "Player" || other.tag == "bullet" || other.tag == "NPC")
            return;
        if (other.tag == "Enemy")
            other.GetComponentInParent<Enemy>().giveDamage(damage);
        GetComponent<VisualEffect>().SetFloat("isHit",2f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject,delay);
    }
}
