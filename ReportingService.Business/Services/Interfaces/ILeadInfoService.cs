﻿namespace ReportingService.Business.Services;

public interface ILeadInfoService
{
    Task<List<int>> GetCelebrantsFromDateToNow(DateTime fromDate);
}