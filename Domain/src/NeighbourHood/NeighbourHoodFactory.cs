using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Domain.NeighbourHood
{
    internal class NeighbourHoodFactory
    {
        private readonly List<List<Cel>> _currentWorld;
        private Location _location;

        public NeighbourHoodFactory(List<List<Cel>> currentWorld, Location location)
        {
            _currentWorld = currentWorld;
            _location = location;
        }

        public Neighbourhood Create()
        {
            return new Neighbourhood(GetNeighbours().Count(neighbor => neighbor == Cel.Alive));

            IEnumerable<Cel> GetNeighbours()
            {
                return FindLocationNeighbors().Select(GetCel);

                Cel GetCel(Location locationNeighbor)
                {
                    return DoesCelExist() ? _currentWorld[locationNeighbor.RowNumber][locationNeighbor.ColumnNumber] : Cel.Dead;

                    bool DoesCelExist()
                    {
                        return DoesRowExist() && DoesColumnExist();

                        bool DoesColumnExist() => locationNeighbor.ColumnNumber >= 0 && locationNeighbor.ColumnNumber < _currentWorld.Count;

                        bool DoesRowExist() => locationNeighbor.RowNumber >= 0 && locationNeighbor.RowNumber < _currentWorld[0].Count;
                    }
                }

                List<Location> FindLocationNeighbors()
                {
                    return new List<Location> {
                        GetLocationFirstUpperNeighbor(),
                        GetLocationSecondUpperNeighbor(),
                        GetLocationThirdUpperNeighbor(),
                        GetLocationFirstFellowNeighbor(),
                        GetLocationSecondFellowNeighbor(),
                        GetLocationFirstDownstairNeighbor(),
                        GetLocationSecondDownstairNeighbor(),
                        GetLocationThirdDownstairNeighbor()};

                    Location GetLocationFirstUpperNeighbor() => new Location(_location.RowNumber - 1, _location.ColumnNumber - 1);

                    Location GetLocationSecondUpperNeighbor() => new Location(_location.RowNumber - 1, _location.ColumnNumber);

                    Location GetLocationThirdUpperNeighbor() => new Location(_location.RowNumber - 1, _location.ColumnNumber + 1);

                    Location GetLocationFirstFellowNeighbor() => new Location(_location.RowNumber, _location.ColumnNumber - 1);

                    Location GetLocationSecondFellowNeighbor() => new Location(_location.RowNumber, _location.ColumnNumber + 1);

                    Location GetLocationFirstDownstairNeighbor() => new Location(_location.RowNumber + 1, _location.ColumnNumber - 1);

                    Location GetLocationSecondDownstairNeighbor() => new Location(_location.RowNumber + 1, _location.ColumnNumber);

                    Location GetLocationThirdDownstairNeighbor() => new Location(_location.RowNumber + 1, _location.ColumnNumber + 1);
                }
            }
        }
    }
}