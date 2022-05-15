using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace CadastroMotorista.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataCpf(this RazorPage page, string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

    }
}
