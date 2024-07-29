using BlazorWasmAuth.Core.Requests.Account;
using BlazorWasmAuth.Core.Responses;

namespace BlazorWasmAuth.Core.Handlers;
public interface IAccountHandler
{
    Task<Response<string>> LoginAsync(LoginRequest request);
    Task<Response<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}