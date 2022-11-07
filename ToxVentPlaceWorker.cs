namespace ToxVent;

public class ToxVentPlaceWorker : PlaceWorker
{
    public static IntVec3 GetFacingCell(IntVec3 position, Rot4 rotation) => position + IntVec3.South.RotatedBy(rotation);

    public override void DrawGhost(ThingDef def, IntVec3 center, Rot4 rot, Color ghostCol, Thing thing = null)
    {
        GenDraw.DrawFieldEdges(new() { GetFacingCell(center, rot) }, Color.white);
    }

    public override AcceptanceReport AllowsPlacing(BuildableDef def, IntVec3 center, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
    {
        var cell = GetFacingCell(center, rot);
        if (cell.Impassable(map)) return "MustPlaceVentWithFreeSpaces".Translate();
        return true;
    }
}