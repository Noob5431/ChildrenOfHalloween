using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public TextMeshPro healthText;
    public float maxHealth, distanceToPlayer;
    public float currentHealth;
    public bool isAggro;
    public GameObject player;
    NavMeshAgent enemyMeshAgent;
    LayerMask playerLayerMask;
    public float deathDelay;
    public bool isDying;

    void Start()
    {
        currentHealth = maxHealth;
        enemyMeshAgent = GetComponent<NavMeshAgent>();
        playerLayerMask = 1 << 6;
    }

    public float getHealth()
    {
        return currentHealth;
    }

    public void giveDamage(float damage)
    {
        currentHealth -= damage;
        if (gameObject.activeInHierarchy)
            healthText.text = ((currentHealth / maxHealth) * 100).ToString() + "%";
    }

    void Update()

    {
        if (currentHealth < 1 && !isDying)
            StartCoroutine("kill");
        RaycastHit ray;
        //Debug.DrawRay(transform.position, GetComponentInChildren<SpriteRotation>().direction * distanceToPlayer, Color.red);
        if (gameObject.activeSelf)
        {
            if (isAggro && !Physics.Raycast(transform.position, GetComponentInChildren<SpriteRotation>().direction, out ray, distanceToPlayer, playerLayerMask))
            {
                enemyMeshAgent.SetDestination(player.transform.position);
            }
            else
            {
                enemyMeshAgent.SetDestination(transform.position);
            }
        }
    }

    IEnumerator kill()
    {
        isDying = true;
        GetComponent<AudioSource>().Play();
        player.GetComponent<PlayerHealth>().enemiesInRange.Remove(gameObject.name);
        yield return new WaitForSeconds(deathDelay);
        gameObject.SetActive(false);
        yield break;
    }

    
}
