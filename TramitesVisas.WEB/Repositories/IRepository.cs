﻿using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace TramitesVisas.WEB.Repositories
{
    public interface IRepository
    {

        Task<HttpResponseWrapper<T>> GetAsync<T>(string url);
        Task<HttpResponseWrapper<T>> GetAsync<T>(string url, string url2);
        Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model);
        Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> DeleteAsync(string url);
        Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T model);
        Task<HttpResponseWrapper<TResponse>> PutAsync<T, TResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> Get(string url);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T model);

    }
}
