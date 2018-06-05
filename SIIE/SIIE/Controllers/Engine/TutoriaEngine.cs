using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIIE.Models;


namespace SIIE.Controllers.Engine
{
    public class TutoriaEngine:MainEngine
    {
        public List<Tutorias> getTutorias()
        {
            return db.Tutorias.ToList();
        }

        public void getTutoria(int id)
        {
            
        }

    }
}