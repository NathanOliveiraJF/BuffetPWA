using Buffet.Models.Buffet.Cliente;
using System;

namespace Buffet.RequestModels.Buffet.Evento
{
    public class EventoRegisterRequestModel
    {
        public EventoRegisterRequestModel()
        {
            Nome = "";
            Descricao = "";
            TipoEvento = "";
            Cliente = "";
            Situacao = "";
            TextoObservacao = "";
            Local = "";
            DataInicio = "";
            DataTermino = "";
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TipoEvento { get; set; }
        public string Cliente { get; set; }
        public string Situacao { get; set; }
        public string Local { get; set; }
        public string TextoObservacao { get; set; }
        public string DataInicio { get; set; }
        public string DataTermino { get; set; }

    }
}