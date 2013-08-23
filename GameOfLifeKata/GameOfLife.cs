namespace GameOfLifeKata.Core
{
    public class GameOfLife
    {
        public Grid Play(Grid input)
        {
            var output = new Grid(new bool[input.Cells.GetLength(0),input.Cells.GetLength(1)]);

            for (var x = 0; x < input.Cells.GetLength(0); x++)
                for (var y = 0; y < input.Cells.GetLength(1); y++)
                    ProcessRulesOfLife(input, x, y, output);

            return output;
        }

        private void ProcessRulesOfLife(Grid input, int x, int y, Grid output)
        {
            var neighbors = GetNumberOfNeighbors(input, x, y);
            if (neighbors < 2 || neighbors >= 4)
                output.Decimate(x, y);
            if (input.Cells[x, y] && neighbors == 2)
                output.Resuscitate(x, y);
            if (neighbors == 3)
                output.Resuscitate(x, y);
        }

        private int GetNumberOfNeighbors(Grid input, int x, int y)
        {
            return
                GetNeighborAbove(input, x, y) +
                GetNeighborDiagnollyUpRight(input, x, y) +
                GetNeighborToTheRight(input, x, y) +
                GetNeighborDiagnollyDownRight(input, x, y) +
                GetNeighborBelow(input, x, y) +
                GetNeighborDiagnollyDownLeft(input, x, y) +
                GetNeighborToTheLeft(input, x, y) +
                GetNeighborDiagnollyUpLeft(input, x, y);
        }

        private int GetNeighborDiagnollyUpLeft(Grid input, int x, int y)
        {
            return (y > 0 && x > 0 && input.Cells[x - 1, y - 1]) ? 1 : 0;
        }

        private int GetNeighborToTheLeft(Grid input, int x, int y)
        {
            return (x > 0 && input.Cells[x - 1, y]) ? 1 : 0;
        }

        private int GetNeighborDiagnollyDownLeft(Grid input, int x, int y)
        {
            return (y < input.Cells.GetLength(1) - 1 && x > 0 && input.Cells[x - 1, y + 1]) ? 1 : 0;
        }

        private int GetNeighborAbove(Grid input, int x, int y)
        {
            return (y > 0 && input.Cells[x, y - 1]) ? 1 : 0;
        }

        private int GetNeighborDiagnollyUpRight(Grid input, int x, int y)
        {
            return (y > 0 && x < input.Cells.GetLength(0) - 1 && input.Cells[x + 1, y - 1]) ? 1 : 0;
        }

        private static int GetNeighborDiagnollyDownRight(Grid input, int x, int y)
        {
            return (x < input.Cells.GetLength(0) - 1 && y < input.Cells.GetLength(1) - 1 && input.Cells[x + 1, y + 1]) ? 1 : 0;
        }

        private static int GetNeighborBelow(Grid input, int x, int y)
        {
            return (y < input.Cells.GetLength(1) - 1 && input.Cells[x, y + 1]) ? 1 : 0;
        }

        private static int GetNeighborToTheRight(Grid input, int x, int y)
        {
            return (x < input.Cells.GetLength(0) - 1 && input.Cells[x + 1, y]) ? 1 : 0;
        }
    }
}
