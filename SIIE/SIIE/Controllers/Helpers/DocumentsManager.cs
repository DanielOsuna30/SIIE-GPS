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
        DocX doc;
        HttpResponseBase Response;
        string fileName ="";
        string filePath = (AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" );

        public DocumentsManager(HttpResponseBase Response)
        { 
            this.Response = Response;
        }

        private void setResponseInfo()
        {
            doc.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.WriteFile(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            Response.End();
            FileInfo fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            fileInfo.Delete();
        }

        /// <summary>
        /// Crear pdf para la ficha de inscripcion
        /// </summary>
        public void InscriptionFoil(int CN)
        {
            filePath += "inscriptionTemplate.docx";
            fileName += "FolioReinscripcion"+CN+".docx";
            doc = DocX.Load(filePath);
            setResponseInfo();
        }

        /// <summary>
        /// Crear pdf para ficha de reinscripcion
        /// </summary>
        public void ReinscriptionFoil(int CN)
        {
            filePath += "reinscriptionTemplate.docx";
            fileName += "FolioReinscripcion"+CN+".docx";
            doc = DocX.Load(filePath);
            setResponseInfo();
        }

        /// <summary>
        /// Crear pdf para historial academico
        /// </summary>
        public string CarrerHistory(int CN)
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
        public string SemesterHistory(int CN)
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
        public string Schedule(int CN)
        {
            filePath += "scheduleTemplate.docx";
            fileName += "Horario" + CN + ".docx";
            DocX doc = DocX.Load(filePath);
            doc.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            return fileName;
        }
    }
}