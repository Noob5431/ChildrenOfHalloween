using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity,smoothness, xClamp, yClamp;
    Transform parentTransform;
    Vector2 rotation = Vector2.zero;

    private void Start()
    {
        parentTransform = transform.parent.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        rotation.x += Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime * 1000;
        rotation.y += Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime * 1000;

        //rotation.x = Mathf.Clamp(rotation.x, -xClamp, xClamp);
        rotation.y = Mathf.Clamp(rotation.y, -yClamp, yClamp);

        parentTransform.localEulerAngles = new Vector2(0,rotation.x);
        transform.localEulerAngles = new Vector2(-rotation.y, 0);
    }
}
