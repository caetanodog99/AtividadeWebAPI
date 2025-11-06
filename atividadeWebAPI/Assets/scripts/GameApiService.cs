using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class GameApiService
{
    private readonly HttpClient httpClient;
    private const string BASE_URL = "https://68f971c1ef8b2e621e7c15fa.mockapi.io";
    public string idteste;

    public GameApiService()
    {
        httpClient = new HttpClient();
    }


    void Start()
    {
        idteste = "1";
    }

    //Métodos dos jogadores

    public async Task<Jogador[]> GetTodosJogadores()
    {
        try
        {
            string url =
            $"{BASE_URL}/Player";
            Debug.Log($"GET: {url}");
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            Debug.Log($"Resposta recebida:{json.Substring(0, Math.Min(200, json.Length))} ...");


            string wrappedJson = $"{{\"jogadores\":{json}}}";
            JogadorArray jogadorArray = JsonUtility.FromJson<JogadorArray>(wrappedJson);
            return jogadorArray.jogadores;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro ao buscar jogadores: {ex.Message} ");
            return new Jogador[0];
        }
    }

    public async Task<Jogador> GetJogador(string id)
    {
        try
        {
            string url = $"{BASE_URL}/Player/{id}";
            Debug.Log($"GET: {url}");

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            Debug.Log($"Jogador recebido: {json}");

            Jogador jogador = JsonUtility.FromJson<Jogador>(json);
            return jogador;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro ao buscar jogador {id}: {ex.Message}");
            return null;
        }
    }

    public async Task<Jogador> AtualizarJogador(Jogador jogador)
    {
        try
        {
            string url = $"{BASE_URL}/Player/1";
            Debug.Log($"PUT: {url}");

            string json = JsonUtility.ToJson(jogador);
            Debug.Log($"JSON sendo enviado: {json}");

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(url, content);

            Debug.Log($"Status da resposta: {response.StatusCode}");
            Debug.Log($"Resposta: {await response.Content.ReadAsStringAsync()}");

            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();
            Debug.Log($"Jogador atualizado: {responseJson}");

            return JsonUtility.FromJson<Jogador>(responseJson);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro ao atualizar jogador: {ex.Message}");
            return null;
        }
    }

    public async Task<Jogador> CriarJogador(Jogador jogador)
    {
        try
        {
            string url = $"{BASE_URL}/Player";
            Debug.Log($"POST: {url}");

            string json = JsonUtility.ToJson(jogador);
            Debug.Log($"JSON sendo enviado: {json}");

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();
            Debug.Log($"Jogador criado: {responseJson}");

            return JsonUtility.FromJson<Jogador>(responseJson);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro ao criar jogador: {ex.Message}");
            return null;
        }
    }

   

    [System.Serializable]
    public class JogadorArray
    {
        public Jogador[] jogadores;
    }




}
