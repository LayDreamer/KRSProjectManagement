namespace MMS.DataManager.Cli.Utils;

public static class ReplacePackageReferenceExtensions
{
    public static string ReplacePackageReferenceCore(this string content)
    {
        return content
                .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\frameworks\\src\\MMS.DataManager.Core\\MMS.DataManager.Core.csproj\"/>",
                    "<PackageReference Include=\"MMS.DataManager.Core\"/>")
                .Replace("<ProjectReference Include=\"..\\..\\..\\..\\aspnet-core\\frameworks\\src\\MMS.DataManager.Core\\MMS.DataManager.Core.csproj\"/>",
                    "<PackageReference Include=\"MMS.DataManager.Core\"/>")
                .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\shared\\MMS.DataManager.Shared.Hosting.Microservices\\MMS.DataManager.Shared.Hosting.Microservices.csproj\"/>",
                    "<PackageReference Include=\"MMS.DataManager.Shared.Hosting.Microservices\"/>")
                .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\shared\\MMS.DataManager.Shared.Hosting.Gateways\\MMS.DataManager.Shared.Hosting.Gateways.csproj\"/>",
                    "<PackageReference Include=\"MMS.DataManager.Shared.Hosting.Gateways\"/>")
            ;
    }

    public static string ReplacePackageReferenceBasicManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\MMS.DataManager.BasicManagement.Application\\MMS.DataManager.BasicManagement.Application.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.BasicManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\MMS.DataManager.BasicManagement.Application.Contracts\\MMS.DataManager.BasicManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.BasicManagement.Application.Contracts\"/>")
            .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\MMS.DataManager.BasicManagement.Domain\\MMS.DataManager.BasicManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.BasicManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\MMS.DataManager.BasicManagement.Domain.Shared\\MMS.DataManager.BasicManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.BasicManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\MMS.DataManager.BasicManagement.EntityFrameworkCore\\MMS.DataManager.BasicManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.BasicManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\MMS.DataManager.BasicManagement.FreeSqlRepository\\MMS.DataManager.BasicManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FreeSqlRepository\"/>")
            .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\MMS.DataManager.BasicManagement.HttpApi\\MMS.DataManager.BasicManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.BasicManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\MMS.DataManager.BasicManagement.HttpApi.Client\\MMS.DataManager.BasicManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.BasicManagement.HttpApi.Client\"/>");
    }

    public static string ReplacePackageReferenceDataDictionaryManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\MMS.DataManager.DataDictionaryManagement.Application\\MMS.DataManager.DataDictionaryManagement.Application.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.DataDictionaryManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\MMS.DataManager.DataDictionaryManagement.Application.Contracts\\MMS.DataManager.DataDictionaryManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.DataDictionaryManagement.Application.Contracts\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\MMS.DataManager.DataDictionaryManagement.Domain\\MMS.DataManager.DataDictionaryManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.DataDictionaryManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\MMS.DataManager.DataDictionaryManagement.Domain.Shared\\MMS.DataManager.DataDictionaryManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.DataDictionaryManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\MMS.DataManager.DataDictionaryManagement.EntityFrameworkCore\\MMS.DataManager.DataDictionaryManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.DataDictionaryManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\MMS.DataManager.DataDictionaryManagement.FreeSqlRepository\\MMS.DataManager.DataDictionaryManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FreeSqlRepository\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\MMS.DataManager.DataDictionaryManagement.HttpApi\\MMS.DataManager.DataDictionaryManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.DataDictionaryManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\MMS.DataManager.DataDictionaryManagement.HttpApi.Client\\MMS.DataManager.DataDictionaryManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.DataDictionaryManagement.HttpApi.Client\"/>");
    }

    public static string ReplacePackageReferenceFileManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\MMS.DataManager.FileManagement.Application\\MMS.DataManager.FileManagement.Application.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FileManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\MMS.DataManager.FileManagement.Application.Contracts\\MMS.DataManager.FileManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FileManagement.Application.Contracts\"/>")
            .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\MMS.DataManager.FileManagement.Domain\\MMS.DataManager.FileManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FileManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\MMS.DataManager.FileManagement.Domain.Shared\\MMS.DataManager.FileManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FileManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\MMS.DataManager.FileManagement.EntityFrameworkCore\\MMS.DataManager.FileManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FileManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\MMS.DataManager.FileManagement.FreeSqlRepository\\MMS.DataManager.FileManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FreeSqlRepository\"/>")
            .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\MMS.DataManager.FileManagement.HttpApi\\MMS.DataManager.FileManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FileManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\MMS.DataManager.FileManagement.HttpApi.Client\\MMS.DataManager.FileManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FileManagement.HttpApi.Client\"/>");
    }

    public static string ReplacePackageReferenceLanguageManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\MMS.DataManager.LanguageManagement.Application\\MMS.DataManager.LanguageManagement.Application.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.LanguageManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\MMS.DataManager.LanguageManagement.Application.Contracts\\MMS.DataManager.LanguageManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.LanguageManagement.Application.Contracts\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\MMS.DataManager.LanguageManagement.Domain\\MMS.DataManager.LanguageManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.LanguageManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\MMS.DataManager.LanguageManagement.Domain.Shared\\MMS.DataManager.LanguageManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.LanguageManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\MMS.DataManager.LanguageManagement.EntityFrameworkCore\\MMS.DataManager.LanguageManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.LanguageManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\MMS.DataManager.LanguageManagement.FreeSqlRepository\\MMS.DataManager.LanguageManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FreeSqlRepository\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\MMS.DataManager.LanguageManagement.HttpApi\\MMS.DataManager.LanguageManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.LanguageManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\MMS.DataManager.LanguageManagement.HttpApi.Client\\MMS.DataManager.LanguageManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.LanguageManagement.HttpApi.Client\"/>");
    }

    public static string ReplacePackageReferenceNotificationManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\MMS.DataManager.NotificationManagement.Application\\MMS.DataManager.NotificationManagement.Application.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.NotificationManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\MMS.DataManager.NotificationManagement.Application.Contracts\\MMS.DataManager.NotificationManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.NotificationManagement.Application.Contracts\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\MMS.DataManager.NotificationManagement.Domain\\MMS.DataManager.NotificationManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.NotificationManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\MMS.DataManager.NotificationManagement.Domain.Shared\\MMS.DataManager.NotificationManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.NotificationManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\MMS.DataManager.NotificationManagement.EntityFrameworkCore\\MMS.DataManager.NotificationManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.NotificationManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\MMS.DataManager.NotificationManagement.FreeSqlRepository\\MMS.DataManager.NotificationManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.FreeSqlRepository\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\MMS.DataManager.NotificationManagement.HttpApi\\MMS.DataManager.NotificationManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.NotificationManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\MMS.DataManager.NotificationManagement.HttpApi.Client\\MMS.DataManager.NotificationManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"MMS.DataManager.NotificationManagement.HttpApi.Client\"/>");
    }

    public static string ReplaceMMSPackageVersion(this string context, string version)
    {
        return context.Replace("8.3.3.2", version);
    }
}