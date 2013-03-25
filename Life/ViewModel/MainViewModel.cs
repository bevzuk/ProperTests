using Domain;
using ViewModel.LifeWebService;

namespace ViewModel {
    public class MainViewModel {
        private readonly ILifeWebService service;

        public MainViewModel(ILifeWebService service) {
            this.service = service;
        }

        public Game CurrentGame { get; private set; }

        public void Load(string gameName) {
            CurrentGame = service.Load(gameName);
        }
    }
}