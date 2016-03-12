using System;

namespace Damasio34.Seedwork.Domain
{
    public interface IEntidadeBase
    {
        // Propriedades
        Guid Id { get; }
        DateTime DataDeCadastro { get; }
        bool Ativo { get; }
    }
}