using System.Data.Common;

namespace Eventify.Modules.Events.Application.Abstractions;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}