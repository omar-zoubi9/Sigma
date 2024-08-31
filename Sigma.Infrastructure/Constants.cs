namespace Sigma.Infrastructure;

public static class Constants
{
    public static class RepositoryTypes
    {
        public static string Csv = "CSV";

        public static string GetRepositoryTypes()
        {
            return $"{Csv}";
        }
    }
}