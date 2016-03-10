using System;

namespace Damasio34.Seedwork.Domain
{
    /// <summary>
    ///     Base class for entities
    /// </summary>
    public abstract class EntidadeBase : IEntidadeBase
    {
        #region [ Construtores ]

        protected EntidadeBase()
        {
            Ativo = true;
            DataDeCadastro = DateTime.Now;            
        }

        protected EntidadeBase(Guid id)
        {
            Ativo = true;
            DataDeCadastro = DateTime.Now;
            this.Id = id;
        }

        #endregion

        #region [ Atributos ]

        private int? _requestedHashCode;

        #endregion

        #region [ Propriedades ]

        /// <summary>
        ///     Get the persisten object identifier
        /// </summary>
        public virtual Guid Id { get; protected set; }
        public DateTime DataDeCadastro { get; protected set; }
        public bool Ativo { get; protected set; }

        #endregion

        #region [ Métodos públicos ]

        /// <summary>
        ///     Check if this entity is transient, ie, without id at this moment
        /// </summary>
        /// <returns>True if entity is transient, else false</returns>
        public bool HasId()
        {
            return Id == Guid.Empty;
        }

        /// <summary>
        ///     Generate id for this entity
        /// </summary>
        public void GerarId()
        {
            if (this.HasId()) this.Id = Guid.NewGuid();
        }

        /// <summary>
        ///     Change current id for a new non transient id
        /// </summary>
        /// <param name="id">the new id</param>
        public void AlterarId(Guid id)
        {
           this.Id = id;
        }

        #endregion

        #region [ Métodos Overrides ]

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntidadeBase))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (EntidadeBase) obj;

            if (item.HasId() || HasId())
                return false;
            return item.Id == Id;
        }

        public override int GetHashCode()
        {
            if (!HasId())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;
                        // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            return base.GetHashCode();
        }

        public static bool operator ==(EntidadeBase left, EntidadeBase right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            return left.Equals(right);
        }

        public static bool operator !=(EntidadeBase left, EntidadeBase right)
        {
            return !(left == right);
        }

        #endregion
    }
}