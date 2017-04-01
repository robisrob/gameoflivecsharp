using System.Collections.Generic;
using System.Linq;
public class NeighbourHoodFactory {

    private readonly List<List<Cel>> currentWorld;

    public NeighbourHoodFactory(List<List<Cel>> currentWorld) {
        this.currentWorld = currentWorld;
    }

    public Neighbourhood create(Location location) {
        return new Neighbourhood((int) GetNeighbours(location).Where(neighbor => neighbor == Cel.Alive).Count());
    }

    private List<Cel> GetNeighbours(Location location) {
        return new List<List<Cel>> {GetDownStairNeighbours(location), GetFellowNeighbors(location), GetUpperNeighbors(location)}.SelectMany(list => list).ToList();
    }

    private List<Cel> GetDownStairNeighbours(Location location) {
        return new List<Cel>{GetFirstDownstairNeighbor(location), GetSecondDownstairNeighbor(location), GetThirdDownstairNeighbor(location)};
    }

    private List<Cel> GetFellowNeighbors(Location location) {
        return new List<Cel>{GetFirstFellowNeighbor(location), GetSecondFellowNeigbor(location)};
    }

    private List<Cel> GetUpperNeighbors(Location location) {
        return new List<Cel>{GetFirstUpperNeighbor(location), GetSecondUpperNeighbor(location), GetThirdUpperNeighbor(location)};
    }

    private Cel GetFirstUpperNeighbor(Location location) {
        return GetCel(GetLocationFirstUpperNeighbor(location));
    }

    private Cel GetSecondUpperNeighbor(Location location) {
        return GetCel(GetLocationSecondUpperNeighbor(location));
    }

    private Cel GetThirdUpperNeighbor(Location location) {
        return GetCel(GetLocationThirdUpperNeighbor(location));
    }

    private Cel GetFirstFellowNeighbor(Location location) {
        return GetCel(GetLocationFirstFellowNeighbor(location));
    }

    private Cel GetSecondFellowNeigbor(Location location) {
        return GetCel(GetLocationSecondFellowNeighbor(location));
    }

    private Cel GetFirstDownstairNeighbor(Location location) {
        return GetCel(GetLocationFirstDownstairNeighbor(location));
    }

    private Cel GetSecondDownstairNeighbor(Location location) {
        return GetCel(GetLocationSecondDownstairNeighbor(location));
    }

    private Cel GetThirdDownstairNeighbor(Location location) {
        return GetCel(GetLocationThirdDownstairNeighbor(location));
    }

    private Cel GetCel(Location location) {
        return DoesCelExist(location) ? currentWorld[(location.GetRowNummer())][(location.GetColumnNummer())] : Cel.Dead;
    }

    private bool DoesCelExist(Location location) {
        return DoesRowExist(location) && DoesColumnExist(location);
    }

    private bool DoesColumnExist(Location location) {
        return location.GetColumnNummer() >= 0 && location.GetColumnNummer() < currentWorld.Count();
    }

    private bool DoesRowExist(Location location) {
        return location.GetRowNummer() >= 0 && location.GetRowNummer() < currentWorld[0].Count();
    }

    private Location GetLocationFirstUpperNeighbor(Location location) {
        return new Location(location.GetRowNummer() - 1, location.GetColumnNummer() - 1);
    }

    private Location GetLocationSecondUpperNeighbor(Location location) {
        return new Location(location.GetRowNummer() - 1, location.GetColumnNummer());
    }

    private Location GetLocationThirdUpperNeighbor(Location location) {
        return new Location(location.GetRowNummer() - 1, location.GetColumnNummer() + 1);
    }

    private Location GetLocationFirstFellowNeighbor(Location location) {
        return new Location(location.GetRowNummer(), location.GetColumnNummer() - 1);
    }

    private Location GetLocationSecondFellowNeighbor(Location location) {
        return new Location(location.GetRowNummer(), location.GetColumnNummer() + 1);
    }

    private Location GetLocationFirstDownstairNeighbor(Location location) {
        return new Location(location.GetRowNummer() + 1, location.GetColumnNummer() - 1);
    }

    private Location GetLocationSecondDownstairNeighbor(Location location) {
        return new Location(location.GetRowNummer() + 1, location.GetColumnNummer());
    }

    private Location GetLocationThirdDownstairNeighbor(Location location) {
        return new Location(location.GetRowNummer() + 1, location.GetColumnNummer() + 1);
    }
}