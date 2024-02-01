using Azure.Storage.Blobs;
using JMSWAResume.Models;
using JMSWAResumeAPI.Models;
using JMSWAResumeAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JMSWAResumeAPI.Functions.Get
{
    public abstract class AbstractGetHttpFunctions
    {

        public readonly string connectionString;
        public readonly string containerName;
        public readonly QRCodeGenerator qrGenerator;
        public BlobContainerClient containerClient;
        public AbstractGetHttpFunctions()
        {
            connectionString = Environment.GetEnvironmentVariable("StorageAccount");
            containerName = Environment.GetEnvironmentVariable("StorageAccount_Container");
            qrGenerator = new QRCodeGenerator();
            containerClient = new(connectionString, containerName);
        }

        public IActionResult MissingConnectionString()
        {
            return new BadRequestObjectResult(
                JsonSerializer.Serialize(
                    new ErrorModel("Storage Account or Container Name not set.")));
        }
        public IActionResult MissingFile()
        {
            return new NotFoundObjectResult(
                JsonSerializer.Serialize(new ErrorModel("File not found.")));
        }

        public IActionResult ParseJsonError(JsonException e, string path)
        {
            return new CustomInternalServerErrorResult(
                JsonSerializer.Serialize(
                    new JsonExceptionModel($"{nameof(JsonException)}: Unable to parse {path}\n{e.Message}", e)));
        }

        public BlobClient GetBlobClient(string path)
        {
            return containerClient.GetBlobClient(path);
        }

    }
}
