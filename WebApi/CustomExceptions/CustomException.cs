using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace SeatManagement1.CustomExceptions
{
    [Serializable]
    public class CustomException:Exception
    {public CustomException() { }
     public CustomException(string message) { }
    public CustomException(string message,Exception inner):base(  message, inner){ }
    


    }
}
