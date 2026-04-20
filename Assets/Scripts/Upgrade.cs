using UnityEngine;

public enum UpgradeType
{
    MaxNectar,
    MaxSpeed,
    Acceleration,
    FactorySpeed,
    MoreTime,
    PlantCooldown
}

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrades/Upgrade")]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string upgradeName;
    [TextArea] public string upgradeDescription;
}