using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.Word;
using Novacode;
using System.IO;

namespace SIIE.Controllers.Helpers
{
    public class DocumentsManager
    {
        string fileName ="";
        string filePath = (AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" );

        /// <summary>
        /// Crear pdf para la ficha de inscripcion
        /// </summary>
        public string InscriptionFoil(string CN)
        {
            filePath += "inscriptionTemplate.docx";
            fileName += "FolioReinscripcion"+CN+".docx";
            DocX doc = DocX.Load(filePath);
            doc.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            return fileName;
        }

        /// <summary>
        /// Crear pdf para ficha de reinscripcion
        /// </summary>
        public string ReinscriptionFoil(string CN)
        {
            filePath += "reinscriptionTemplate.docx";
            fileName += "FolioReinscripcion"+CN+".docx";
            DocX doc = DocX.Load(filePath);
            doc.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\"+fileName);
            return fileName;
        }

        /// <summary>
        /// Crear pdf para historial academico
        /// </summary>
        public string CarrerHistory(string CN)
        {
            filePath += "carrerTemplate.docx";
            fileName += "HistorialAcademico" + CN + ".docx";
            DocX doc = DocX.Load(filePath);
            doc.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            return fileName;
        }

        /// <summary>
        /// Crear pdf para boleta de semestre
        /// </summary>
        public string SemesterHistory(string CN)
        {
            filePath += "semesterTemplate.docx";
            fileName += "Boleta" + CN + ".docx";
            DocX doc = DocX.Load(filePath);
            doc.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            return fileName;
        }

        /// <summary>
        /// Crear pdf para horario de alumno
        /// </summary>
        public string Schedule(string CN)
        {
            filePath += "scheduleTemplate.docx";
            fileName += "Horario" + CN + ".docx";
            DocX doc = DocX.Load(filePath);
            doc.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            return fileName;
        }
    }
}