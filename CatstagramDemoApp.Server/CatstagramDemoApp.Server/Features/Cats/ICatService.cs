namespace CatstagramDemoApp.Server.Features.Cats {
    public interface ICatService {
        Task<int> Create(string imageUrl, string description, string userId);
    }
}
