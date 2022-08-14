using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float meleeDamage, projSpeed, meleeAttackSpeed, rangedAttackSpeed;
    public float timeToHitMelee,timeToHitRanged;
    public EnemyManager enemyManager;
    GameObject bullet;
    public Animator weaponAnimator;
    PlayerHealth playerHealth;
    AudioManager audioManager;

    public GameObject magazine;

    bool isAttacking = false;
    public bool isRanged = false;
    float timeLeftMelee, timeLeftRanged;

    void Start()
    {
        timeLeftMelee = 0;
        timeLeftRanged = 0;
        playerHealth = FindObjectOfType<PlayerHealth>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        for (int i = 0; i < enemyManager.enemiesInCollider.Count; i++)
        {
            if (!enemyManager.enemiesInCollider[0].activeInHierarchy)
            {
                enemyManager.enemiesInCollider.RemoveAt(i);
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
            isRanged = true;
        else isRanged = false;

        weaponAnimator.SetBool("isRanged", isRanged);

        timeLeftMelee -= Time.deltaTime;
        timeLeftRanged -= Time.deltaTime;
        if (timeLeftMelee <= 0) timeLeftMelee = 0;
        if (timeLeftRanged <= 0) timeLeftRanged = 0;

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            if (!isRanged)
            {
                if (timeLeftMelee == 0)
                {
                    isAttacking = true;
                    weaponAnimator.SetBool("isAttacking", true);
                    StartCoroutine(attackMelee());
                }
            }
            else
            {
                if (timeLeftRanged == 0 && playerHealth.sanity>0)
                {
                    StartCoroutine(attackRanged());
                    isAttacking = true;
                    weaponAnimator.SetBool("isRangedAttacking", true);
                }
            }
         }
    }

    IEnumerator attackMelee()
    {
        
        if (enemyManager.enemiesInCollider.Count > 0)
            audioManager.Play("MeleeOnTarget");
        else audioManager.Play("Melee");
        yield return new WaitForSeconds(timeToHitMelee);
        weaponAnimator.SetBool("isAttacking", false);

        
        foreach (GameObject cGameObject in enemyManager.enemiesInCollider)
        {
                cGameObject.GetComponentInParent<Enemy>().giveDamage(meleeDamage);
        }
        timeLeftMelee = meleeAttackSpeed;
        isAttacking = false;
    }

    IEnumerator attackRanged()
    {
        audioManager.Play("Shot");
        
        yield return new WaitForSeconds(timeToHitRanged);
        weaponAnimator.SetBool("isRangedAttacking", false);
        playerHealth.sanity--;
        bullet = magazine.GetComponent<magScript>().getPlayerElement();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward  * projSpeed + GetComponentInParent<Rigidbody>().velocity.normalized * 10, ForceMode.Impulse);

        timeLeftRanged = rangedAttackSpeed;
        Destroy(bullet, 10);
        isAttacking = false;
        
    }
}
