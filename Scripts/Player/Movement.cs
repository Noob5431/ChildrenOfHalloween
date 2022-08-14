using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed;
    Rigidbody playerRigidbody;
    Vector3 inputVector;
    Animator anim;
    bool isWalking;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputVector *= Time.deltaTime * 1000;
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);
        
        playerRigidbody.velocity = inputVector * playerSpeed  + new Vector3(0,playerRigidbody.velocity.y,0);

        //Debug.Log(playerRigidbody.velocity);
        if (inputVector.x != 0 || inputVector.y != 0)
            isWalking = true;
        else isWalking = false;
        anim.SetBool("isWalking", isWalking);
    }

}
