using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DataChangedEventArgs : EventArgs
    {
        public string FunctionName { get; }
        public DataTable Data { get; }

        public DataChangedEventArgs(string functionName, DataTable data)
        {
            FunctionName = functionName;
            Data = data;
        }
    }
}
