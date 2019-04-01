using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using polozi_ba.Data;
using polozi_ba.Data.Models;

namespace polozi_ba.Models.Naslovna
{
    public class IndexViewModel
    {
        public SelectList PredmetiSelectLista { get; set; }
        public SelectList GradoviSelectLista { get; set; }

        public polozi_ba.Data.Models.Predmet Predmet { get; set; }
        public Grad Grad { get; set; }
    }
}
