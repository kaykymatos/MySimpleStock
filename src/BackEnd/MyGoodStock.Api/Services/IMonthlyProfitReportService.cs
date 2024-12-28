﻿using MyGoodStock.Api.Models.ViewModel;

namespace MyGoodStock.Api.Services
{
    public interface IMonthlyProfitReportService : IBaseService<MonthlyProfitReportViewModel>
    {
        Task<MonthlyProfitReportViewModel> GetMonthlyProfitReportByMonth(int month, Guid userId);
    }
}
