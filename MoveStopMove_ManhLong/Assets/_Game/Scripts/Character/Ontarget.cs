using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontarget : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Enemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CacheString.TAG_PLAYER))
        {
            if (enemy.isDeath == false)
            {
                target.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(CacheString.TAG_PLAYER))
        {
            target.SetActive(false);
        }
    }

    private void OnDisable()
    {
        target.SetActive(false);
    }
}
