﻿using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Enums;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastucture.Repositories;
public class BloodStockRepository : IBloodStockRepository
{
    private readonly BloodDonationSystemDbContext _context;

    public BloodStockRepository(BloodDonationSystemDbContext context)
    {
        _context = context;
    }
    public async Task<BloodStock> Add(BloodStock bloodStock)
    {
        await _context.bloodStocks.AddAsync(bloodStock);
        await _context.SaveChangesAsync();

        return bloodStock;
    }

    public async Task<List<BloodStock>> GetAll()
    {
        var bloodStocks = await _context.bloodStocks.ToListAsync();

        return bloodStocks;
    }

    public async Task<bool> Delete(int id)
    {
        var bloodStock = await _context.bloodStocks.FirstOrDefaultAsync(b => b.Id == id);

        if (bloodStock is null)
        {
            return false;
        }

        bloodStock.Delete();
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<BloodStock?> GetById(int id)
    {
        var bloodStock = await _context.bloodStocks.FirstOrDefaultAsync(b => b.Id == id);

        return bloodStock;
    }

    public async Task<BloodStock?> GetByTypeAndFactor(BloodType bloodType, RgFactor rhFactor)
    {
        var bloodStock = await _context.bloodStocks.FirstOrDefaultAsync(b => b.BloodType == bloodType && b.RgFactor == rhFactor);

        return bloodStock;
    }

    public async Task Update(BloodStock bloodStock)
    {
        _context.bloodStocks.Update(bloodStock);
        await _context.SaveChangesAsync();
    }
}
