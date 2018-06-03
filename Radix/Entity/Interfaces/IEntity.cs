
using System.ComponentModel.DataAnnotations;

namespace Entidade.Interfaces
{
    /// <summary>
    /// Interface da coluna de identificação das entidades
    /// </summary>
    public interface IEntity
    {
        #region Propriedades
        /// <summary>
        /// Get da identificação da entidade
        /// </summary>
        [Key]
        int Id { get; }
        #endregion
    }
}
