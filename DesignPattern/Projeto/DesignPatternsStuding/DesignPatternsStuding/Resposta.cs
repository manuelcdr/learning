using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public interface IResposta
    {
        IResposta Proximo { set; }
        string Responde(Requisicao requisicao, Conta conta);
    }

    public class RespostaXML : IResposta
    {
        public IResposta Proximo { private get; set; }

        public string Responde(Requisicao requisicao, Conta conta)
        {
            if (requisicao.Formato.Equals(Formato.XML))
            {
                string xml = "<conta>";
                xml += $"<titular>{conta.Titular}</titular>";
                xml += $"<saldo>{conta.Saldo}</saldo>";
                return xml;
            }
            else
            {
                return Proximo.Responde(requisicao, conta);
            }


        }
    }

    public class RepostaPorcento : IResposta
    {
        public IResposta Proximo { private get; set; }

        public string Responde(Requisicao requisicao, Conta conta)
        {
            if (requisicao.Formato.Equals(Formato.PORCENTO))
            {
                return $"{conta.Titular}%{conta.Saldo}";
            }
            else
            {
                return Proximo.Responde(requisicao, conta);
            }
        }
    }

    public class RepostaSVC : IResposta
    {
        public IResposta Proximo { private get; set; }

        public string Responde(Requisicao requisicao, Conta conta)
        {
            if (requisicao.Formato.Equals(Formato.SVC))
            {
                return $"{conta.Titular};{conta.Saldo}";
            }
            else
            {
                if (Proximo != null) { 
                    return Proximo.Responde(requisicao, conta);
                }
                else
                {
                    return "";
                }
            }
        }
    }

    public class SemResposta : IResposta
    {
        public IResposta Proximo { private get; set;  }

        public string Responde(Requisicao requisicao, Conta conta)
        {
            return "";
        }
    }

}
