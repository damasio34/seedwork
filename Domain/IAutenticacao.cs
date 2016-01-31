using System;

namespace Damasio34.Seedwork.Domain
{
    public interface IAutenticacao
    {
        Guid IdUsuario { get; }
        Guid IdGrupo { get; set; }
    }
}