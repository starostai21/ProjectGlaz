using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VosemNovKA
{
    interface ICon
    {
        void Sidu_interface(string sql);
        DataSet IConO(string query);
    }
}
