using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{

    public static CamerasController instance = null;

    [SerializeField] private Transform player;

    [SerializeField] private GameObject TPcamera;

    void Start()
    {
        TPcamera.transform.parent = player;
    }

}

