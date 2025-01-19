using System;
using FitTakip.Application.DTOs;

namespace FitTakip.Application.Interfaces.Services;

public interface ITokenService
{
    Token CreateAccessToken();
}
