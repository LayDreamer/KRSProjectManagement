namespace MMS.DataManager.EntityFrameworkCore
{
    public static class DataManagerEfCoreEntityExtensionMappings
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            DataManagerGlobalFeatureConfigurator.Configure();
            DataManagerModuleExtensionConfigurator.Configure();

            OneTimeRunner.Run(() =>
            {
                ObjectExtensionManager.Instance
               .MapEfCoreProperty<IdentityUser, long>(
                   "DingTalkUserId",
                   (entityBuilder, propertyBuilder) =>
                   {
                       propertyBuilder.HasColumnName("DingTalkUserId");
                       propertyBuilder.HasMaxLength(64);
                   });


                ObjectExtensionManager.Instance
                 .MapEfCoreProperty<OrganizationUnit, long>(
                     "DingTalkOrganizationUnitId",
                     (entityBuilder, propertyBuilder) =>
                     {
                         propertyBuilder.HasColumnName("DingTalkOrganizationUnitId");
                         propertyBuilder.HasMaxLength(64);
                     });
            });
        }
    }
}
