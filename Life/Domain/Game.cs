namespace Domain {
    public class Game {
        private readonly int size;
        private bool[,] cells;

        public Game(int size) {
            this.size = size;
            cells = new bool[size,size];
        }

        public Cell this[int row, int column] {
            get { return new Cell(cells[row, column]); }
        }

        public void GiveBirth(int row, int column) {
            cells[row - 1, column - 1] = true;
        }

        public void Step() {
//            var newGeneration = new bool[size,size];
//            for (var row = 0; row < size; row++) {
//                for (var column = 0; column < size; column++) {
//                    if (NumberOfNeighbors(row, column) == 0) {
//                        Kill()
//                    }
//                }
//            }
//            cells = newGeneration;
        }
    }
}