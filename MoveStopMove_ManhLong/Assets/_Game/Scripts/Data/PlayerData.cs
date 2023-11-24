public class PlayerData
{
    public WeaponType WeaponType;
    public float moveSpeed;
    public float range;

 
    public PlayerData(WeaponType weaponType, float moveSpeed, float range)
    {
        this.WeaponType = weaponType;
        this.moveSpeed = moveSpeed;
        this.range = range;
    }
}
    