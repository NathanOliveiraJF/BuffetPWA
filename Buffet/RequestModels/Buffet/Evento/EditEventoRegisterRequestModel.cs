using Buffet.Models.Buffet.Cliente;
using System;

namespace Buffet.RequestModels.Buffet.Evento
{
    public class EditEventoRegisterRequestModel
    {
        public EditEventoRegisterRequestModel()
        {

            Nome = "";
            Descricao = "";
            Id = "";
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Id { get; set; }

    }
}