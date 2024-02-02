using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMSWAResumeAPI.Models {
    public class SuccessModel : ResponseModel {
        public SuccessModel() {
            Message = "Success!";
        }
        public SuccessModel(string message) {
            Message = message;
        }
    }
}
