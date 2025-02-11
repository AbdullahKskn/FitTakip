using System;
using FitTakip.Application.Common;

namespace FitTakip.Application.Interfaces.Services;

public interface IUyeService
{
    Task<Result> RandevulariGetirPagination(int UyeId, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet);
    Task<Result> OlcumleriGetirPagination(int UyeId, int Baslangic, int Adet);
}
