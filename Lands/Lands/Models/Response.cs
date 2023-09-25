
namespace Lands.Models
{
    public class Response
    {
        public bool IsSuccess
        {
            //trae la lista de paises,
            //TRUE = trae la lista de paises
            //FALSE = falla al traer lista
            get;
            set;
        }

        public string Message
        {
            //Decripción del error 
            get;
            set;
        }

        public object Result
        {
            //Devuelve resultado lista de paises
            get;
            set;
        }


    }
}
