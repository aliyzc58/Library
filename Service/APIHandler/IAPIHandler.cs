using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.APIHandler
{
    public interface IAPIHandler
    {
        T GetApi<T>(string url);
        T PostApi<T>(dynamic dynamicModel, string Url);
    }
}
