using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObjects/UnitData", order = 1)]
public class UnitData : ScriptableObject
{
    [Header("Identity")]
    public string displayName;
    public string unitID;
    public Sprite icon;
    public RuntimeAnimatorController animatorController;

    [Header("Base Stats")]
    public int baseHP;
    public int baseATK;
    public int baseDEF;
    public float baseATKSpeed;
    public float baseMoveSpeed;
    public float baseCritRate;   
    public float baseCritDMG;    

    [Header("Collider Setup")]
    public Vector2 hurtboxSize;
    public Vector2 hitboxSize;
    public Vector2 hurtboxOffset;
    public Vector2 hitboxOffset;

    [Header("Economy")]
    public int spawnCostMeat;
    public int unlockCostOre;
    public float productionTime;
    public float spawnCooldown; //Spawning during combat need to respect this cooldown 

    [Header("Tags")]
    public string[] abilityTags;
}
