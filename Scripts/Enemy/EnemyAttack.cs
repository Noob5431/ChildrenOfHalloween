using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float rangedDamage, projSpeed, rangedAttackSpeed, timeToHit, leftTimeToHit;
    GameObject bullet;
    public GameObject magazine;
    public Animator animator;
    float timeLeftMelee, timeLeftRanged;

    void Start()
    {
        leftTimeToHit = timeToHit;
    }
    void Update()
    {

        timeLeftRanged -= Time.deltaTime;
        if (timeLeftRanged <= 0) timeLeftRanged = 0;

        if (timeLeftRanged == 0)
        {
            if (GetComponentInParent<Enemy>().isAggro)
            {
                leftTimeToHit -= Time.deltaTime;
                if (leftTimeToHit <= 0) leftTimeToHit = 0;
                animator.SetBool("startedAttacking", true);
                if (leftTimeToHit == 0)
                {
                    animator.SetBool("startedAttacking", false);
                    attackRanged();
                    timeLeftRanged = rangedAttackSpeed;
                    leftTimeToHit = timeToHit;
                }
            }
        }
    }

    void attackRanged()
    { 
        bullet = magazine.GetComponent<magScript>().getEnemyElement();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * projSpeed, ForceMode.Impulse);
        bullet.GetComponent<EnemyBullet>().damage = rangedDamage;

        
        Destroy(bullet, 10);

    }
}
