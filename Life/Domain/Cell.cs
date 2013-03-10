namespace Domain {
    public class Cell {
        private readonly bool isAlive;

        public Cell(bool isAlive) {
            this.isAlive = isAlive;
        }


        public bool IsDead {
            get { return !isAlive; }
        }

        public bool IsAlive {
            get { return isAlive; }
        }
    }
}