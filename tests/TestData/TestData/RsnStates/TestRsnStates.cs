namespace Linn.Service.TestData.RsnStates
{
    using Linn.Service.Domain.LinnApps;
    using Linn.Service.TestData.ProcessTeams;

    public class TestRsnStates
    {
        public static readonly RsnState Open = new RsnState("OP", "OPENED", "I")
        {
            ProcessTeam = TestProcessTeams.MaterialHandling,
            DateActionedPrompt = "Date Entered",
            ActionedByPrompt = "Entered By",
            SortOrder = 0
        };

        public static readonly RsnState Received = new RsnState("RE", "RECEIVED AT GOODS INWARD", "T")
        {
            ProcessTeam = TestProcessTeams.GoodsIn,
            DateActionedPrompt = "Date Received",
            ActionedByPrompt = "Received By",
            SortOrder = 1
        };

        public static readonly RsnState WithEngineer = new RsnState("EN", "WITH RSN ENGINEER", "T")
        {
            ProcessTeam = TestProcessTeams.RsnEngineers,
            DateActionedPrompt = "Date passed on",
            ActionedByPrompt = "Worked on by",
            SortOrder = 2
        };

        public static readonly RsnState AtAssembly = new RsnState("AS", "AT ASSEMBLY", "T")
        {
            ProcessTeam = TestProcessTeams.Assembly,
            DateActionedPrompt = "Date passed to OSA",
            ActionedByPrompt = "Assembler",
            SortOrder = 3
        };

        public static readonly RsnState WithService = new RsnState("SE", "WITH SERVICE ADMIN", "T")
        {
            ProcessTeam = TestProcessTeams.Service,
            DateActionedPrompt = "Date",
            ActionedByPrompt = "Processed By",
            SortOrder = 4
        };

        public static readonly RsnState DespatchPreparation = new RsnState("PA", "DESPATCH PREPARATION", "T")
        {
            ProcessTeam = TestProcessTeams.Assembly,
            DateActionedPrompt = "Sent to Despatch by",
            ActionedByPrompt = "Sent to Despatch on",
            SortOrder = 5
        };

        public static readonly RsnState WithDespatch = new RsnState("DE", "WITH DESPATCH", "T")
        {
            ProcessTeam = TestProcessTeams.Despatch,
            DateActionedPrompt = "With Despatch",
            ActionedByPrompt = "With Despatch",
            SortOrder = 6
        };

        public static readonly RsnState ReturnedToCustomer = new RsnState("RT", "RETURNED TO CUSTOMER", "F")
        {
            ProcessTeam = TestProcessTeams.Despatch,
            DateActionedPrompt = "Date shipped",
            ActionedByPrompt = "Processed by",
            SortOrder = 7
        };
    }
}
