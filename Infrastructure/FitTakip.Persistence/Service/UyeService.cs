using System;
using FitTakip.Application.Common;
using FitTakip.Application.DTOs;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Domain.Entities;

namespace FitTakip.Persistence.Service;

public class UyeService : IUyeService
{
    private readonly IRandevuRepository _randevuRepository;
    private readonly IOlcumRepository _olcumRepository;

    public UyeService(IRandevuRepository randevuRepository, IOlcumRepository olcumRepository)
    {
        _randevuRepository = randevuRepository;
        _olcumRepository = olcumRepository;
    }

    public async Task<Result> RandevulariGetirPagination(int UyeId, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet)
    {
        try
        {
            var randevular = await _randevuRepository.UyeyeAitRandevulariTariheGoreGetirAsync(UyeId, BaslangicTarih, BitisTarih, Baslangic, Adet);

            if (!randevular.Any())
                return new Result(false, "Seçilen Üyeye Ait Seçilen Tarih Aralığında Randevu Bulunmamaktadır.");

            var randevuDto = randevular.Select(s => new RandevuDto
            {
                RandevuId = s.RandevuId,
                UyeId = s.UyeId,
                EgitmenId = s.EgitmenId,
                Tarih = s.Tarih,
                Aciklama = s.Aciklama
            }).ToList();

            return new Result(true, "Seçilen Üyeye Ait Randevu Getirme Başarılı", randevuDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> OlcumleriGetirPagination(int UyeId, int Baslangic, int Adet)
    {
        try
        {
            var olcumler = await _olcumRepository.UyeyeAitOlcumleriGetirAsync(UyeId, Baslangic, Adet);

            if (!olcumler.Any())
                return new Result(false, "Seçilen Üyeye Ait Ölçüm Bulunamamaktadır.");

            var olcumDto = olcumler.Select(s => new OlcumDto
            {
                OlcumId = s.OlcumId,
                UyeId = s.UyeId,
                Tarih = s.Tarih,
                Boy = s.Boy,
                Kilo = s.Kilo,
                Omuz = s.Omuz,
                Gogus = s.Gogus,
                SagKol = s.SagKol,
                SolKol = s.SolKol,
                Bel = s.Bel,
                Kalca = s.Kalca,
                SagBacak = s.SagBacak,
                SolBacak = s.SolBacak
            }).ToList();

            return new Result(true, "Üyeye Ait Ölçüm Getirme Başarılı", olcumDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
