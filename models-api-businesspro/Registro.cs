namespace models_api_bussinesspro
{
    public abstract class Registro
    {
        protected readonly HttpClient client;
        protected readonly BussinesPro bussinesPro;
        protected readonly int id;
        protected readonly int parentId;
        public Registro(int id = -1, int parentId = -1)
        {
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };
            client = new(httpClientHandler);
            bussinesPro = new(Environment.GetEnvironmentVariable("BUSSINES_PRO_BASE_URL"), client);
            this.id = id;
            this.parentId = parentId;
        }
        public abstract Task<CrearResponse> POST();
        public abstract Task<ActualizarResponse> PUT();
        public abstract Task<EliminarResponse> DELETE();
    }
}