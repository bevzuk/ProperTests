#region Usings

using System;
using System.Linq;
using Domain;
using NUnit.Framework.Constraints;

#endregion

namespace Common {
    public class GameConstraint : Constraint {
        private readonly string expectedGameRepresentation;
        private string actualGameRepresentation;

        public GameConstraint(string gameRepresentation) {
            expectedGameRepresentation =
                string.Join(Environment.NewLine,
                            gameRepresentation.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(_ => _.Trim()));
        }

        public override bool Matches(object actual) {
            var actualGame = actual as Game;
            if (actualGame == null) return false;

            actualGameRepresentation = actualGame.ToString();
            return actualGameRepresentation == expectedGameRepresentation;
        }

        public override void WriteDescriptionTo(MessageWriter writer) {
            writer.WriteLine();
            writer.WriteLine(expectedGameRepresentation);
        }

        public override void WriteActualValueTo(MessageWriter writer) {
            writer.WriteLine();
            writer.WriteLine(actualGameRepresentation);

            writer.WriteLine();
            writer.WriteLine("  Difference:");
            actualGameRepresentation
                .ToCharArray()
                .ToList()
                .Select((c, i) => c == expectedGameRepresentation[i] ? c : '#')
                .ToList()
                .ForEach(writer.Write);
        }
    }
}