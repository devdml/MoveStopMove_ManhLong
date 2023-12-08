using UnityEngine;

public class TargetOn : MonoBehaviour
{
    public GameObject targetOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            targetOn.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            targetOn.SetActive(false);
        }
    }

}
