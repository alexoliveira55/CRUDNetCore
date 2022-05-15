using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroMotorista.Util
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return null;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;

            string digito, tempCpf, Cpf;

            Cpf = value.ToString().Trim();
            Cpf = Cpf.Replace(".", "").Replace("-", "");

            if (Cpf.Length != 11)
                return new ValidationResult("Cpf Inválido.");

            tempCpf = Cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = String.Concat(tempCpf, digito);
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (Cpf.EndsWith(digito))
                return null;
            else
                return new ValidationResult("Cpf Inválido.");
        }

        public override string FormatErrorMessage(string name)
        {
            return name;
        }
    }
}
