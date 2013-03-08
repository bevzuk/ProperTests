#region Usings

using System;
using System.Linq;

#endregion

namespace Domain {
    public static class StringExtensions {
        public static Game AsGame(this string gameRepresentation) {
            var lines = gameRepresentation.Split(new[] {Environment.NewLine, "\n"}, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(_ => _.Trim().ToCharArray());
            var game = new Game(lines.Count);
            for (var row = 0; row < lines.Count; row++) {
                var line = lines[row];
                for (var column = 0; column < line.Count(); column++) {
                    if (line[column] == 'x' || line[column] == 'X') {
                        game.GiveBirth(row, column);
                    }
                }
            }
            return game;
        }
    }
}