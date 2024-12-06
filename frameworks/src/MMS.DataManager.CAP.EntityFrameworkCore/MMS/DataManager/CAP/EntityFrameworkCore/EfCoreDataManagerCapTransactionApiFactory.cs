namespace MMS.DataManager.CAP.EntityFrameworkCore;

public class EfCoreDataManagerCapTransactionApiFactory : IDataManagerCapTransactionApiFactory, ITransientDependency
{
    public Type TransactionApiType { get; } = typeof(EfCoreTransactionApi);

    protected readonly ICapPublisher Publisher;
    protected readonly DataManagerEfCoreDbContextCapOptions Options;
    protected readonly IDataManagerCapDbProviderInfoProvider DataManagerCapDbProviderInfoProvider;
    protected readonly ICancellationTokenProvider CancellationTokenProvider;

    public EfCoreDataManagerCapTransactionApiFactory(
        ICapPublisher publisher,
        IOptions<DataManagerEfCoreDbContextCapOptions> options,
        IDataManagerCapDbProviderInfoProvider abpProCapDbProviderInfoProvider,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        Publisher = publisher;
        Options = options.Value;
        DataManagerCapDbProviderInfoProvider = abpProCapDbProviderInfoProvider;
        CancellationTokenProvider = cancellationTokenProvider;
    }

    public virtual ITransactionApi Create(ITransactionApi originalApi)
    {
        var efApi = (EfCoreTransactionApi)originalApi;

        var capTrans = CreateCapTransactionOrNull(efApi);

        return capTrans is null
            ? originalApi
            : new EfCoreTransactionApi(capTrans, efApi.StarterDbContext, CancellationTokenProvider);
    }

    protected virtual IDbContextTransaction CreateCapTransactionOrNull(EfCoreTransactionApi originalApi)
    {
        // TODO 通过数据库连接字符串判断数据库类型
        // if (Options.CapUsingDbConnectionString != originalApi.StarterDbContext.Database.GetConnectionString())
        // {
        //     return null;
        // }

        var dbProviderInfo = DataManagerCapDbProviderInfoProvider.GetOrNull(originalApi.StarterDbContext.Database.ProviderName);

        if (dbProviderInfo?.CapTransactionType is null || dbProviderInfo.CapEfDbTransactionType is null)
        {
            return null;
        }

        var capTransactionType = dbProviderInfo.CapTransactionType;

        if (ActivatorUtilities.CreateInstance(Publisher.ServiceProvider, capTransactionType) is not CapTransactionBase capTransaction)
        {
            return null;
        }

        capTransaction.DbTransaction = originalApi.DbContextTransaction;
        capTransaction.AutoCommit = false;

        Publisher.Transaction.Value = capTransaction;

        return (IDbContextTransaction)Activator.CreateInstance(dbProviderInfo.CapEfDbTransactionType, capTransaction);
    }
}