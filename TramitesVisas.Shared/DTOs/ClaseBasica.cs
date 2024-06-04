using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.DTOs
{
    public class ClaseBasica<TItem1, TItem2>
    {

        public TItem1? Item1 { get; set; }

        public TItem2? Item2 { get; set; }

    }
}
