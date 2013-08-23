using System;

namespace GameOfLifeKata.Core
{
    public class Grid
    {
        public override int GetHashCode()
        {
            return (Cells != null ? Cells.GetHashCode() : 0);
        }

        public bool[,] Cells { get; private set; }

        public Grid(bool[,] cells)
        {
            if (cells.GetLength(0) < 2 || cells.GetLength(1) < 2)
                throw new ArgumentOutOfRangeException();

            Cells = cells;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            for (var x = 0; x < Cells.GetLength(0); x++)
                for (var y = 0; y < Cells.GetLength(1); y++)
                    Cells[x, y] = false;
        }

        public void Resuscitate(int x, int y)
        {
            Cells[x, y] = true;
        }

        public void Decimate(int x, int y)
        {
            Cells[x, y] = false;
        }

    }
}
