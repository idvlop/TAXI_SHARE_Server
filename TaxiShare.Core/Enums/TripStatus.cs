using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Domain.Enums
{
    /// <summary>
    /// Статус поездки
    /// </summary>
    public enum TripStatus
    {
        /// <summary>
        /// Открыта
        /// </summary>
        Opened,
        /// <summary>
        /// В пути
        /// </summary>
        OnWay,
        /// <summary>
        /// Закрыта
        /// </summary>
        Closed
    }
}
