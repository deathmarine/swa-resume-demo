using JMSWAResume.Models.Admin;
using JMSWAResume.Models.Pages;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JMSWAResume.Services
{
    public abstract class APIServiceAbstract : IAPIService{
        public HttpClient _httpClient;
        public ILogger<APIService> _logger;

        //Cache the data
        private PersonModel Person;
        private ExperienceModel[] Experiences;
        private EducationModel[] Educations;
        private AwardModel[] Awards;
        private CertificationModel[] Certifications;
        private ProjectModel[] Projects;

        public async Task<PersonModel> GetPersonAsync() {
            if (Person != null)
                return Person;
            _logger.LogInformation($"Getting {nameof(PersonModel)}..");
            Person = await JsonSerializer.DeserializeAsync<PersonModel>(
                await _httpClient.GetStreamAsync($"api/GetPerson"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return Person;
        }

        public async Task<ExperienceModel[]> GetExperiencesAsync() {
            if (Experiences != null)
                return Experiences;
            _logger.LogInformation($"Getting {nameof(ExperienceModel)}..");
            Experiences = await JsonSerializer.DeserializeAsync<ExperienceModel[]>(
                await _httpClient.GetStreamAsync($"api/GetExperience"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return Experiences;
        }

        public async Task<EducationModel[]> GetEducationsAsync() {
            if (Educations != null)
                return Educations;
            _logger.LogInformation($"Getting {nameof(EducationModel)}..");
            Educations = await JsonSerializer.DeserializeAsync<EducationModel[]>(
                await _httpClient.GetStreamAsync($"api/GetEducation"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return Educations;
        }

        public async Task<AwardModel[]> GetAwardsAsync() {
            if (Awards != null)
                return Awards;
            _logger.LogInformation($"Getting {nameof(AwardModel)}..");
            Awards = await JsonSerializer.DeserializeAsync<AwardModel[]>(
                await _httpClient.GetStreamAsync($"api/GetAwards"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return Awards;
        }

        public async Task<CertificationModel[]> GetCertificationsAsync() {
            if (Certifications != null)
                return Certifications;
            _logger.LogInformation($"Getting {nameof(CertificationModel)}..");
            Certifications = await JsonSerializer.DeserializeAsync<CertificationModel[]>(
                await _httpClient.GetStreamAsync($"api/GetCertifications"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return Certifications;
        }

        public async Task<ProjectModel[]> GetProjectsAsync() {
            if (Projects != null)
                return Projects;
            _logger.LogInformation($"Getting {nameof(ProjectModel)}..");
            Projects = await JsonSerializer.DeserializeAsync<ProjectModel[]>(
                    await _httpClient.GetStreamAsync("api/GetProjects"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return Projects;
        }

        public Task PostFormDataAsync(ContactModel data) {
            var json = JsonSerializer.Serialize(data);
            _logger.LogInformation($"Sending form data: {json}");
            return _httpClient.PostAsync("api/SubmitContact", new StringContent(json, Encoding.UTF8, "application/json"));
        }

        public Task UploadContentAsync(string path, string content) {
            var payload = new StringContent(content, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync($"api/UploadContent?path={path}", payload);
        }
        public Task UploadImageAsync(string path, MultipartFormDataContent content) {
            return _httpClient.PostAsync($"api/UploadImage?path={path}", content);
        }

        public async Task<bool> GetHealthAsync() {
            bool success = false;
            int count = 0;
            while (!success && count < 5) {
                try {
                    var response = await _httpClient.GetAsync("api/GetHealth");
                    response.EnsureSuccessStatusCode();
                    success = true;
                    return success;
                } catch (Exception e) {
                    count++;
                    _logger.LogError(e, $"API Health check failed. Count:{count} Retrying..");
                    await Task.Delay(1000);
                    
                }
            }
            return success;
        }
        public string GetAPIPath() {
            return $"{_httpClient.BaseAddress}api/";
        }
        public string GetFunctionPath(string function) {
            return $"{GetAPIPath()}{function}";
        }
        public string GetBlobPath(string path) {
            return $"{GetFunctionPath("GetBlob")}?blobName={path}";
        }
        public string GetQRCodePath(string encode) {
            return $"{GetFunctionPath("GetQRCode")}?encode={encode}";
        }
        public string GetVCardPath() {
            return $"{GetFunctionPath("GetVCard")}";
        }
        public string GetVCardQRCodePath() {
            return $"{GetFunctionPath("GetVCardQRCode")}";
        }
    }
}
