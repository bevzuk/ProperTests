#region Usings

using NUnit.Framework.Constraints;

#endregion

namespace Common {
    public static class IsEquivalent {
        public static IResolveConstraint To(string gameRepresentation) {
            return new GameConstraint(gameRepresentation);
        }
    }
}