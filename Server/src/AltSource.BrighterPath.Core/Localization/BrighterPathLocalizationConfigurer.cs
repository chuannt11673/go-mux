using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AltSource.BrighterPath.Localization
{
    public static class BrighterPathLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BrighterPathConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BrighterPathLocalizationConfigurer).GetAssembly(),
                        "AltSource.BrighterPath.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

