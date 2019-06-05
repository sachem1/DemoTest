using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCommon
{
    public interface IOptionService
    {
         Task<string> GetOptions();
    }


    public class OptionService : IOptionService
    {
        public async Task<string> GetOptions()
        {
            return await Task.FromResult("ddd");
        }
    }
}
