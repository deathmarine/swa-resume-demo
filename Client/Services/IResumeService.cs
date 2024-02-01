using JMSWAResume.Models.Admin;

namespace JMSWAResume.Services {
    public interface IResumeService {
		Task<AboutModel> GetAboutAsync();
		Task<string> GetLicenseAsync();
		string GetRootPath();
	}
}
