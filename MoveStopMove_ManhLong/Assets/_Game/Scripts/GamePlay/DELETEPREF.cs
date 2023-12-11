using UnityEditor;
using UnityEngine;

public class DELETEPREF : MonoBehaviour
{
    [MenuItem("Window/Delete PlayerPrefs (All)")]
    static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
