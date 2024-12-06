namespace MMS.DataManager.CAP;

public class DataManagerCapPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var abpIdentityGroup = context.GetGroup(DataManagerCapPermissions.CapManagement.Default);

        abpIdentityGroup.AddPermission(DataManagerCapPermissions.CapManagement.Cap, L("Permission:Cap"), multiTenancySide: MultiTenancySides.Both);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataManagerLocalizationResource>(name);
    }
}