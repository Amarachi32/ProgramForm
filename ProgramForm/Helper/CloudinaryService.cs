using ProgramFormCore.Models;

namespace ProgramForm.Helper
{
    public static class CloudinaryService
    {
        public static void ConfigureUpload(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySetting"));

        }

    }
}
