public interface IDamageInformation
{
    DamageInformation DamageInfo { get; }
}

public struct DamageInformation
{
    public string DamageSourceName { get; set; }
    public int DamageAmount { get; set; }
}
