using MMS.DataManager.Project.AggregateRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MMS.DataManager.Data.Seed
{
    public class ProjectTemplateSeed : IDataSeedContributor, ITransientDependency
    {
        private readonly IBasicRepository<ProjectTemplate, Guid> repository;

        public ProjectTemplateSeed(IBasicRepository<ProjectTemplate, Guid> repository)
        {
            this.repository = repository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var template1 = new ProjectTemplate()
            {
                Name = "通用项目模板",
                Description = "",
                CreateUser = "admin",
                Data = new Project.Dto.ProjectTemplateData()
                {
                    OpenProjectTarget = true,
                    ProjectTargetSheet = true,
                    ProjectTargetSheetCols = new List<string>() { "阶段一(最小闭环目标)", "阶段二(里程碑目标)", "阶段三(最终目标)" },
                    ProjectTargetSheetRows = new List<string>() { "项目日期区间", "总目标", "部门一", "部门二", "部门三", "部门N" },
                    OpenProjectAnalyza = true,
                    ProjectAnalyzeDatas = new List<string>() { "S优势", "W劣势", "O机会", "S威胁" },
                    OpenProjectReference = false,
                    ProjectReferences = new List<string>() { },
                    OpenProjectCauseAnalysis = false,
                    ProjectCauseAnalysiss = new List<string>() { },
                    OpenProjectImprovementplan = false,
                    ProjectImprovementplans = new List<string>() { },
                }
            };


            var template2 = new ProjectTemplate()
            {
                Name = "研发项目技改模板",
                Description = "",
                CreateUser = "admin",
                Data = new Project.Dto.ProjectTemplateData()
                {
                    OpenProjectTarget = true,
                    ProjectTargetSheet = true,
                    ProjectTargetSheetCols = new List<string>() { "阶段一(最小闭环目标)", "阶段二(里程碑目标)", "阶段三(最终目标)" },
                    ProjectTargetSheetRows = new List<string>() { "项目日期区间", "总目标", "部门一", "部门二", "部门三", "部门N" },
                    OpenProjectAnalyza = true,
                    ProjectAnalyzeDatas = new List<string>() { "S优势", "W劣势", "O机会", "S威胁" },
                    OpenProjectReference = true,
                    ProjectReferences = new List<string>() { "参考一", "参考二", "参考三" },
                    OpenProjectCauseAnalysis = false,
                    ProjectCauseAnalysiss = new List<string>() { },
                    OpenProjectImprovementplan = false,
                    ProjectImprovementplans = new List<string>() { },
                }
            };

            var template3 = new ProjectTemplate()
            {
                Name = "质量DAMIC项目模板",
                Description = "",
                CreateUser = "admin",
                Data = new Project.Dto.ProjectTemplateData()
                {
                    OpenProjectTarget = true,
                    ProjectTargetSheet = false,
                    ProjectTargetSheetCols = new List<string>() { },
                    ProjectTargetSheetRows = new List<string>() { },
                    OpenProjectAnalyza = false,
                    ProjectAnalyzeDatas = new List<string>() { },
                    OpenProjectReference = false,
                    ProjectReferences = new List<string>() { },
                    OpenProblemDefinitionD = true,
                    OpenCurrentLossM = true,
                    OpenProjectCauseAnalysis = true,
                    ProjectCauseAnalysiss = new List<string>() { "问题一", "问题二", "问题三" },
                    OpenProjectImprovementplan = true,
                    ProjectImprovementplans = new List<string>() { "短期方案一", "中期方案二", "长期方案三" },
                }
            };

            await repository.InsertAsync(template1, true);
            await repository.InsertAsync(template2, true);
            await repository.InsertAsync(template3, true);
        }
    }
}
