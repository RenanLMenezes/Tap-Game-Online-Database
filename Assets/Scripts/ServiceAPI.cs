using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class ServiceAPI 
{
    const string URL = "https://frozen-shore-49283.herokuapp.com/";

    public static HttpClient GetClient()
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("Connection", "close");
        return client;
    }

    public static async Task<User> GetUser(string nick)
    {
        HttpClient client = GetClient();
        var responsive = await client.GetAsync($"{URL}user/{nick}");
        if(responsive.IsSuccessStatusCode)
        {
            string content = await responsive.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(content);
        }

        return new User();
    }
    
    public static async Task<User> GetUser()
    {
        HttpClient client = GetClient();
        var responsive = await client.GetAsync($"{URL}highscore");
        if(responsive.IsSuccessStatusCode)
        {
            string content = await responsive.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(content);
        }

        return new User();
    }

    public static async void SetScore(string nick, int score) 
    {
        HttpClient client = GetClient();
        HttpContent content = null;
        await client.PutAsync($"{URL}user/{nick}/score{score}", content);
    }
}
