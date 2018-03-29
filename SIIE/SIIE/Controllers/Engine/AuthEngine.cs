using System.Linq;
using SIIE.Models;

namespace SIIE.Controllers.Engine
{
    public class AuthEngine:MainEngine 
    {
        /// <summary>
        /// Verificar credenciales de login en la db
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void VerifyCredentials(ref Loginn Data)
        {
            string cn = Data.noControl, pass = Data.Constraseña;
            Data = db.Loginn.FirstOrDefault(x => x.noControl == cn && x.Constraseña == pass);
        }
    }
}