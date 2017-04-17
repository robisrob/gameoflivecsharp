using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Domain.NeighbourHood
{
    internal class NeighbourHoodFactory
    {
        private readonly List<List<Cel>> currentWorld;

        public NeighbourHoodFactory(List<List<Cel>> currentWorld)
        {
            this.currentWorld = currentWorld;
        }

        public Neighbourhood Create(Location location)
            => new Neighbourhood((int)GetNeighbours(location).Where(neighbor => neighbor == Cel.Alive).Count());

        private List<Cel> GetNeighbours(Location location) 
            => new List<List<Cel>> { GetDownStairNeighbours(location), GetFellowNeighbors(location), GetUpperNeighbors(location) }.SelectMany(list => list).ToList();

        private List<Cel> GetDownStairNeighbours(Location location) 
            => new List<Cel> { GetFirstDownstairNeighbor(location), GetSecondDownstairNeighbor(location), GetThirdDownstairNeighbor(location) };

        private List<Cel> GetFellowNeighbors(Location location)
            => new List<Cel> { GetFirstFellowNeighbor(location), GetSecondFellowNeigbor(location) };

        private List<Cel> GetUpperNeighbors(Location location)
            => new List<Cel> { GetFirstUpperNeighbor(location), GetSecondUpperNeighbor(location), GetThirdUpperNeighbor(location) };

        private Cel GetFirstUpperNeighbor(Location location)
            => GetCel(GetLocationFirstUpperNeighbor(location));

        private Cel GetSecondUpperNeighbor(Location location)
            => GetCel(GetLocationSecondUpperNeighbor(location));

        private Cel GetThirdUpperNeighbor(Location location)
         => GetCel(GetLocationThirdUpperNeighbor(location));

        private Cel GetFirstFellowNeighbor(Location location)
         => GetCel(GetLocationFirstFellowNeighbor(location));

        private Cel GetSecondFellowNeigbor(Location location)
            =>  GetCel(GetLocationSecondFellowNeighbor(location));

        private Cel GetFirstDownstairNeighbor(Location location)
            => GetCel(GetLocationFirstDownstairNeighbor(location));

        private Cel GetSecondDownstairNeighbor(Location location)
            => GetCel(GetLocationSecondDownstairNeighbor(location));

        private Cel GetThirdDownstairNeighbor(Location location)
            => GetCel(GetLocationThirdDownstairNeighbor(location));
        
        private Cel GetCel(Location location)
            => DoesCelExist(location) ? currentWorld[(location.RowNumber)][(location.ColumnNumber)] : Cel.Dead;

        private bool DoesCelExist(Location location)
            =>  DoesRowExist(location) && DoesColumnExist(location);

        private bool DoesColumnExist(Location location)
            => location.ColumnNumber >= 0 && location.ColumnNumber < currentWorld.Count();

        private bool DoesRowExist(Location location)
            =>  location.RowNumber >= 0 && location.RowNumber < currentWorld[0].Count();

        private Location GetLocationFirstUpperNeighbor(Location location)
            => new Location(location.RowNumber - 1, location.ColumnNumber - 1);

        private Location GetLocationSecondUpperNeighbor(Location location)
            => new Location(location.RowNumber - 1, location.ColumnNumber);

        private Location GetLocationThirdUpperNeighbor(Location location)
            => new Location(location.RowNumber - 1, location.ColumnNumber + 1);

        private Location GetLocationFirstFellowNeighbor(Location location)
            => new Location(location.RowNumber, location.ColumnNumber - 1);

        private Location GetLocationSecondFellowNeighbor(Location location)
            => new Location(location.RowNumber, location.ColumnNumber + 1);

        private Location GetLocationFirstDownstairNeighbor(Location location)
            => new Location(location.RowNumber + 1, location.ColumnNumber - 1);

        private Location GetLocationSecondDownstairNeighbor(Location location)
            => new Location(location.RowNumber + 1, location.ColumnNumber);

        private Location GetLocationThirdDownstairNeighbor(Location location)
            => new Location(location.RowNumber + 1, location.ColumnNumber + 1);
    }
}