using AutoMapper;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.ModelMapper
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
            CreateMap<Client, ClientViewModel>().ReverseMap();
        }
    }
}
