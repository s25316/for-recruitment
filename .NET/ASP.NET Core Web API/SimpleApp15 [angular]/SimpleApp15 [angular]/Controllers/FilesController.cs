using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using SimpleApp15__angular_.DTOs;

namespace SimpleApp15__angular_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        [HttpPost("save")]
        public async Task<IActionResult> UploadFileAsync(FIleReq req, CancellationToken cancellation)
        {
            var file = req.File;
            if (file == null || file.Length == 0)
                return BadRequest("Nie wybrano pliku.");

            if (file.ContentType != "application/pdf")
                return BadRequest("Przesłany plik nie jest plikiem PDF.");

            var filePath = await SaveToDBAsync(file, cancellation);
            Console.WriteLine("Svcaed");
            return Ok(new { FilePath = filePath, Message = "Plik został zapisany." });
        }

        [HttpGet("download/{fileId}")]
        public async Task<IActionResult> GetAsync(string fileId, CancellationToken cancellation)
        {
            var connectionString = "mongodb://myuser:mypassword@localhost:27017/";
            var databaseName = "files_CV";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            var gridFS = new GridFSBucket(database);

            try
            {
                var objectId = new ObjectId(fileId);
                var fileStream = new MemoryStream();

                // Pobieranie pliku z MongoDB do MemoryStream
                await gridFS.DownloadToStreamAsync(objectId, fileStream, cancellationToken: cancellation);

                fileStream.Position = 0; // Ustawienie pozycji na początek strumienia

                var fileName = fileId; // Możesz ustawić nazwę pliku, jeśli jest dostępna w bazie
                var encodedFileName = Uri.EscapeDataString(fileName);

                // Ustawienie nagłówka Content-Disposition
                Response.Headers.Add("Content-Disposition", $"attachment; filename*=UTF-8''{encodedFileName}");
                Response.ContentType = "application/pdf"; // Możesz dynamicznie ustawić Content-Type na podstawie pliku

                return File(fileStream, "application/pdf");
            }
            catch (GridFSFileNotFoundException)
            {
                return NotFound("File not found.");
            }
        }

        //================================================================================================
        //================================================================================================
        //================================================================================================
        //Private Methods
        private async Task<string> SaveIntoRepositoryAsync(IFormFile file, CancellationToken cancellation)
        {
            var projectRoot = Directory.GetParent(AppContext.BaseDirectory)?
                .Parent?
                .Parent?
                .Parent?
                .FullName;

            var filePath = Path.Combine(projectRoot, "Uploads", file.FileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Tworzenie katalogu, jeśli nie istnieje
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filePath;
        }

        private async Task<string> SaveToDBAsync(IFormFile file, CancellationToken cancellation)
        {
            var connectionString = "mongodb://myuser:mypassword@localhost:27017/"; // Zmień na swój connection string
            var databaseName = "files_CV";

            // Połączenie z MongoDB
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            // Tworzenie obiektu GridFS
            var gridFS = new GridFSBucket(database);

            await using var stream = file.OpenReadStream();
            var fileId = await gridFS.UploadFromStreamAsync(file.FileName, stream, new GridFSUploadOptions
            {
                Metadata = new MongoDB.Bson.BsonDocument
                {
                    { "ContentType", file.ContentType },
                    { "UploadedAt", DateTime.UtcNow }
                }
            });
            return fileId.ToString();
        }
    }
}
