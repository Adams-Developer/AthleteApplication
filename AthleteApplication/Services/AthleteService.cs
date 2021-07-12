using AthleteApplication.Models;
using AthleteApplication.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AthleteApplication.Services
{
    public class AthleteService
    {
        private  AthleteDbContext _dbContext;
        //private AthleteViewModel _athleteViewModel;

        public AthleteService(AthleteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AthleteViewModel> SaveRecord(AthleteViewModel viewModel)
        {
            var record = new Athletes
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                SchoolName = viewModel.SchoolName,
                Sport = viewModel.Sport,
                InstagramHandle = viewModel.InstagramHandle,
                EmailAddress = viewModel.EmailAddress,
                TwitterHandle = viewModel.TwitterHandle,
                StreetAddress = viewModel.StreetAddress,
                ApartmentNumber = viewModel.ApartmentNumber,
                City = viewModel.City,
                State = viewModel.State,
                ZipCode = viewModel.ZipCode,
                MerchSize = viewModel.MerchSize
            };

            await _dbContext.Athletes.AddAsync(record);
            await _dbContext.SaveChangesAsync();

            return viewModel;
        }

        public List<Cities> GetCities()
        {
            return _dbContext.Cities.ToList();
        }

        public List<Sizes> GetSizes()
        {
            return _dbContext.Sizes.ToList();
        }

        //public void PopulateSizeDropDownList(object selectedSize = null)
        //{
        //    var sizesQuery = from x in _dbContext.Sizes
        //                     orderby x.SizeId
        //                     select x;
        //    _athleteViewModel.SizeSelectList = new SelectList(sizesQuery, "SizeId", "Size", selectedSize);
            
        //}
    }
}
