
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_SignalR_Angular.Hubs
{
    public static class Contador
    {
        public static int valor;
        public static IList<String> conectados = new List<string>();
    }

  


    public class ContadorHub : Microsoft.AspNetCore.SignalR.Hub
    {

        public override Task OnConnectedAsync()
        {

            Contador.conectados.Add(Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public async Task GetContador()
        {
            await Clients.Caller.SendAsync("getContador", Contador.valor);
        }

        public async Task SomaContador()
        {
            Contador.valor++;
            await BroadCastContador();
        }

        public async Task BroadCastContador()
        {
            await Clients.All.SendAsync("broadcastContador", Contador.valor);
        }

        public Task OnConnected()
        {
            throw new NotImplementedException();
        }

        public Task OnReconnected()
        {
            throw new NotImplementedException();
        }

        public Task OnDisconnected(bool stopCalled)
        {
            throw new NotImplementedException();
        }
    }
}
