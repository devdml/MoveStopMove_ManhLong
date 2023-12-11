public class PlayerData
{
    public WeaponType WeaponType;
    public HatType HatType;
    public float moveSpeed;
    public float range;

 
    public PlayerData(WeaponType weaponType, HatType hatType,float moveSpeed, float range)
    {
        this.HatType = hatType;
        this.WeaponType = weaponType;
        this.moveSpeed = moveSpeed;
        this.range = range;
    }
}
    