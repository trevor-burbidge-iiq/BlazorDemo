using BlazorDemo.Shared.ApiModels;
using System.Net.Http.Json;

namespace BlazorDemo.Client.Services
{
    public interface ILanguageService
    {
        Task AddLanguage(LanguageApiModel languageApiModel);
        Task<List<LanguageApiModel>> GetLanguages();
    }

    public class LanguageService : ILanguageService
    {
        private readonly HttpClient httpClient;

        public LanguageService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<LanguageApiModel>> GetLanguages()
        {
            var languages = await httpClient.GetFromJsonAsync<List<LanguageApiModel>>("api/languages");
            return languages.OrderBy(l => l.Name).ToList();
        }

        public async Task AddLanguage(LanguageApiModel languageApiModel)
        {
            await httpClient.PostAsJsonAsync("api/languages", languageApiModel);
        }
    }
}
