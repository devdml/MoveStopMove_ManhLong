using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    public WeaponType WeaponType;
    public GameObject bulletPrefab;
    public MyDataPlayer myDataPlayer;

    private void OnEnable()
    {
        myDataPlayer = GetComp.Instance.myDataPlayer;
        Debug.Log(this.WeaponType.ToString());

        for (int i = 0; i < 10; i++)
        {
            bulletPrefab.SetActive(false);
            Instantiate(bulletPrefab, myDataPlayer.holderWeapons);
        }

    }
}
