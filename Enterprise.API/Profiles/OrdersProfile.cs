using AutoMapper;
using Enterprise.API.Dtos;
using Enterprise.Domain.Entities;

namespace Enterprise.API.Profiles
{
	public class OrdersProfile : Profile
	{
		public OrdersProfile()
		{
			CreateMap<Order, OrderDto>();
		}
	}
}
