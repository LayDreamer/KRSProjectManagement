namespace MMS.DataManager.BasicManagement.Features.Dtos;

public class DeleteFeatureInput : IValidatableObject
{
    public string ProviderName { get; set; }

    public string ProviderKey { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var localization = validationContext.GetRequiredService<IStringLocalizer<DataManagerLocalizationResource>>();
        if (ProviderName.IsNullOrWhiteSpace())
        {
            yield return new ValidationResult(
                localization[DataManagerLocalizationErrorCodes.ErrorCode100003, nameof(ProviderName)],
                new[] { nameof(ProviderName) }
            );
        }

        if (ProviderKey.IsNullOrWhiteSpace())
        {
            yield return new ValidationResult(
                localization[DataManagerLocalizationErrorCodes.ErrorCode100003, nameof(ProviderKey)],
                new[] { nameof(ProviderKey) }
            );
        }
    }
}