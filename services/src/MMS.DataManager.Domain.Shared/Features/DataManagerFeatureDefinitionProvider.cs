using Volo.Abp.Features;
using Volo.Abp.Validation.StringValues;

namespace MMS.DataManager.Features;

public class DataManagerFeatureDefinitionProvider : FeatureDefinitionProvider
{
    public override void Define(IFeatureDefinitionContext context)
    {
       
        var group = context.AddGroup(DataManagerFeatures.GroupName,L("Feature:TestGroup"));
        
        // ToggleStringValueType bool类型 前端渲染为checkbox
        group.AddFeature(DataManagerFeatures.TestEnable,
            "true",
            L("Feature:TestEnable"),
            L("Feature:TestEnable"),
            new ToggleStringValueType());
        
        // ToggleStringValueType string类型 前端渲染为input
        group.AddFeature(DataManagerFeatures.TestString,
            "输入需要设定的值",
            L("Feature:TestString"),
            L("Feature:TestString"),
            new FreeTextStringValueType());
        
        // todo SelectionStringValueType select标签待定
    }
    
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataManagerResource>(name);
    }
}