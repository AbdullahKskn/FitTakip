using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IPaketRepository
{
    Task<List<Paket>> IsletmeyeAitPaketleriGetirAsync(long IsletmeId);
}
