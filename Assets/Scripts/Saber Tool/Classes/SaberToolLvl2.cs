class SaberToolLvl2 : SaberToolInterface
{
    private int damageAttack = 2;
    private int range = 3;

    private int damageShoot = 5;
    private int timeReload = 8;
    private int shootRange = 6;

    public int upgradeCores { get; } = 3;
    private SaberToolInterface nextLvl = new SaberToolLvl3();
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
