using System;

namespace Damasio34.Seedwork.Domain
{
    public abstract class EntidadeDoGrupo : EntidadeBase, IEntidadeDoGrupo, IEntidadeBase
    {
        public Grupo Grupo { get; set; }
        public Guid IdGrupo { get; set; }
    }
}