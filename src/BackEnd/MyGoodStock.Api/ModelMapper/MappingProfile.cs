using AutoMapper;
using MyGoodStock.Api.Models.Entity;
using MyGoodStock.Api.Models.ViewModel;

namespace MyGoodStock.Api.ModelMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configuração de mapeamento
            CreateMap<MonthlyProfitReport, MonthlyProfitReportViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Sale, SaleViewModel>().ReverseMap();
            CreateMap<SaleItem, SaleItemViewModel>().ReverseMap();
        }
    }
}
