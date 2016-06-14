using System;
using AutoMapper;
using MvcSample.AngularJs.Web.Models;
using MvcSample.Domain.Entities;

namespace MvcSample.AngularJs.Web
{
    public static class AutomapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<Contact, ContactViewModel>();
                mapper.CreateMap<ContactViewModel, Contact>();
            });
        }
    }
}