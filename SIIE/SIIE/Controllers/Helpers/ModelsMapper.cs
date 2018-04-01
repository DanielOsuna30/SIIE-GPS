using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SIIE.Controllers.Helpers
{
    public class ModelsMapper
    {
        protected MapperConfiguration map;

        /// <summary>
        /// Mappear alumno
        /// </summary>
        /// <param name="UpdateData"></param>
        /// <param name="AlumnoData"></param>
        /// <returns></returns>
        public Alumno convertAlumno(UserModels.UserData UpdateData,Alumno AlumnoData)
        {
            map = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModels.UserData, Alumno>()
                .ForMember(x => x.Nombre, opts => opts.MapFrom(x => x.FirstName))
                .ForMember(x => x.ApellidoP, opts => opts.MapFrom(x => x.LastNameP))
                .ForMember(x => x.ApellidoM, opts => opts.MapFrom(x => x.LastNameM));
            });

            Alumno MappedData = map.CreateMapper().Map(UpdateData, AlumnoData);
            return MappedData;
        }
    }
}