using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine.Utils
{
    public static class Utilities
    {
        private static string GetEnteredID(List<KeyModel> Entries)
        {
            return string.Join(" ", Entries.Select(key => key.Entry));
        }

        /// <summary>
        /// Determines the product entered by the user in the key-Pad
        /// </summary>
        /// <param name="ProductStock">Collection of all the products</param>
        /// <param name="Entries">Collection of entered keys </param>
        /// <returns>Returns Product object </returns>
        public static SlotModel ProductEntered(List<SlotModel> SlotsList, List<KeyModel> Entries)
        {
            return SlotsList.FirstOrDefault(slot => slot.SlotID == GetEnteredID(Entries));
        }

        /// <summary>
        /// Determine if the entered ID matches a product ID
        /// </summary>
        /// <param name="Entries">Collection of entered keys</param>
        /// <param name="ProductStock">Collection of all the products</param>
        /// <returns>Returns boolean value</returns>
        public static bool IsRequestedIdValid(List<KeyModel> Entries, List<SlotModel> SlotsList)
        {
            return SlotsList.Any(slot => slot.SlotID == GetEnteredID(Entries));
        }
    }
}
