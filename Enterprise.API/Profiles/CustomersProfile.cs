using AutoMapper;
using Enterprise.API.Dtos;
using Enterprise.Domain.Entities;

namespace Enterprise.API.Profiles
{
	public class CustomersProfile : Profile
	{
		public CustomersProfile()
		{
			CreateMap<Customer, CustomerDto>()
				.ForMember(
					dest => dest.Name,
					opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
		}
	}
}
