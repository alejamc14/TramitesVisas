﻿using System.Linq;
using TramitesVisas.Shared.DTOs;

namespace TramitesVisas.API.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable,
        PaginationDTO pagination)
        {
            return queryable
            .Skip((pagination.Page - 1) * pagination.RecordsNumber)
            .Take(pagination.RecordsNumber);
        }
    }
}