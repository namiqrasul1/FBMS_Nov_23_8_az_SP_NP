using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security;
using System.Security.Permissions;

namespace Lesson1AppDomain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AppDomain domain = AppDomain.CreateDomain("BabatDomain");

            //Type type = typeof(Virus);
            ////Console.WriteLine(type.FullName);
            ////Console.WriteLine(type.Name);
            ////Console.WriteLine(type.Assembly.FullName);

            //domain.CreateInstance(type.Assembly.FullName, type.FullName);

            //AppDomain.Unload(domain);
            //Console.ReadKey();

            //PermissionSet permissions = new PermissionSet(PermissionState.None);
            //permissions.AddPermission(new FileIOPermission(PermissionState.None));
            //permissions.AddPermission(new FileIOPermission(FileIOPermissionAccess.NoAccess, "C://"));
            //var appDomainSetup = new AppDomainSetup();
            //appDomainSetup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            //AppDomain appDomain = AppDomain.CreateDomain("BabatDomain", null, appDomainSetup, permissions);

            //AppDomain.Unload(appDomain);



            // console app
            // butun processler gorunur, sonda ise, New Task, End Task bolmesi olur.
            // eger New Task sechilse, process adi daxil olunur, ve hemin process ishe dushur.
            // eger End Task sechilse, process id'si daxil olunur, ve hemin process kill olunur





        }
    }

    class Virus
    {
        public Virus() { Console.WriteLine("Salam, men hackerem, geldim ogurluga");  }

        //private void Ogurla() { Console.WriteLine("girdim Disk C'e"); }
        ~Virus() { Console.WriteLine("Sagol, her sheyi ogurladim gedirem"); }
    }
}
