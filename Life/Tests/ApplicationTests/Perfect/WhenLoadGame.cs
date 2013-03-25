#region Usings

using Application;
using Common;
using Moq;
using NUnit.Framework;
using ViewModel;
using ViewModel.LifeWebService;

#endregion

namespace ApplicationTests.Perfect {
    [TestFixture]
    public class WhenLoadGame : ApplicationTest {
        private readonly GameService service = new GameService();
        private ILifeWebService serviceFake;

        [SetUp]
        public void SetUp() {
            var mock = new Mock<ILifeWebService>();
            mock.Setup(_ => _.Load(It.IsAny<string>()))
                .Returns<string>(_ => service.Load(_, InMemoryDatabase));
            serviceFake = mock.Object;
        }

        [Test]
        public void SaveGameState() {
            Arrange(a.Game(name: "SampleGame",
                           field: @"...
                                  .x.
                                  ..."));

            var game = service.Load("SampleGame", InMemoryDatabase);

            Assert.That(game, IsEquivalent.To(@"...
                                                .x.
                                                ..."));
        }

        [Test]
        public void LoadGameByName() {
            Arrange(a.Game(name: "Diablo III"));

            var viewModel = new MainViewModel(serviceFake);
            viewModel.Load("Diablo III");

            Assert.AreEqual("Diablo III", viewModel.CurrentGame.Name);
        }
    }
}