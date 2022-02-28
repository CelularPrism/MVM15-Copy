using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SaberToolInterface
{
    public int upgradeCores { get; } // Count cores for Upgrade
    public int Attack(); // Return attack points
    public int Shoot(); // Return shoot points
    public int GetTimeReload();
    public int GetRange();
    public int GetShootRange();
    public SaberToolInterface Upgrade(int countCores); // Return next level for Saber Tool
}
