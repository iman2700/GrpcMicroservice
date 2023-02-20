
using Grpc.Net.Client;
using ProductGrpc.Protos;

Console.WriteLine("is runing...");
Thread.Sleep(2000);
using var cahnnel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new ProductProtoService.ProductProtoServiceClient(cahnnel);
Console.WriteLine("get product async start..");
var responce = await client.GetProductAsync(
    new ProductRequest
    {
        ProductId = 1
    } ) ;
Console.WriteLine("getProduct responce" + responce.ToString());
Console.ReadLine();
