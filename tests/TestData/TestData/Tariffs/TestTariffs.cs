namespace Linn.Service.TestData.Tariffs
{
    using Linn.Service.Domain.LinnApps;

    public class TestTariffs
    {
        public static readonly Tariff SoundReproduction =
            new Tariff
            {
                TariffId = 83,
                TariffCode = "8519 8900 00",
                Description = "SOUND REPRODUCING APPARATUS SECTION XVI Machinery and mechanical appliances;electrical equipment;parts thereof;sound recorders and reproducers,television image and sound recorders and reproducers,and parts and accessories of such articles.\r\nElectrical machinery and equipment and parts thereof;sound recorders and reproducers,television image and sound recorders and reproducers,and parts and accessories of such articles.\r\nTurntables(record-decks),record-players,cassette-players and other sound reproducing apparatus,not incoporating a sound recording device:\r\nOther sound reproducing apparatus.",
                ValidForIPR = "Y"
            };
    }
}
