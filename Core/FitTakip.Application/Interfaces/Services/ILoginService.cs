using System;
using FitTakip.Application.Common;
using FitTakip.Application.Parametre;

namespace FitTakip.Application.Interfaces.Services;

public interface ILoginService
{
    Task<Result> GirisYap(GirisYapParametre parametre);
}
