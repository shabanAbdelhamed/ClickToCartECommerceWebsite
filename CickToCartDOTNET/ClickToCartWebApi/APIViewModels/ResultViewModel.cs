using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickToCartWebApi.APIViewModels
{
    public class ResultViewModel
    {
        public bool success { get; set; }
        public object data { get; set; }
        public string message { get; set; }
    }
}
