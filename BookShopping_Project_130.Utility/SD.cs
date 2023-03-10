using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping_Project_130.Utility
{
    public static class SD
    {
        //Proc
        public const string Proc_CreateCoverType = "CreateCoverType";
        public const string Proc_UpdateCoverType = "UpdateCoverType";
        public const string Proc_DeleteCoverType = "DeleteCoverType";
        public const string Proc_GetAllCoverTypes = "GetAllCoverTypes";
        public const string Proc_GetCoverType = "GetCoverType";
        //Roles
        public const string Role_User_Admin = "Admin";
        public const string Role_User_Employee = "Employee";
        public const string Role_User_Company = "Company User";
        public const string Role_User_Individual = "Individual User";

        //Session
        public const string ssShoppingCartSession = "ShoppingCart Session";


        //order status
        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProgress = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";


        //Payment status

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayPayment = "PaymentStatusDelayPayment";
        public const string PaymentStatusRejected = "Rejected";

        public static double GetPriceBasedOnQuantity(double quantity, 
            double price, double price50,double price100)
        {
            if (quantity < 50)
                return price;
            else if (quantity < 100)
                return price50;
            else
                return price100;
        }
        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;
            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i]; //<
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>') //>
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
