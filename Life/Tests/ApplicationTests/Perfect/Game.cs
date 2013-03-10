#region Usings

using System.Collections.Generic;

#endregion

namespace ApplicationTests.Perfect {
    public class Game {
        public string Name { get; set; }
        public int Size { get; set; }
        private readonly List<Cell> cells;
    }
}