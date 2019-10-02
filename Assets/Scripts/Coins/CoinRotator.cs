using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{

    private float speed = 70f;
    
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime, Space.Self);
    }
}
