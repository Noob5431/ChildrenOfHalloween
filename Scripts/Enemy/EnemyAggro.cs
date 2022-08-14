using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("bullet"))
        {
            GetComponentInParent<Enemy>().isAggro = true;
            if (!GetComponentInParent<Enemy>().isDying && player.enemiesInRange.Find(a => a == gameObject.transform.parent.gameObject.name) == null)
                player.enemiesInRange.Add(gameObject.transform.parent.gameObject.name);
        }
    }
}
