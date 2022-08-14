using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float volume;
    public List<string> enemiesInRange;
    public float health, maxHealth, sanity, maxSanity;
    public GameObject deathPanel;
    public xp cXp;
    public Image damagePanel;
    public float maxDamageTransp, damageEffectSpeed;
    float cDamageTransp;
    public Color redColor = new Color(255,0,0), greenColor = new Color(204,204,255);
    AudioManager audioManager;
    public bool isInCombat;
    bool oldCombat;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        health = maxHealth;
        sanity = maxSanity;
    }

    void Update()
    {
        if (enemiesInRange.Count == 0)
        {
            isInCombat = false;
        }
        else isInCombat = true;

        if (health<0)
        {
            deathPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true ;
            audioManager.GetComponent<AudioListener>().enabled = true;
            audioManager.Play("DeathPlayer");
            gameObject.SetActive(false);
        }
        cXp.health = health;
        cXp.sanity = sanity;

        cDamageTransp -= damageEffectSpeed * Time.deltaTime;
        if (cDamageTransp < 0)
            cDamageTransp = 0;
        if (cDamageTransp > maxDamageTransp)
            cDamageTransp = maxDamageTransp;
        damagePanel.color = new Color(damagePanel.color.r, damagePanel.color.g, damagePanel.color.b, cDamageTransp);

        if (isInCombat != oldCombat)
        {
            oldCombat = isInCombat;
            if (isInCombat)
            {
                audioManager.getSound("InGame").source.volume = 0;
                audioManager.getSound("Combat").source.volume = volume;
            }
            else
            {
                audioManager.getSound("Combat").source.volume = 0;
                audioManager.getSound("InGame").source.volume = volume;
            }
        }
    }

    public void giveDamage(float damage)
    {
        if (damage>0)
            damagePanel.color = new Color(redColor.r, redColor.g, redColor.b, damagePanel.color.a);
        else damagePanel.color = new Color(greenColor.r, greenColor.g, greenColor.b, damagePanel.color.a);
        health -= damage;
        cDamageTransp += damageEffectSpeed;
    }

}
