using HomesEngland.UseCase.ImportAssets;
using Main;

namespace HomesEngland.AssetImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var assetRegister = new DependencyRegister();
            IConsoleImporter assetImporter = assetRegister.Get<IConsoleImporter>();
            assetImporter.ProcessAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
