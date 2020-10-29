using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Server
{
    public static class Server
    {
        public static List<Client> Clients = new List<Client>();
        public static void NewClient(Socket handle)
        {
            try
            {
                Client newClient = new Client(handle);
                Clients.Add(newClient);
                Console.WriteLine("New client connected: {0}", handle.RemoteEndPoint);
            }
            catch (Exception ex) { Console.WriteLine("Error with addNewClient: {0}.",ex.Message); }
        }
        public static void EndClient(Client client)
        {
            try
            {
                client.End();
                Clients.Remove(client);
                Console.WriteLine("User {0} has been disconnected.", client.UserName);
            }
            catch (Exception ex) { Console.WriteLine("Error with endClient: {0}.",ex.Message); }
        }
        public static void UpdateAllChats()
        {
            try
            {
                int countUsers = Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    Clients[i].UpdateChat();
                }
            }
            catch (Exception ex) { Console.WriteLine("Error with updateAlLChats: {0}.",ex.Message); }
        }
        
    }
}
