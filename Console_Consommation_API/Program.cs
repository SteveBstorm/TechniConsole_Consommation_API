using Console_Consommation_API;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

string baseAdress = "https://localhost:7186/api/";

HttpClient client = new HttpClient();
client.BaseAddress = new Uri(baseAdress);

#region HttpGet
//List<Game> games = new List<Game>();

//using(HttpResponseMessage response = client.GetAsync("game").Result)
//{
//    if(!response.IsSuccessStatusCode)
//    {
//        throw new HttpRequestException();
//    }

//    string json = response.Content.ReadAsStringAsync().Result;
//    games = JsonConvert.DeserializeObject<List<Game>>(json);  
//}

//foreach (Game item in games)
//{
//    Console.WriteLine($"Nom : {item.Name}");
//    Console.WriteLine($"Description : {item.Description}");
//    Console.WriteLine($"********************");
//    Console.WriteLine();
//} 
#endregion

#region HttpPost + récupération de donnée dans la réponse
////Methode login (http post)
Member ConnectedUser = new Member();
var loginForm = new { pseudo = "test", pwd = "test" };

//Comment Envoyer un objet vers l'api
string jsonToSend = JsonConvert.SerializeObject(loginForm);
HttpContent content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");

using (HttpResponseMessage response = client.PostAsync("member/login", content).Result)
{
    //Test obligatoire pour déclencher la requête
    if (!response.IsSuccessStatusCode)
        throw new HttpRequestException();
    //if(response.StatusCode == System.Net.HttpStatusCode.OK)

    string jsonResponse = response.Content.ReadAsStringAsync().Result;
    ConnectedUser.Token = jsonResponse;
}
#endregion


Profil profil;
//intégration du token dans le header de la requete
client.DefaultRequestHeaders.Authorization = new
AuthenticationHeaderValue("Bearer", ConnectedUser.Token);

using(HttpResponseMessage response = client.GetAsync("member/1").Result)
{
    if (!response.IsSuccessStatusCode) throw new HttpRequestException();

    string json = response.Content.ReadAsStringAsync().Result;
    profil = JsonConvert.DeserializeObject<Profil>(json);
}

Console.WriteLine($"Pseudo : {profil.Pseudo}");
Console.WriteLine();
Console.WriteLine("Liste de favoris");
Console.WriteLine();
foreach (Game item in profil.favoriteList)
{
    Console.WriteLine($"Nom du jeu : {item.Name}");
}

