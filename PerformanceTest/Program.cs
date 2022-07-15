using Cloudmersive.APIClient.NETCore.VirusScan.Api;
using System.Diagnostics;

List<double> Data = new List<double>();

Parallel.For(0, 100, new ParallelOptions() { MaxDegreeOfParallelism = 4 }, i => {

    DateTime start = DateTime.Now;

    Console.WriteLine("Scan started: " + i);

    var apiInstance = new ScanApi();
    apiInstance.Configuration = new Cloudmersive.APIClient.NETCore.VirusScan.Client.Configuration();
    apiInstance.Configuration.AddApiKey("Apikey", "your-api-key");
    apiInstance.Configuration.Timeout = 10000000;
    apiInstance.Configuration.BasePath = "https://api-endpoint";

    var inputFile = new MemoryStream(new byte[1 * 1000000]); // System.IO.Stream | Input file to perform the operation on.

    // Scan a file for viruses
    var result = apiInstance.ScanFileAdvanced(inputFile);


    //Assert.IsTrue(result.CleanResult.Value);

    Data.Add((DateTime.Now.Subtract(start).TotalSeconds));

    Console.WriteLine("Scan completed: " + i +
        ", Duration: " + (DateTime.Now.Subtract(start).TotalSeconds));


});

Debug.WriteLine("Average Duration (Seconds): " + Data.Average());
