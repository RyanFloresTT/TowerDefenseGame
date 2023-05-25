using System.Runtime.CompilerServices;

public class ResourceData
{
    public GeneratorTier Tier { get; private set; }
    public float Amount { get; private set; }
    public ResourceData(GeneratorTier tier, float amount)
    {
        Tier = tier;
        Amount = amount;
    }
}
