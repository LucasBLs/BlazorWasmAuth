﻿using BlazorWasmAuth.Core.Handlers;
using BlazorWasmAuth.Core.Requests.Account;
using BlazorWasmAuth.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWasmAuth.Web.Pages.Identity;

public partial class LoginPage : ComponentBase
{
    #region Dependencies
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IAccountHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    [Inject]
    public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    #endregion

    #region Properties
    public bool IsBusy { get; set; } = false;
    public LoginRequest InputModel { get; set; } = new();
    #endregion

    #region Overrides
    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity != null && user.Identity.IsAuthenticated)
            Navigation.NavigateTo("/");
    }
    #endregion

    #region Methods
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.LoginAsync(InputModel);
            if (result.IsSuccess)
            {
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                AuthenticationStateProvider.NotifyAuthenticationStateChanged();
                Navigation.NavigateTo("/");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
    #endregion
}