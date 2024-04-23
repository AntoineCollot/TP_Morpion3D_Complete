using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayCube : MonoBehaviour
{
    public float speed = 40;

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.down * speed * input * Time.deltaTime);
    }
}
