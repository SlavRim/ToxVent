namespace ToxVent;

public class ToxVentComp_Properties : CompProperties
{
    public float ToxPourTime;
    public int ToxPourValue;
    public float FuelConsumption;
    public ToxVentComp_Properties()
    {
        compClass = typeof(ToxVentComp);
    }
}