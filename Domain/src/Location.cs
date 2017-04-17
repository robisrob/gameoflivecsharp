namespace GameOfLife.Domain
{
    internal class Location
    {
        public Location(int rowNumber, int columnNumber)
        {
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }

        public int RowNumber { get; }
        public int ColumnNumber { get; }
    }
}
