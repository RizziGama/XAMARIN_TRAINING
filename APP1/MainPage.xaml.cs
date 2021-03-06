using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using APP1.Servico.Modulo;
using APP1.Servico;

namespace APP1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            try
            {
                string cep = CEP.Text.Trim();

                if (isValidCEP(cep))
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if(end != null)
                    {
                        
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);

                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado:" + cep, "OK");
                    }
                }

            }
            catch(Exception e)
            { 
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
            }

        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            int NovoCEP = 0;
            if (cep.Length != 8)
            {
                //erro
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
  
            else if(!int.TryParse(cep,out NovoCEP))
            {
                //erro
                valido = false;
                DisplayAlert("ERRO", "CEP inválido! O CEP deve composto apenas por números.", "OK");
            }

            return valido;
        }
    }
}
