using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Domain.Models
{
    public class ActionServiceResult
    {
        public ActionServiceResult(bool success, int appCode, string message, object data)
        {
            Success = success;
            AppCode = appCode;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public int AppCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ActionServiceResult<T>
    {
        public ActionServiceResult(bool success, int appCode, string message, T data)
        {
            Success = success;
            AppCode = appCode;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public int AppCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
