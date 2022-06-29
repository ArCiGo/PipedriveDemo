using Bogus;
using PipedriveDemo.UI.PageObjectModel.Utilities;

namespace PipedriveDemo.Tests.Data
{
    public class Mocks
    {
        private static readonly Faker dataFaker = new Faker("es_MX");
        private static readonly Faker dateFakerUK = new Faker("uk");    // Ukrainian

        // Constants
        public static readonly object[] testCases =
        {
            new object[]
            {
                new DealModel()
                {
                    ContactPerson = dataFaker.Name.FullName(),
                    Organization = dataFaker.Company.CompanyName(),
                    Title = dataFaker.Hacker.Random.AlphaNumeric(10),
                    Value = "60000",
                    ExpectedCloseDate = "25/07/2022",
                    Phone = dataFaker.Phone.PhoneNumberFormat(),
                    Email = dataFaker.Internet.Email()
                }, "", ""
            },
            new object[]
            {
                new DealModel()
                {
                    ContactPerson = dataFaker.Name.FullName(),
                    Organization = dataFaker.Company.CompanyName(),
                    Title = dataFaker.Hacker.Random.AlphaNumeric(10),
                }, "", ""
            },
            new object[]
            {
                new DealModel()
                {
                    ContactPerson = dateFakerUK.Name.FullName(),
                    Organization = dateFakerUK.Company.CompanyName(),
                    Title = dateFakerUK.Hacker.Random.AlphaNumeric(10),
                    Value = "60000",
                    ExpectedCloseDate = "25/07/2022",
                    Phone = dateFakerUK.Phone.PhoneNumberFormat(),
                    Email = dateFakerUK.Internet.Email()
                }, "", ""
            },
        };
    }
}

