using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JMSWAResumeAPI.Models {
    public class JsonExceptionModel: ResponseModel {

        public JsonExceptionModel(string v, JsonException e) {
            Message = $"{v}, {e.Message}";
            LineNumber = e.LineNumber;
            BytePositionInLine = e.BytePositionInLine;
            Path = e.Path;
            Source = e.Source;
            StackTrace = e.StackTrace;
        }
#nullable enable
        public long? LineNumber {
            get; set;
        }
        public long? BytePositionInLine {
            get; set;
        }
        public string? Path {
            get; set;
        }
        public string? Source {
            get; set;
        }
        public string? StackTrace {
            get; set;
        }
#nullable disable

    }
}
