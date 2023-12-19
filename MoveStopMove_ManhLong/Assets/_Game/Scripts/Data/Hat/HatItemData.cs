using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class HatItemData
{
    public int id;
    public HatType HatType;
    public int price;
    public HatView hatView;
    public Button hatBtn;
    public bool isUnlock;
}
