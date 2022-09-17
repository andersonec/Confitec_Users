using System;
using System.Text.RegularExpressions;

namespace users.Infra.CrossCutting.Validation
{
    public class Validation
    {
        public static string IsNameValid(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                return "Por favor, digite um nome."; ;
            }
            if (nome.Length > 50)
            {
                return "O nome não pode conter mais de 50 caracteres.";
            }

            for (int i = 0; i < nome.Length; i++)
            {
                if (Regex.IsMatch(nome[i].ToString(), @"^[0-9]+$") == true)
                {
                    return "O nome não pode conter caracteres especiais e nem números.";
                }
            }
            return null;
        }

        public static string IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email) || email.Length < 5)
                return "Digite um email válido";

            Regex rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (rg.IsMatch(email))
            {
                return null;
            }
            else
            {
                return "Email Inválido!";
            }
        }

        public static string IsCpfValid(string cpf)
        {
            if (String.IsNullOrEmpty(cpf) || cpf.Length < 5)
                return "Digite um cpf válido";

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return "O CPF precisa conter 11 dígitos numéricos.";
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            if (cpf.EndsWith(digito) == false)
            {
                return "CPF inválido";
            }
            else
            {
                return null;
            }
        }
    }
}
