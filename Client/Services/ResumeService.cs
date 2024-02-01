using JMSWAResume.Models.Admin;
using JMSWAResume.Pages.Resume;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace JMSWAResume.Services {
    public class ResumeService : IResumeService {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ResumeService> _logger;

		[AllowNull]
		private AboutModel _about;
		private string _license;

        public ResumeService(HttpClient httpClient, ILogger<ResumeService> logger) {
            _httpClient = httpClient;
            _logger = logger;
        }

		public async Task<AboutModel> GetAboutAsync() {
            _logger.LogInformation($"Getting {nameof(AboutModel)}..");
            _about ??= await JsonSerializer.DeserializeAsync<AboutModel>(
					await _httpClient.GetStreamAsync(AboutModel.Path),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return _about;
		}

		public async Task<string> GetLicenseAsync() {
            _logger.LogInformation($"Getting {nameof(LicenseModel)}..");
            if (_license == null) {
                var response = await _httpClient.GetAsync(LicenseModel.Path);
                _license = await response.Content.ReadAsStringAsync();
            }
            return _license;
		}

        public string GetRootPath() => _httpClient.BaseAddress.AbsoluteUri;

	}
}
