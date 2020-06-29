using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickUp : MonoBehaviour
{
    
    public float xSpeed, ySpeed, zSpeed;
    void Update()
    {
        transform.Rotate(xSpeed, ySpeed, zSpeed, Space.World);
    }
}
