#region Usings

using System;
using System.Text;

#endregion

namespace Domain {
    public class Game {
        public Cell[,] Cells;
        public int Size { get; private set; }

        public Game(int size) {
            Size = size;
            Cells = new Cell[size,size];
            for (var row = 0; row < Size; row++) {
                for (var column = 0; column < Size; column++) {
                    Cells[row, column] = new Cell(false);
                }
            }
        }

        public Cell this[int row, int column] {
            get { return Cells[row, column]; }
        }

        public void GiveBirth(int row, int column) {
            Cells[row, column] = new Cell(true);
        }

        public void Step() {
            var newGeneration = new Cell[Size,Size];
            for (var row = 0; row < Size; row++) {
                for (var column = 0; column < Size; column++) {
                    newGeneration[row, column] = new Cell(false);
                    if (this[row, column].IsAlive && NumberOfNeighbors(row, column) < 2) {
                        newGeneration[row, column] = new Cell(false);
                    }
                    if (this[row, column].IsAlive && NumberOfNeighbors(row, column) == 2) {
                        newGeneration[row, column] = new Cell(true);
                    }
                    if (this[row, column].IsAlive && NumberOfNeighbors(row, column) == 3) {
                        newGeneration[row, column] = new Cell(true);
                    }
                    if (this[row, column].IsAlive && NumberOfNeighbors(row, column) == 4) {
                        newGeneration[row, column] = new Cell(false);
                    }
                    if (this[row, column].IsDead && NumberOfNeighbors(row, column) == 3) {
                        newGeneration[row, column] = new Cell(true);
                    }
                }
            }
            Cells = newGeneration;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            for (var row = 0; row < Size; row++) {
                for (var column = 0; column < Size; column++) {
                    sb.Append(this[row, column].IsAlive ? 'x' : '.');
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        private int NumberOfNeighbors(int row, int column) {
            return
                Neighbor(row - 1, column - 1) +
                Neighbor(row - 1, column) +
                Neighbor(row - 1, column + 1) +
                Neighbor(row, column - 1) +
                Neighbor(row, column + 1) +
                Neighbor(row + 1, column - 1) +
                Neighbor(row + 1, column) +
                Neighbor(row + 1, column + 1);
        }

        private int Neighbor(int row, int column) {
            if (row < 0 || row >= Size || column < 0 || column >= Size) return 0;
            return Cells[row, column].IsAlive ? 1 : 0;
        }
    }
}