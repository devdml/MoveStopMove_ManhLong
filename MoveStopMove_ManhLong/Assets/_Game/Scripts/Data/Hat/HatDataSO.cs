using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HatDataSO")]
public class HatDataSO : ScriptableObject
{
    public List<HatItemData> hatItemDatas = new List<HatItemData>();
}

public enum HatType
{
    arrow = 0,
    cowbow = 1,
    crown = 2,
    ear = 3
}
