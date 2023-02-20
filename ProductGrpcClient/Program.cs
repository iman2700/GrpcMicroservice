
using Grpc.Core;
using Grpc.Net.Client;
using ProductGrpc.Protos;

Console.WriteLine("is runing...");
Thread.Sleep(2000);
using var cahnnel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new ProductProtoService.ProductProtoServiceClient(cahnnel);






await GetProductAsync(client);
await GetAllProductsAsync(client);

async Task GetAllProductsAsync(ProductProtoService.ProductProtoServiceClient client)
{
    //using (var clientData = client.GetAllProduct(new GetAllProductsRequest()))
    //{
    //    while (await clientData.ResponseStream.MoveNext(new CancellationToken()))
    //    {
    //        var currentProduct = clientData.ResponseStream.Current;
    //        Console.WriteLine(currentProduct);
    //    }
    //}
    using (var clientData = client.GetAllProduct(new GetAllProductsRequest()))
    {
        await foreach (var responseData in clientData.ResponseStream.ReadAllAsync())
        {
            Console.WriteLine(responseData);
        }
        Console.ReadLine();
    }
}

async Task GetProductAsync(ProductProtoService.ProductProtoServiceClient client)
{
    Console.WriteLine("get product async start..");
    var responce = await client.GetProductAsync(
        new ProductRequest
        {
            ProductId = 1
        });
    Console.WriteLine("getProduct responce" + responce.ToString());
    Console.ReadLine();
}