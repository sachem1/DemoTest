using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;

namespace ModuleCommon
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OptionService>().As<IOptionService>();
        }
    }
}
