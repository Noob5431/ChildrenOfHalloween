using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_animation : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isNearPlayer", true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isNearPlayer", false);
        }
    }
}
