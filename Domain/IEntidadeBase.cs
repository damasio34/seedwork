using System;

namespace Damasio34.Seedwork.Domain
{
    public interface IEntidadeBase
    {
        Guid Id { get; }
        DateTime DataDeCadastro { get; }
        bool Ativo { get; }

        bool HasId();
        void GerarId();
        void AlterarId(Guid id);
    }
}