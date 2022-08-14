using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    public GameObject player;
    public Vector3 direction;

    void Update()
    {
        direction = (player.transform.position - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
    }

}
