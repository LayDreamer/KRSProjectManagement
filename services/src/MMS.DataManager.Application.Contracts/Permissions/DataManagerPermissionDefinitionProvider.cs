namespace MMS.DataManager.Permissions
{
    public class DataManagerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DataManagerResource>(name);
        }
    }
}