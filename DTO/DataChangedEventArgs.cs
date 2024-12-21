using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DataChangedEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string OperationName { get; set; }
        public string TableName { get; set; }
        public int AffectedRows { get; set; }
    }
}
