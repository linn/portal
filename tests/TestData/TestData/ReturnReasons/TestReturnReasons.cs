namespace Linn.Service.TestData.ReturnReasons
{
    using Linn.Service.Domain.LinnApps;

    public class TestReturnReasons
    {
        public static readonly RsnReturnReason FailedAfterRepair = new RsnReturnReason("FAR", "FAILED AFTER REPAIR - URGENT REPAIR", true, false, "Repair");

        public static readonly RsnReturnReason Faulty = new RsnReturnReason("FAUL", "FAULTY", false, true, "Repair");

        public static readonly RsnReturnReason NoFaultFound = new RsnReturnReason("NFF", "NO FAULT FOUND", false, true, string.Empty);

        public static readonly RsnReturnReason OrderedInError = new RsnReturnReason("OIE", "ORDERED IN ERROR", true, true, "Credit");

        public static readonly RsnReturnReason ReturnedForRepair = new RsnReturnReason("RFR", "RETURN FOR REPAIR", true, true, "Repair");

        public static readonly RsnReturnReason ReturnedForUpgrade = new RsnReturnReason("RFU", "RETURN FOR UPGRADE", true, true, "Upgrade");
    }
}
