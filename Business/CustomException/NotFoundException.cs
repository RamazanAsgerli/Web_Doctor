using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomException
{
    public class NotFoundException : Exception
    {
        public string V { get; set; }
        public NotFoundException(string? message,string v) : base(message)
        {
            V=v;
        }
    }
}
