using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

public class AzureDevopsServicesClient
{
    private readonly string _baseUri;

    public HttpClient HttpClient { get; private set; }

    public AzureDevopsServicesClient(string personal_access_token, string baseUri)
    {
        _baseUri = baseUri;
        HttpClient client = new HttpClient();

        try
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personal_access_token))));

        }
        catch (Exception)
        {
            throw;
        }

        HttpClient = client;
    }

    public async void GetProjects()
    {
        try
        {
            var a = ExecuteHttpMethod<object>(HttpMethod.Get, "/_apis/projects", null);

            Console.WriteLine(a);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public T Get<T>(string requestUri, string expectedMediaType = "application/json", bool expectSuccess = true)
    {
        return ExecuteHttpMethod<T>(HttpMethod.Get, requestUri, null, expectedMediaType, expectSuccess);
    }

    public T Post<T>(string requestUri, HttpContent content, string expectedMediaType = "application/json", bool expectSuccess = true)
    {
        return ExecuteHttpMethod<T>(HttpMethod.Post, requestUri, content, expectedMediaType, expectSuccess);
    }

    private T ExecuteHttpMethod<T>(HttpMethod httpMethod, string requestUri, HttpContent? content, string expectedMediaType = "application/json", bool expectSuccess = true)
    {
        requestUri = _baseUri + requestUri;

        HttpClient client = HttpClient;
        Task<HttpResponseMessage> httpTask = null;

        if (httpMethod == HttpMethod.Get) {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(expectedMediaType));
            httpTask = Task.Run(() => client.GetAsync(requestUri));
        } else if (httpMethod == HttpMethod.Post)
        {
            httpTask = Task.Run(() => client.PostAsync(requestUri, content));
        }

        httpTask.Wait();

        HttpResponseMessage response = httpTask.Result;

        if (expectSuccess)
        {
            response.EnsureSuccessStatusCode();

        }

        Task<string> readContentTask = Task.Run(() => response.Content.ReadAsStringAsync());
        readContentTask.Wait();

        string responseBody = readContentTask.Result;

        T deserializedResponse;

        try
        {
            deserializedResponse = JsonConvert.DeserializeObject<T>(responseBody);
        }
        catch (Exception ex)
        {
            // normal, not deserializeable
            deserializedResponse = (T)(object)responseBody;
        }

        return deserializedResponse;
    }
}