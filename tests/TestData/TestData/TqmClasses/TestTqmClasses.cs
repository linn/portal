namespace Linn.Service.TestData.TqmClasses
{
    using Linn.Service.Domain.LinnApps;

    public class TestTqmClasses
    {
        public static readonly TqmClass FailedOnArrival = new TqmClass("FOA", "FAILED ON ARRIVAL", 0, 1, 1);

        public static readonly TqmClass FailedWithin3Months = new TqmClass("F3M", "FAILED WITHIN 3 MONTHS", 1, 3, 2);

        public static readonly TqmClass FailedUnder2Years = new TqmClass("F2Y", "FAILED 3 MONTHS - 2 YEARS", 3, 24, 3);

        public static readonly TqmClass FailedOver2Years = new TqmClass("FM", "FAILED > 2 YEARS", 24, null, 3);

        public static readonly TqmClass ReturnForUpgrade = new TqmClass("RFU", "RETURN FOR UPGRADE");
    }
}
