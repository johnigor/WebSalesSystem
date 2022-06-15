using System;

namespace SalesWebMvc.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }

        //a fun��o retorna se ele n�o for nulo ou vazio
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}