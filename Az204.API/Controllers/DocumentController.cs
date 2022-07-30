using Az204.Domain.DTOs;
using Az204.Domain.Storage;
//using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Az204.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        //readonly BlobServiceClient blobServiceClient;
        readonly string cnx;

        public DocumentController(IConfiguration configuration)
        {
            cnx = configuration.GetValue<string>("StorageConnectionString");
            //blobServiceClient = new BlobServiceClient(cnx);
        }

        [HttpPost("Upload")]
        public IActionResult Upload(DocumentDTO documentDTO)
        {
            //BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient("documents");
            //blobContainerClient.CreateIfNotExists();

            string fileName = documentDTO.FileName;
            string filePath = documentDTO.FilePath;
            byte[] fileBytes = Convert.FromBase64String(documentDTO.FileBase64);

            //BlobClient blobClient = blobContainerClient.GetBlobClient($"{filePath}{fileName}");
            //using var ms = new MemoryStream(fileBytes);
            //var result = blobClient.Upload(ms, true);
            //int statusCode = blobClient.Exists() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError;
            //return Ok(new ResponseDTO { Code = statusCode });

            //BlobService
            var result = new BlobService(cnx).Upload("documents", $"{filePath}{fileName}", fileBytes);
            int statusCode = result ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError;
            return Ok(new ResponseDTO { Code = statusCode });
        }

        [HttpPost("Download")]
        public IActionResult Download(DocumentDTO documentDTO)
        {
            //BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient("documents");
            //blobContainerClient.CreateIfNotExists();

            string fileName = documentDTO.FileName;
            string filePath = documentDTO.FilePath;

            //BlobClient blobClient = blobContainerClient.GetBlobClient($"{filePath}{fileName}");
            //if(!blobClient.Exists()) return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound });
            //byte[] fileBytes;
            //using var ms = new MemoryStream();
            //blobClient.DownloadTo(ms);
            //fileBytes = ms.ToArray();
            //documentDTO.FileBase64 = Convert.ToBase64String(fileBytes);
            //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = documentDTO });

            //BlobService
            BlobService blobService = new(cnx);
            var exists = blobService.Exists("documents", $"{filePath}{fileName}");
            if (!exists) return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound });

            byte[] fileBytes = blobService.GetBytes("documents", $"{filePath}{fileName}");
            documentDTO.FileBase64 = Convert.ToBase64String(fileBytes);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = documentDTO });
        }
    }
}