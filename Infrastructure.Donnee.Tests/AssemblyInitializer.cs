using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Infrastructure.Donnee.Tests
{
    [TestClass]
    public class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {

            string solution_dir = Path.GetDirectoryName(Path.GetDirectoryName(context.TestDir));
            var appPathD = System.IO.Path.Combine(solution_dir, "SQLiteClient", "App_Data");

            AppDomain.CurrentDomain.SetData(
               "DataDirectory",
               Path.Combine(appPathD, string.Empty));
        }
    }
}
