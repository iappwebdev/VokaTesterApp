namespace VokaTester.Tests.Infrastructure
{
    using System;
    using AutoMapper;
    using NUnit.Framework;
    using VokaTester.Infrastructure.Profiles;

    public class AutoMapperConfigTests
    {
        public static IMapper Mapper { get; set; }

        [SetUp]
        public static void Startup(TestContext testContext)
        {
            if (testContext == null)
            {
                throw new ArgumentNullException(nameof(testContext));
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = config.CreateMapper();

            // Alle Mapping sollte komplett im Sinne der Destination Objekte sein, nicht gemappte Properties müssen mit Ignore-Option konfiguriert werden
            config.AssertConfigurationIsValid();
        }
    }
}