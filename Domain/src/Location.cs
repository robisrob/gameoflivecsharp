namespace GameOfLife.Domain
{
    public class Location
    {
        private readonly int rowNummer;
        private readonly int columnNummer;

        public Location(int rowNummer, int columnNummer)
        {
            this.rowNummer = rowNummer;
            this.columnNummer = columnNummer;
        }

        public int GetRowNummer()
        {
            return rowNummer;
        }

        public int GetColumnNummer()
        {
            return columnNummer;
        }
    }
}
