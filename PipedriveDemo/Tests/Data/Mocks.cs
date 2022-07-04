using Bogus;
using PipedriveDemo.UI.PageObjectModel.Utilities;

namespace PipedriveDemo.Tests.Data
{
    public class Mocks
    {
        private static readonly Faker dataFaker = new Faker("es_MX");
        private static readonly Faker dateFakerUK = new Faker("uk");    // Ukrainian

        // Constants
        public static readonly object[] validDataObjects =
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
                }, "", ""   // here goes your email and password
            },
            new object[]
            {
                new DealModel()
                {
                    ContactPerson = dataFaker.Name.FullName(),
                    Organization = dataFaker.Company.CompanyName(),
                    Title = dataFaker.Hacker.Random.AlphaNumeric(10),
                }, "", ""   // here goes your email and password
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
                }, "", ""   // here goes your email and password
            },
        };

        // Errors
        public static List<string> mandatoryErrors = new List<string>()
        {
            "A person or organization is required",
            "A person or organization is required",
            "Title is required"
        };
    }
}

