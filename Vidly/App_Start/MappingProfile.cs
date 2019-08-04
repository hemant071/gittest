﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movies, MoviesDto>();
            Mapper.CreateMap<MoviesDto, Movies>();
            Mapper.CreateMap<Genre, GenreDto>();

           Mapper.CreateMap<MembershipType, MembershipTypeDto>();
          

        }
    }
}