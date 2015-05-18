using System.Collections.Generic;

namespace Lim.Web.UI.Repository
{
    public interface ILimRepository
    {
        IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class;
        TItem Item<TItem>(string sql, object param) where TItem : class;
    }

    public interface IUserManagementRepository
    {
        IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class;
        TItem Item<TItem>(string sql, object param) where TItem : class;
    }
}