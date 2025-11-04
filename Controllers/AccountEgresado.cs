using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Info360_EFSI.Models;

namespace Info360_EFSI.Controllers;

public class AccountEgresado : Controller
{
    private readonly ILogger<AccountEgresado> _logger;

    public AccountEgresado(ILogger<AccountEgresado> logger)
    {
        _logger = logger;
    }
}