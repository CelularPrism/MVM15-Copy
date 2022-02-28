class SaberToolLvl1 : SaberToolInterface
{
    private int damageAttack = 1;
    private int range = 2;

    private int damageShoot = 0;
    private int timeReload = 0;
    private int shootRange = 0;

    public int upgradeCores { get; } = 2; // Count cores for Upgrade
    private SaberToolInterface nextLvl = new SaberToolLvl2();
    
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
        if (countCores >= upgradeCores)
            return nextLvl;
        else
            return null;
    }
}
