using System.Data.Common;
using Dapper;
using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Application.Abstractions.Messaging;
using Eventify.Modules.Events.Application.Categories.GetCategory;
using FluentResults;

namespace Eventify.Modules.Events.Application.Categories.GetCategoriesQuery;

internal sealed class GetCategoriesQueryHandler(IDbConnectionFactory dbConnectionFactory) 
    : IQueryHandler<GetCategoriesQuery, IReadOnlyCollection<CategoryResponse>>
{
    public async Task<Result<IReadOnlyCollection<CategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();
        
        const string sql =
            $"""
             SELECT
                 id AS {nameof(CategoryResponse.Id)},
                 name AS {nameof(CategoryResponse.Name)},
                 is_archived AS {nameof(CategoryResponse.IsArchived)}
             FROM events.categories
             """;
        
        return (await connection.QueryAsync<CategoryResponse>(sql)).AsList();
    }
}