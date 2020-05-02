using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    public Vector3 speed;
    void FixedUpdate()
    {
        transform.position += speed * Time.fixedDeltaTime;
    }
}
