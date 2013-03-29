#region Usings

using Domain;
using Moq;
using NUnit.Framework;
using ViewModel;
using ViewModel.LifeWebService;

#endregion

namespace PresentationTests.NotPerfect {
    [TestFixture]
    public class GamePresentationTests {
        [Test]
        public void AssertMethodWasCalled() {
            var mock = new Mock<ILifeWebService>();
            mock.Setup(_ => _.Load(It.IsAny<string>()));

            new MainViewModel(mock.Object).Load("New game");

            mock.Verify(_ => _.Load("New game"));
        }
        
        [Test]
        public void AssertFakeState() {
            var mock = new Mock<ILifeWebService>();
            var expected = new Game(1);
            const string gameName = "New game";

            mock.Setup(_ => _.Load(gameName)).Returns(expected);

            var viewModel = new MainViewModel(mock.Object);
            viewModel.Load(gameName);

            Assert.AreSame(expected, viewModel.CurrentGame);
        }
    }
}