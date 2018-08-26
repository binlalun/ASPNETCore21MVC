using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore21MVC.Models
{
    //public class AppSettings : IAppSettings, IAppSettingsScoped, IAppSettingsSingleton
    //{
    //    public AppSettings()
    //    {
    //        this.Name = Guid.NewGuid().ToString();
    //    }

    //    public string Id { get; set; }
    //    public string Name { get; set; }
    //}
    public class AppSettings
    {
        public string IP { get; set; }
    }
}
