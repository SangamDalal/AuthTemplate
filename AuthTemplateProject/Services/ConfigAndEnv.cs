namespace AuthTemplateProject.Services
{
    public class ConfigAndEnv : IConfigAndEnv
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        public ConfigAndEnv(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this._configuration = configuration;
            this._environment = environment;
        }
        public List<string> get()
        {
            
            List<string> env = new List<string> { _configuration["JwtSettings:IssuerIs"], _environment.EnvironmentName };

            return env;
        }
    }
}
