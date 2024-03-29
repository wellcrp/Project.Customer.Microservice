﻿using AutoMapper;
using Project.Customer.Application.Commands;
using Project.Customer.Domain.Entities;
using Project.Customer.Domain.Response;

namespace Project.Customer.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerEntities, CustomerResponse>().ReverseMap();
            CreateMap<CustomerEntities, CreateCustomerCommand>().ReverseMap();

        }
    }
}
