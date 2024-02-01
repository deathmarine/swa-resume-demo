using JMSWAResume.Models.Shared;
using JMSWAResume.Services;
using System.ComponentModel.DataAnnotations;

namespace JMSWAResume.Models.Pages {
	public class PersonModel {
		public static readonly string Path = "/content/personal.json";

		[Required]
		public string Name {
			get; set;
		}
		[Required]
		public string Profession {
			get; set;
		}
		public string Location {
			get; set;
		}
		public string Image {
			get; set;
		}

		public string ResumeTxt {
			get; set;
		}
		public string ResumeDoc {
			get; set;
		}
		public string ResumePdf {
			get; set;
		}
		public SocialMediaModel SocialMedia {
			get; set;
		}

		public string Summary {
			get; set;
		}

	}

}
