using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Tags.Commands
{
    public class AtualizarTagCommand : IRequest<(string, bool)>
    {
        [Required(ErrorMessage = " id do usuario é obrigatório")]
        public required Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "cor é obrigatório")]
        public required string Cor { get; set; }

    }

}

internal class AtualizarTagHandle : IRequestHandle<AtualizarTagCommand, (string, bool)>
{
    public Task<(string, bool)> Handle(AtualizarTagCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}