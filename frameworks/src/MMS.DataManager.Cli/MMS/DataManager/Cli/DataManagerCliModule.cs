namespace MMS.DataManager.Cli;

[DependsOn(
    typeof(MMS.DataManager.Cli.DataManagerCliCoreModule),
    typeof(AbpAutofacModule)
)]
public class DataManagerCliModule : AbpModule
{
}
