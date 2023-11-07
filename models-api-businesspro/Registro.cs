
namespace models_api_businesspro;
public abstract class Registro
{
    protected readonly BusinessPro businessPro;
    protected readonly HttpClient httpClient;
    protected readonly int id;
    protected readonly int parentId;
    public Registro(string baseUrl, int id = -1, int parentId = -1)
    {
        httpClient = HttpClientSingleton.HttpClient;
        this.id = id;
        this.parentId = parentId;
        businessPro = new(baseUrl, httpClient);
    }
    public abstract Task POST();
    public abstract Task PUT();
    public abstract Task DELETE();
}