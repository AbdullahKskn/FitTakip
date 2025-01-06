using System;
using FitTakip.Application.Common;
using FitTakip.Application.Parametre;

namespace FitTakip.Application.Interfaces.Services;

public interface IIsletmeService
{
    Task<Result> EgitmenOlustur(EgitmenOlusturParametre parametre);
    Task<Result> EgitmenGuncelle(EgitmenGuncelleParametre parametre);
    Task<Result> EgitmenSil(int EgitmenId);
}
