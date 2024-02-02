using JMSWAResume.Models.Admin;
using JMSWAResume.Models.Pages;

namespace JMSWAResume.Services
{
    public interface IAPIService {
        Task<bool> GetHealthAsync();
		Task PostFormDataAsync(ContactModel data);
		Task UploadContentAsync(string path, string content);
		Task UploadImageAsync(string path, MultipartFormDataContent content);
        Task<PersonModel> GetPersonAsync();
        Task<ExperienceModel[]> GetExperiencesAsync();
        Task<EducationModel[]> GetEducationsAsync();
        Task<AwardModel[]> GetAwardsAsync();
        Task<CertificationModel[]> GetCertificationsAsync();
        Task<ProjectModel[]> GetProjectsAsync();
        public string GetAPIPath();
        public string GetFunctionPath(string path);
        public string GetBlobPath(string path);
        public string GetQRCodePath(string path);
        public string GetVCardPath();
        public string GetVCardQRCodePath();



    }
}
