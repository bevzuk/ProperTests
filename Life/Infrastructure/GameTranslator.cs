#region Usings

using Domain;
using Cell = Infrastructure.DataObjects.Cell;

#endregion

namespace Infrastructure {
    public class GameTranslator {
        public void Persist(Game game, DataObjects.Game doGame) {
            doGame.Size = game.Size;
            doGame.Name = game.Name;
            PersistCells(game, doGame);
        }

        private void PersistCells(Game game, DataObjects.Game doGame) {
            doGame.Cells.Clear();
            for (var row = 0; row < game.Size; row++) {
                for (var column = 0; column < game.Size; column++) {
                    if (game[row, column].IsAlive) {
                        doGame.Cells.Add(new Cell {X = column, Y = row});
                    }
                }
            }
        }

        public Game Reconstitute(DataObjects.Game doGame) {
            var game = new Game(doGame.Size, doGame.Name);
            foreach (var cell in doGame.Cells) {
                game.GiveBirth(cell.Y, cell.X);
            }
            return game;
        }
    }
}