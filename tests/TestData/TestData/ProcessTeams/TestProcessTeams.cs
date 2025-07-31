namespace Linn.Service.TestData.ProcessTeams
{
    using Linn.Service.Domain.LinnApps;
    using Linn.Service.TestData.Facilities;

    public class TestProcessTeams
    {
        public static readonly ProcessTeam Assembly = new ProcessTeam("ASSEMBLY", "ASSEMBLY", TestFacilities.Eaglesham);

        public static readonly ProcessTeam Despatch = new ProcessTeam("DESPATCH", "DESPATCH", TestFacilities.Eaglesham);

        public static readonly ProcessTeam GoodsIn = new ProcessTeam("GOODSIN", "GOODS INWARD", TestFacilities.Eaglesham);

        public static readonly ProcessTeam MaterialHandling = new ProcessTeam("MATHAND", "MATERIALS HANDLING", TestFacilities.Eaglesham);

        public static readonly ProcessTeam RsnEngineers = new ProcessTeam("RSNENG", "RSN ENGINEERS", TestFacilities.Eaglesham);

        public static readonly ProcessTeam Service = new ProcessTeam("SERVICE", "SERVICE", TestFacilities.Eaglesham);
    }
}
