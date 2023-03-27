using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBVL.Sistema.Domain.Core.Enums
{
    public enum Situacao
    {
        Ativo = 'A',
        AfastadoVoluntariamente ='V',
        DesligadoVoluntariamente ='D',
        Excluido='X',
        Impossibilitado ='I',
        Transferido,
        Falecido = 'F',

    }
    public enum FormaAdimissao
    {
        ProfissaoFeBatismo,
        TransferidoOutraIgreja       

    }
}
