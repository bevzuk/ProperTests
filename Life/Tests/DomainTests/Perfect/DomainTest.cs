#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace DomainTests.Perfect {
    public class DomainTest {
        public DomainTest() {
            Create = new Father();
        }

        public class AssertThat {
            public static void AreEqual(string expectedGameRepresentation, Game game) {
                var row = 0;
                var lines = expectedGameRepresentation.Split(new[] {Environment.NewLine, "\n"}, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(_ => _.Trim());
                var errors = expectedGameRepresentation.Split(new[] {Environment.NewLine, "\n"}, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(_ => _.Trim().ToCharArray());
                var hasErrors = false;

                foreach (var line in lines) {
                    var column = 0;
                    foreach (var code in line) {
                        switch (code) {
                            case '.':
                                if (game[row, column].IsAlive) {
                                    hasErrors = true;
                                    errors[row][column] = '*';
                                }
                                break;
                            case 'x':
                            case 'X':
                                if (game[row, column].IsDead) {
                                    hasErrors = true;
                                    errors[row][column] = '*';
                                }
                                break;
                        }
                        column++;
                    }
                    row++;
                }
                if (hasErrors) {
                    Assert.Fail("Games doesn't match:" + Environment.NewLine + ConvertToString(errors));
                }
            }

            private static string ConvertToString(IEnumerable<char[]> errors) {
                var sb = new StringBuilder();
                foreach (var error in errors) {
                    sb.AppendLine(new string(error));
                }
                return sb.ToString();
            }
        }

        public Father Create { get; private set; }
    }
}