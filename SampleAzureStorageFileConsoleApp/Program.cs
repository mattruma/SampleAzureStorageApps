using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.File;
using Microsoft.Extensions.Configuration;
using System;

namespace SampleAzureStorageFileConsoleApp
{
    class Program
    {
        // https://blogs.msdn.microsoft.com/jpsanders/2017/10/12/easily-create-a-sas-to-download-a-file-from-azure-storage-using-azure-storage-explorer/
        // https://docs.microsoft.com/en-us/azure/storage/files/storage-dotnet-how-to-use-files

        static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            Console.WriteLine("Hello World!");

            // Parse the connection string and return a reference to the storage account.
            var storageAccount = CloudStorageAccount.Parse(
                "SharedAccessSignature=sv=2018-03-28&ss=f&srt=sco&sp=rl&st=2019-08-14T16%3A31%3A01Z&se=2019-08-15T16%3A31%3A01Z&sig=aXM2TvtVMVK6UpszwvHXwx5trL3uyncYnp7m2KMjL4U%3D;FileEndpoint=https://mjr001stgacc.file.core.windows.net/;");
            var fileClient = storageAccount.CreateCloudFileClient();
            var share = fileClient.GetShareReference("files");

            var directory = share.GetRootDirectoryReference();

            var file = directory.GetFileReference("logo.jpg");

            Console.WriteLine(file.Uri);

            Console.Write("Press any key to exit...");
            Console.Read();
        }
    }
}
