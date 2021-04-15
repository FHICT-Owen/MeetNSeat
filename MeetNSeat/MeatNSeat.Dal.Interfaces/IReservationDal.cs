using System.Collections.Generic;
using MeatNSeat.Dal.Interfaces;

namespace MeatNSeat.Dal.Interfaces
{
    public interface IReservationDal
    {
        /// <summary>
        /// Get all the reservations from the database
        /// </summary>
        /// <returns></returns>
        List<ReservationDto> GetAllReservations();
        /// <summary>
        /// Create a new reservation in the database
        /// </summary>
        void CreateReservation();
    }
}