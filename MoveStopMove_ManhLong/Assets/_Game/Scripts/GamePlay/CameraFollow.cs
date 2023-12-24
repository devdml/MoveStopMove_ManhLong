using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public Vector3 offset = new Vector3(0, 0, 0);


    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
