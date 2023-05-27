public class UpgradeData
{
    public UpgradeTypes type { get; private set; }
    public float value { get; private set; }

    public UpgradeData(UpgradeTypes type, float value)
    {
        this.type = type;
        this.value = value;
    }
}