using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMSWAResumeAPI.Models {
    public class ErrorModel : ResponseModel{
        public ErrorModel() {
            Message = "An error has occurred.";
        }
        public ErrorModel(string message) {
            Message = message;
        }
    }
}
