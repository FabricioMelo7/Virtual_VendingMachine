using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine.Custom_EventArgs
{
    public class KeyPadSelectionEventArgs
    {
        public List<KeyModel> Entries { get; set; }
    }
}
