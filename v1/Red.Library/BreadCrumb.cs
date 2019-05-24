using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.Library
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class BreadCrumb
    {
        public string LinkText { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public bool Voltar { get; set; }

        public string VoltarUrl { get; set; }

        public string Link { get; set; }

        public bool LinkRoot { get; set; }
    }
}
