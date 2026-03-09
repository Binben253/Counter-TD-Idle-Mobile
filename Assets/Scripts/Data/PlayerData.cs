using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//HELPER//
[System.Serializable]
public class ArmyEntry
{
    public string unitID;
    public int count;
}

[System.Serializable]
public class BarrackEntry
{
    public string unitID;
    public int queueCount;
    public string productionStartTime;
    public int maxQueueCap; //We need to add a Cap to the Barrack Queue to prevent players from spamming units and causing performance issues. This can be based on the player's progression or can be a fixed number that can be upgraded through IAP or progression.
    public int barrackLevel; //We can also add a Barrack Level to increase the production speed and queue cap. This can be upgraded through IAP or progression.
}

[System.Serializable]
public class  UnitUpgrade
{
    public string unitID;
    public int hpLevel;
    public int defLevel;
    public int atkLevel;
    public int atkSpdLevel;
    public int moveSpdLevel;
    public int critRateLevel;
    public int critDMGLevel;
}

[System.Serializable]
public class PlayerData
{
    //---Identity---
    public string playerID;
    public string playerName;
    public string lastLoginTime; //UTC string

    //---Resource---
    public int meat;
    public int wood;
    public int ore;
    public int coins;

    //---Army---
    public List<ArmyEntry> armyRoster = new List<ArmyEntry>();

    //---Baarrack---
    public List<BarrackEntry> baarrackQueue = new List<BarrackEntry>();

    //---Upgrade---
    public List<UnitUpgrade> unitUpgrades = new List<UnitUpgrade>();

    //---Progression---
    public List<string> clearedStages = new List<string>();
    public int highestRosterCap;

    //---IAP---
    public bool hasWarlordPact;
    public bool hasMonthlyPass;
    public string monthlyPassExpiry; //UTC string

    //---Analytics---
    public int totalRaidsWon;
    public int totalRaidsAttempted;
    public int totalAdsWatched;

    //---Settings---
    //We need to save player settings as well, such as sound volume, graphics quality, etc.
}
