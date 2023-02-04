using BookReader.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Domain.Response
{
    public class BaseResponse<T>:IBaseResponse<T>
    {
        public string Description { get; set;}  
        public StatusCode statusCode { get; set;}
        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get;}
        StatusCode statusCode { get;}
        string Description { get;}

    }
}
