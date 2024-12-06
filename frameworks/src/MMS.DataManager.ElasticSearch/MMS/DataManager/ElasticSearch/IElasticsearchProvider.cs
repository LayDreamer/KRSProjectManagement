namespace MMS.DataManager.ElasticSearch;

public interface IElasticsearchProvider
{
    IElasticClient GetClient();
}