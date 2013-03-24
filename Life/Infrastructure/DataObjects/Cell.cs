namespace Infrastructure.DataObjects {
    public class Cell {
        public virtual int X { get; set; }
        public virtual int Y { get; set; }

        protected bool Equals(Cell other) {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cell) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (X*397) ^ Y;
            }
        }
    }
}