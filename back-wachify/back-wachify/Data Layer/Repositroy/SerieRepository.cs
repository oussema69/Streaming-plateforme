using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_wachify.Business_Logic_Layer.Model;
using back_wachify.Business_Logic_Layer.Interfaces;
using back_wachify.Data;

public class SerieRepository : ISerieRepository
{
    private readonly ApplicationDbContext _context;

    public SerieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Series>> GetAllAsync()
    {
        return await _context.Series.ToListAsync();
    }

    public async Task<Series> GetByIdAsync(int id)
    {
        return await _context.Series.FindAsync(id);
    }

    public async Task<Series> CreateAsync(Series series)
    {
        _context.Series.Add(series);
        await _context.SaveChangesAsync();
        return series;
    }

    public async Task<Series> UpdateAsync(int id, Series updatedSeries)
    {
        var series = await _context.Series.FindAsync(id);
        if (series == null)
        {
            return null;
        }

        series.Title = updatedSeries.Title;
        series.Description = updatedSeries.Description;
        series.realisateur = updatedSeries.realisateur;
        series.ReleaseDate = updatedSeries.ReleaseDate;
        series.IsFree = updatedSeries.IsFree;
        series.Genre = updatedSeries.Genre;

        await _context.SaveChangesAsync();
        return series;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var series = await _context.Series.FindAsync(id);
        if (series == null)
        {
            return false;
        }

        _context.Series.Remove(series);
        await _context.SaveChangesAsync();
        return true;
    }
}
