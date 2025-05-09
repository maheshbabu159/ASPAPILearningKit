using Microsoft.AspNetCore.SignalR;
public partial class ProductHub : Hub
{
    public async Task NotifyNewProduct(string productName)
    {
        await Clients.All.SendAsync("ReceiveProduct", productName);
    }
}