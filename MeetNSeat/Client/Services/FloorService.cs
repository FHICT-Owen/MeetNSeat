﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public static class FloorService
    {
        public static async Task<IEnumerable<FloorModel>> GetAllFloorsAndRoomsByLocationId(int id)
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<FloorModel>>($"{Url.Address}/api/floor/{id}");
        }

        public static async Task<IEnumerable<FloorModel>> GetAllFloors()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<FloorModel>>($"{Url.Address}/api/floor");
        }

        public static async Task AddFloor(FloorModel floor)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync($"{Url.Address}/api/floor", floor);
        }
        
        public static async Task DeleteFloor(int id)
        {
            using var client = new HttpClient();
            await client.DeleteAsync($"{Url.Address}/api/floor/{id}");
        }
        
        public static async Task UpdateFloor(FloorModel floor)
        {
            using var client = new HttpClient();
            await client.PutAsJsonAsync($"{Url.Address}/api/floor", floor);
        }
    }
}
