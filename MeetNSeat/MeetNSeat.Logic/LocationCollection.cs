using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class LocationCollection : IManageLocation
    {
        private static LocationCollection _instance;
        private static readonly object Padlock = new object();
        private readonly List<Location> _locations = new ();
        private readonly ILocationDal _dal;

        public LocationCollection()
        {
            _dal = LocationFactory.CreateIssueDal();
        }

        public static LocationCollection Instance
        {
            get
            {
                lock (Padlock)
                {
                    // ReSharper disable once ConvertIfStatementToNullCoalescingExpression
                    if (_instance == null)
                    {
                        _instance = new LocationCollection();
                    }
                    return _instance;
                }
            }
        }
        
        public IReadOnlyCollection<Location> GetAllLocations() 
        {
            _locations.Clear();

            _dal.GetAllLocations().ForEach(
                dto => _locations.Add(new Location(dto)));
			
            return _locations.AsReadOnly();
        }
    
        public void AddLocation(Location location)
        {
            _locations.Add(location);
            _dal.AddLocation(location.ConvertToDto());
        }

    }
}
