using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemiesInCollider = new List<GameObject>();
    public TextPopUp textPopUp;

    void OnTriggerEnter (Collider enemyCollider)
    {
        if (enemyCollider.tag == "Enemy")
            enemiesInCollider.Add(enemyCollider.gameObject);
        if (enemyCollider.tag == "NPC")
        {
            textPopUp.collision(enemyCollider, false);
        }
    }
    void OnTriggerExit(Collider enemyCollider)
    {
        if (enemyCollider.tag == "Enemy")
            enemiesInCollider.Remove(enemyCollider.gameObject);
        if (enemyCollider.tag == "NPC")
        {
            textPopUp.collision(enemyCollider, true);
        }
    }

 
}
