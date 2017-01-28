using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows;

[assembly: AssemblyTitle("FrenchChars")]
[assembly: AssemblyDescription("A tool to quickly pick French special characters")]
#if DEBUG
    [assembly: AssemblyConfiguration("DEBUG")]
#else
    [assembly: AssemblyConfiguration("RELEASE")]
#endif
[assembly: AssemblyCompany("FoxTricks")]
[assembly: AssemblyProduct("FrenchChars")]
[assembly: AssemblyCopyright("Copyright © foxtricks 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]
[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]
[assembly: AssemblyVersion("0.0.1.0")]
[assembly: AssemblyFileVersion("0.0.1.0")]
[assembly: InternalsVisibleTo("FrenchChars.Tests")]