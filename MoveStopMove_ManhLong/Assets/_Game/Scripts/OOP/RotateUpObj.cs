using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateUpObj : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
