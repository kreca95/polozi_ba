using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace polozi_ba.Models.Naslovna
{
    public class IndexViewModel
    {
        public SelectList PredmetiSelectLista { get; set; }
    }
}
