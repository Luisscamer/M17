using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M17
{
    internal interface IItem
    {
        void Adicionar();

        void Apagar();

        List<string> Validar();
    }
}
