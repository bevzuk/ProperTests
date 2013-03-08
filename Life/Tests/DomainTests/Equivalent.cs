#region Usings

using NUnit.Framework.Constraints;

#endregion

namespace DomainTests {
    public static class Equivalent {
        public static IResolveConstraint To(string gameRepresentation) {
            return new GameConstraint(gameRepresentation);
        }
    }
}