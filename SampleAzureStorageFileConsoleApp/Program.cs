using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.File;
using Microsoft.Extensions.Configuration;
using System;

namespace SampleAzureStorageFileConsoleApp
{
    class Program
    {
        static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var storageAccount = CloudStorageAccount.Parse(
                configuration["AzureStorageOptions:ConnectionString"]);
            var fileClient = 
                storageAccount.CreateCloudFileClient();
            var share = 
                fileClient.GetShareReference("files");

            var directory = share.GetRootDirectoryReference();

            var file = directory.GetFileReference("test.json");

            Console.WriteLine(file.Uri);
            Console.WriteLine(file.DownloadText());

            Console.Write("Press any key to exit...");
            Console.Read();
        }
    }
}
