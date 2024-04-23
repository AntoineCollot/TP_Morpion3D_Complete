using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float maxRotation = 45;
    public float speed = 40;
    float currentAngle;

    void Update()
    {
        float input = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        currentAngle += input;
        currentAngle = Mathf.Clamp(currentAngle, -maxRotation, maxRotation);
        transform.rotation = Quaternion.Euler(currentAngle, 0,0);
    }
}

