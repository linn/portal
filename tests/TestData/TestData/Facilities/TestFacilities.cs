namespace Linn.Service.TestData.Facilities
{
    using Linn.Service.Domain.LinnApps;

    public class TestFacilities
    {
        public static readonly Facility Eaglesham = new Facility(
            "LINN",
            "LINN HEAD QUARTERS AT EAGLESHAM",
            "Y",
            "REGISTERED OFFICE: GLASGOW ROAD, WATERFOOT, GLASGOW G76 0EQ. COMPANY REGISTRATION NUMBER 52366.",
            "Please quote RSN number &p_rsn_number with ANY query.");


        public static readonly Facility USA = new Facility(
            "USA",
            "LINN USA SERVICE",
            "N",
            "D.W. LABS, 2475 George Urban Blvd, Depew, NY  14043,  U.S.A",
            "Please quote RSN number &p_rsn_number with any query.");
    }
}
