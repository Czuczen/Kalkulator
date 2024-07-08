using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Parameters
{
    public class SessionParameters
    {
        public bool ReadOnly { get; }
        public bool Config { get; }
        public string Name { get; }

        public SessionParameters(bool readOnly, bool config, string name)
        {
            ReadOnly = readOnly;
            Config = config;
            Name = name;
        }
    }
}
