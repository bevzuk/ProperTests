#region Usings

using Iesi.Collections.Generic;

#endregion

namespace Infrastructure.DataObjects {
    public class Game {
        public virtual int Size { get; set; }
        public virtual string Name { get; set; }
        public virtual ISet<Cell> Cells { get; set; }

        public Game() {
            Cells = new HashedSet<Cell>();
        }
    }
}