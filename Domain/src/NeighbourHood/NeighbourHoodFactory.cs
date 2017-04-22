using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Domain.NeighbourHood
{
    internal class NeighbourHoodFactory
    {
        private readonly List<List<Cel>> _currentWorld;

        public NeighbourHoodFactory(List<List<Cel>> currentWorld)
        {
            _currentWorld = currentWorld;
        }

        public Neighbourhood Create(Location location)
        {
            return new Neighbourhood(GetNeighbours(location).Count(neighbor => neighbor == Cel.Alive));

            IEnumerable<Cel> GetNeighbours(Location locationA)
            {
                return FindLocationNeighbors(locationA).Select(GetCel);

                Cel GetCel(Location locationNeighbor)
                {
                    return DoesCelExist(locationNeighbor) ? _currentWorld[locationNeighbor.RowNumber][locationNeighbor.ColumnNumber] : Cel.Dead;

                    bool DoesCelExist(Location locationB)
                    {
                        return DoesRowExist(locationB) && DoesColumnExist(locationB);

                        bool DoesColumnExist(Location locationC) => locationC.ColumnNumber >= 0 && locationC.ColumnNumber < _currentWorld.Count;

                        bool DoesRowExist(Location locationC) => locationC.RowNumber >= 0 && locationC.RowNumber < _currentWorld[0].Count;
                    }
                }

                List<Location> FindLocationNeighbors(Location locationD)
                {
                    return new List<Location> {
                        GetLocationFirstUpperNeighbor(locationD),
                        GetLocationSecondUpperNeighbor(locationD),
                        GetLocationThirdUpperNeighbor(locationD),
                        GetLocationFirstFellowNeighbor(locationD),
                        GetLocationSecondFellowNeighbor(locationD),
                        GetLocationFirstDownstairNeighbor(locationD),
                        GetLocationSecondDownstairNeighbor(locationD),
                        GetLocationThirdDownstairNeighbor(locationD)};

                    Location GetLocationFirstUpperNeighbor(Location d) => new Location(location.RowNumber - 1, location.ColumnNumber - 1);

                    Location GetLocationSecondUpperNeighbor(Location d) => new Location(location.RowNumber - 1, location.ColumnNumber);

                    Location GetLocationThirdUpperNeighbor(Location d) => new Location(location.RowNumber - 1, location.ColumnNumber + 1);

                    Location GetLocationFirstFellowNeighbor(Location d) => new Location(location.RowNumber, location.ColumnNumber - 1);

                    Location GetLocationSecondFellowNeighbor(Location d) => new Location(location.RowNumber, location.ColumnNumber + 1);

                    Location GetLocationFirstDownstairNeighbor(Location d) => new Location(location.RowNumber + 1, location.ColumnNumber - 1);

                    Location GetLocationSecondDownstairNeighbor(Location d) => new Location(location.RowNumber + 1, location.ColumnNumber);

                    Location GetLocationThirdDownstairNeighbor(Location d) => new Location(location.RowNumber + 1, location.ColumnNumber + 1);
                }
            }
        }
    }
}