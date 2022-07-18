using System;
using System.Net;
using APP1.Servico.Modulo;
using Newtonsoft.Json;

namespace APP1.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {

                string NovoEnderecoURL = string.Format(EnderecoURL, cep);

                WebClient wc = new WebClient();
                string Conteudo = wc.DownloadString(NovoEnderecoURL);

                Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

                if (end.cep == null) return null;

                return end;


        }
    }
}
