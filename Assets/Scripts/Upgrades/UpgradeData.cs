public class UpgradeData
{
    public GeneratorUpgrades type { get; private set; }
    public float value { get; private set; }

    public UpgradeData(GeneratorUpgrades type, float value)
    {
        this.type = type;
        this.value = value;
    }
}