## Folder structure
Below is the folder structure of the project. 
The content for the application is divided into three parts.

```
<blob-container>
|  - content/
|  |  - personal.json
|  |  - experience.json
|  |  - certifications.json
|  |  - education.json
|  |  - projects.json
|  |  - awards.json
|  |  - skills.json
|  - images/
|  |  - <images>
|  - documents/
|  |  - <documents>
```

These paths are coded into the application and should not be changed.

## Content
### personal.json
This file contains the personal information of the user and is used to generate the header and identification of the page.

```json
{
	"Name": "John Doe",
	"Profession": "Software Engineer",
	"Location": "Somewhere,US",
	"Image": "images/profile.jpg",
	"SocialMedia": {
		"Facebook": "https://www.facebook.com/user",
		"LinkedIn": "https://www.linkedin.com/in/user",
		"Github": "https://github.com/user",
		"Email": "example@email.com"
	},
	"ResumeTxt": "/documents/resume.plain.txt",
	"ResumeDoc": "/documents/resume.doc",
	"ResumePdf": "/documents/resume.pdf"
}
```
#### Social Media
Currently, the application supports the following social media platforms:
	
| Social | Dev | Media | Collaboration | Gaming | Direct |
| ----------- | ----------- |
| Facebook | Github | Youtube | Slack | Steam | Email |
| Instagram | StackOverflow | Vimeo | Skype | Twitch | Phone |
| LinkedIn | BitBucket | TikTok | WhatsApp | Xbox  | |
| Twitter |  |  | Discord |  | |
| Reddit |  |  |  |  | |

These parameters are nullable and can be removed from the file if not required.
It is recommended to include no more than 4 media platforms.

More can be added by updating the SocialMediaModel.cs and CustomIcons.cs
### experience.json


