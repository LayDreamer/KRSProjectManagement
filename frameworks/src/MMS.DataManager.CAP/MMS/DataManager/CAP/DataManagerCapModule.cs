namespace MMS.DataManager.CAP;

[DependsOn(
    typeof(AbpEventBusModule), 
    typeof(DataManagerLocalizationModule),
    typeof(AbpUnitOfWorkModule))]
public class DataManagerCapModule : AbpModule
{
}