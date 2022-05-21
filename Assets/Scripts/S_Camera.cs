using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Camera : MonoBehaviour
{
    [SerializeField] float Sensitivity = 100f;
    [SerializeField] Transform Player;
    float RotationX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        RotationX -= MouseY;
        RotationX = Mathf.Clamp(RotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(RotationX, 0,0);
        Player.Rotate(Vector3.up * MouseX);
    }
}
