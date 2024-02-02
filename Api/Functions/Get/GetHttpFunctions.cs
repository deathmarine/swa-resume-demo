using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;
using Azure.Storage.Blobs;
using JMSWAResume.Models.Pages;
using JMSWAResumeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using QRCoder;
using static MudBlazor.FilterOperator;
using static QRCoder.PayloadGenerator;

namespace JMSWAResumeAPI.Functions.Get
{

    public class GetHttpFunctions : AbstractGetHttpFunctions, IGetHttpFunctions {

        [FunctionName(nameof(GetHealth))]
        public async Task<IActionResult> GetHealth(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            string json = JsonSerializer.Serialize(
                new SuccessModel { Message = "Success" }, 
                new JsonSerializerOptions { WriteIndented = true });
            return await Task.FromResult(new OkObjectResult(json)).ConfigureAwait(false);
        }


        [FunctionName(nameof(GetPerson))]
        public async Task<IActionResult> GetPerson(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            if (connectionString == null || containerName == null)
                return MissingConnectionString();

            var blobClient = GetBlobClient(PersonModel.Path);
            if (!await blobClient.ExistsAsync())
                return MissingFile();

            try {

                var model = await JsonSerializer.DeserializeAsync<PersonModel>(
                        await blobClient.OpenReadAsync(),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                string json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
                return new OkObjectResult(json);
            } catch (JsonException e) {
                //Something is wrong with the json file.
                log.LogError(e, "Unable to parse json file.");
                return ParseJsonError(e, PersonModel.Path);
            }
        }

        [FunctionName(nameof(GetExperience))]
        public async Task<IActionResult> GetExperience(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            //Tests
            if (connectionString == null || containerName == null)
                return MissingConnectionString();

            var blobClient = GetBlobClient(ExperienceModel.Path);
            if (!await blobClient.ExistsAsync())
                return MissingFile();

            try {
                var model = await JsonSerializer.DeserializeAsync<ExperienceModel[]>(
                        await blobClient.OpenReadAsync(),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                string json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
                return await Task.FromResult(new OkObjectResult(json));
            } catch (JsonException e) {
                //Something is wrong with the json file.
                log.LogError(e, "Unable to parse json file.");
                return ParseJsonError(e, ExperienceModel.Path);
            }
        }

        [FunctionName(nameof(GetEducation))]
        public async Task<IActionResult> GetEducation(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            //Tests
            if (connectionString == null || containerName == null)
                return MissingConnectionString();

            var blobClient = GetBlobClient(EducationModel.Path);
            if (!await blobClient.ExistsAsync())
                return MissingFile();

            try {
                var model = await JsonSerializer.DeserializeAsync<EducationModel[]>(
                        await blobClient.OpenReadAsync(),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                string json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
                return await Task.FromResult(new OkObjectResult(json));
            } catch (JsonException e) {
                //Something is wrong with the json file.
                log.LogError(e, "Unable to parse json file.");
                return ParseJsonError(e, EducationModel.Path);
            }
        }

        [FunctionName(nameof(GetProjects))]
        public async Task<IActionResult> GetProjects(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            //Tests
            if (connectionString == null || containerName == null)
                return MissingConnectionString();

            var blobClient = GetBlobClient(ProjectModel.Path);
            if (!await blobClient.ExistsAsync())
                return MissingFile();

            try {
                var model = await JsonSerializer.DeserializeAsync<ProjectModel[]>(
                        await blobClient.OpenReadAsync(),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                //Probably don't need to deserialize this and reserialize, but why not.

                string json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });

                return await Task.FromResult(new OkObjectResult(json));
            } catch (JsonException e) {
                //Something is wrong with the json file.
                log.LogError(e, "Unable to parse json file.");
                return ParseJsonError(e, ProjectModel.Path);
            }
        }

        [FunctionName(nameof(GetAwards))]
        public async Task<IActionResult> GetAwards(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {

            if (connectionString == null || containerName == null)
                return MissingConnectionString();

            var blobClient = GetBlobClient(AwardModel.Path);
            if (!await blobClient.ExistsAsync())
                return MissingFile();

            try {
                var model = await JsonSerializer.DeserializeAsync<AwardModel[]>(
                        await blobClient.OpenReadAsync(),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                string json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
                return await Task.FromResult(new OkObjectResult(json));
            } catch (JsonException e) {
                log.LogError(e, "Unable to parse json file.");
                return ParseJsonError(e, AwardModel.Path);
            }
        }

        [FunctionName(nameof(GetCertifications))]
        public async Task<IActionResult> GetCertifications(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {

            if (connectionString == null || containerName == null)
                return MissingConnectionString();

            var blobClient = GetBlobClient(CertificationModel.Path);
            if (!await blobClient.ExistsAsync())
                return MissingFile();

            try {
                var model = await JsonSerializer.DeserializeAsync<CertificationModel[]>(
                        await blobClient.OpenReadAsync(),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                string json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
                return await Task.FromResult(new OkObjectResult(json));
            } catch (JsonException e) {
                log.LogError(e, "Unable to parse json file.");
                return ParseJsonError(e, AwardModel.Path);
            }
        }

        [FunctionName(nameof(GetBlob))]
        public async Task<IActionResult> GetBlob(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            //Tests
            if (connectionString == null || containerName == null)
                return MissingConnectionString();

            string blobName = req.Query["blobName"];
            var blobClient = GetBlobClient(blobName);
            if (!await blobClient.ExistsAsync())
                return MissingFile();

            var response = await blobClient.GetPropertiesAsync();
            var content_type = response.Value.ContentType;
            var blobStream = await blobClient.OpenReadAsync();
            return await Task.FromResult(new FileStreamResult(blobStream, content_type));
        }

        [FunctionName(nameof(GetQRCode))]
        public async Task<IActionResult> GetQRCode(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            string data = req.Query["encode"];
            var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            var stream = new MemoryStream(qrCodeImage);
            return await Task.FromResult(new FileStreamResult(stream, "image/bmp"));
        }

        [FunctionName(nameof(GetVCard))]
        public async Task<IActionResult> GetVCard(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            if (connectionString == null || containerName == null)
                return MissingConnectionString();

            var blobClient = GetBlobClient(PersonModel.Path);
            if (!await blobClient.ExistsAsync())
                return MissingFile();

            try {
                var model = await JsonSerializer.DeserializeAsync<PersonModel>(
                        await blobClient.OpenReadAsync(),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
#nullable enable
                string[]? name = model?.Name?.Split(" ");
                string[]? _location = model?.Location?.Split(',');
                string? _profession = model?.Profession ?? null;
                string? _email = model?.SocialMedia?.Email ?? null;
                string? _phone = model?.SocialMedia?.Phone ?? null;
#nullable disable
                ContactData generator =
                    new(ContactData.ContactOutputType.VCard3,
                    name[0], name[^1], null,
                    _phone, _phone, null,
                    _email, null, req.Host.Value,
                    null, null,
                    _location[0].Trim(), null, null, null,
                    _location[1].Trim(), ContactData.AddressOrder.Default, null,
                    _profession);
                string payload = generator.ToString();
                byte[] bytes = Encoding.Default.GetBytes(payload);
                var stream = new MemoryStream(bytes);
                return await Task.FromResult(new FileStreamResult(stream, "text/vcard"));
            } catch (JsonException e) {
                //Something is wrong with the json file.
                log.LogError(e, "Unable to parse json file.");
                return ParseJsonError(e, PersonModel.Path);
            }
        }

        [FunctionName(nameof(GetVCardQRCode))]
        public async Task<IActionResult> GetVCardQRCode(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            if (connectionString == null || containerName == null)
                return MissingConnectionString();

            var blobClient = GetBlobClient(PersonModel.Path);
            if (!await blobClient.ExistsAsync())
                return MissingFile();

            try {

                var model = await JsonSerializer.DeserializeAsync<PersonModel>(
                        await blobClient.OpenReadAsync(),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
#nullable enable
				string[]? name = model?.Name?.Split(" ");
				string[]? _location = model?.Location?.Split(',');
				string? _profession = model?.Profession ?? null;
				string? _email = model?.SocialMedia?.Email ?? null;
				string? _phone = model?.SocialMedia?.Phone ?? null;
#nullable disable
                ContactData generator = 
				new(ContactData.ContactOutputType.VCard3, 
                    name[0], name[^1],null,
                    _phone,_phone,null,
                    _email, null, req.Host.Value, 
                    null, null, 
                    _location[0].Trim(), null, null, null,
                    _location[1].Trim(),ContactData.AddressOrder.Default,null,
                    _profession);
                string payload = generator.ToString();
                var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new PngByteQRCode(qrCodeData);
                var qrCodeImage = qrCode.GetGraphic(20);
                var stream = new MemoryStream(qrCodeImage);
                return await Task.FromResult(new FileStreamResult(stream, "image/bmp"));
            } catch (JsonException e) {
                //Something is wrong with the json file.
                log.LogError(e, "Unable to parse json file.");
                return ParseJsonError(e, PersonModel.Path);
            }
        }

        [FunctionName(nameof(GetSetup))]
        public async Task<IActionResult> GetSetup(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log) {
            if (bool.TryParse(Environment.GetEnvironmentVariable("SetupEnabled"), out bool result)) {
                var model = new ConfigModel { SetupStatus = result };
                string json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
                return await Task.FromResult(new OkObjectResult(json));
            } else {

				log.LogError("Unable to parse setup Environmental Variable.");
				return new InternalServerErrorResult();
			}
        }
    }
}

