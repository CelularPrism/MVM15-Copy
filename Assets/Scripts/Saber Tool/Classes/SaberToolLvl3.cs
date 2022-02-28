class SaberToolLvl3 : SaberToolInterface
{
    private int damageAttack = 2;
    private int range = 3;

    private int damageShoot = 6;
    private int timeReload = 5;
    private int shootRange = 6;
    public int upgradeCores { get; } = 0;
    
    // Return attack points
    public int Attack()
    {
        return damageAttack;
    }

    // Return shoot points
    public int Shoot()
    {
        return damageShoot;
    }
    public int GetTimeReload()
    {
        return timeReload;
    }
    public int GetRange()
    {
        return range;
    }
    public int GetShootRange()
    {
        return shootRange;
    }

    // Return next level for Saber Tool or null
    public SaberToolInterface Upgrade(int countCores)
    {
        return null;
    }
}