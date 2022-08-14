using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magScript : MonoBehaviour
{
    public int magSize;
    public GameObject playerOrbPrefab, enemyOrbPrefab;
    public GameObject[] playerOrbs;
    public GameObject[] enemyOrbs;
    public int pCursor, eCursor;

    void Start()
    {
        playerOrbs = new GameObject[magSize];
        enemyOrbs = new GameObject[magSize];
        for (int i = 0; i < magSize; i++) 
        {
            addPlayerOrb(i);
            addEnemyOrb(i);
        }
        pCursor = 0;
        eCursor = 0;
    }

    public void addPlayerOrb(int i)
    {
        GameObject orb = Instantiate(playerOrbPrefab, transform.position, transform.rotation);
        playerOrbs[i] = orb;
    }
    public void addEnemyOrb(int i)
    {
        GameObject orb = Instantiate(enemyOrbPrefab, transform.position, transform.rotation);
        enemyOrbs[i] = orb;
    }

    public GameObject getPlayerElement()
    {
        if (pCursor == magSize)
            pCursor = 0;
        GameObject cOrb = playerOrbs[pCursor];
        pCursor--;
        if (pCursor == -1)
            pCursor = magSize-1;
     
        playerOrbs[pCursor] = Instantiate(playerOrbPrefab, transform.position, transform.rotation);
        pCursor++;
        if (pCursor == magSize)
            pCursor = 0;
        pCursor++;
        return cOrb;
    }

    public GameObject getEnemyElement()
    {
        if (eCursor == magSize)
            eCursor = 0;
        GameObject cOrb = enemyOrbs[eCursor];
        eCursor--;
        if (eCursor == -1)
            eCursor = magSize-1;
        enemyOrbs[eCursor] = Instantiate(enemyOrbPrefab, transform.position, transform.rotation);
        eCursor++;
        if (eCursor == magSize)
            eCursor = 0;
        eCursor++;
        return cOrb;
    }
}
