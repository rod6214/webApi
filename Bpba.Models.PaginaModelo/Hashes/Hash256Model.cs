using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;

namespace Bpba.Models.PaginaModelo.Hashes
{
    public class Hash256Model : IHash
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
