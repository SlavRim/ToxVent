namespace ToxVent;

public class ToxVentComp : ThingComp
{
    public CompRefuelable Fuel => parent.GetComp<CompRefuelable>();
    public CompFlickable Flick => parent.GetComp<CompFlickable>();
    public bool Allowed => Flick.SwitchIsOn;
    public IntVec3 FacingCell => ToxVentPlaceWorker.GetFacingCell(parent.Position, parent.Rotation);
    public ToxVentComp_Properties Props => props as ToxVentComp_Properties;
    public float PourTime => Props.ToxPourTime.SecondsToTicks();

    public override void CompTick()
    {
        base.CompTick();
        if (GenTicks.TicksGame % PourTime != 0) return;
        if (!Allowed || !Fuel.HasFuel) return;
        Fuel.ConsumeFuel(Props.FuelConsumption);
        GasUtility.AddGas(FacingCell, parent.Map, GasType.ToxGas, Props.ToxPourValue);
    }
}