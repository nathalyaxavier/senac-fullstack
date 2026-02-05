using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Tags.Commands
{

    public class InativarTagCommand : IRequest<(string, bool)>
    {
        [Required(ErrorMessage = " id do usuario é obrigatório")]
        public required Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "É necessário informar o Id")]
        public required Guid Id { get; set; }
    }

    internal class InativarTagCommandHandler : IRequestHandler<InativarTagCommand, (string, bool)>
    {
        public Task<(string, bool)> Handle(InativarTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
