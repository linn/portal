namespace Linn.Service.TestData.SalesArticles
{
    using Linn.Service.Domain.LinnApps;
    using Linn.Service.TestData.Tariffs;

    public class TestSalesArticles
    {
        public static readonly SalesArticle SelektHub =
            new SalesArticle
            {
                ArticleNumber = "SK HUB",
                Description = "SELEKT DSM HUB",
                Tariff = TestTariffs.SoundReproduction,
                TariffId = TestTariffs.SoundReproduction.TariffId
            };
    }
}
