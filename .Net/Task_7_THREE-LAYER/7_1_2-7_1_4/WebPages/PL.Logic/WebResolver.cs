using UsersAndAwards.Common;

namespace WebPages.PL.Logic
{
    public static class WebResolver
    {
        private static DependencyResolver resolver = null;
        public static string Path { get; private set; }

        public static DependencyResolver Get(string gPath)
        {
            if (resolver == null)
            {
                Path = gPath;

                if (!System.IO.Directory.Exists(gPath))
                {
                    System.IO.Directory.CreateDirectory(gPath);
                }
                resolver = new DependencyResolver(gPath);
            }
            return resolver;
        }
    }
}