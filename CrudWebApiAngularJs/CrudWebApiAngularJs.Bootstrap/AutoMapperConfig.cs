using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Bootstrap
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig(IMapperConfiguration mapperConfiguration)
        {
            Configure(mapperConfiguration);
        }
        public void Configure(IMapperConfiguration mapperConfiguration)
        {
            mapperConfiguration.AddProfile(new AutoMapperProfile(mapperConfiguration));
        }
    }
}
