using HobbyTracker.BusinessEntityComponent;
using HobbyTracker.DataAccessComponent;
using HobbyTracker.ServiceComponent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HobbyTracker.BusinessComponent
{
    public class BusinessAccess
    {
        public static void DeleteHobby(string path, int id)
        {
            XmlDbAccess.DeleteHobby(path, id);
        }
        public static void AddOrUpdateItem(string path, HobbyItemModel item)
        {
            XmlDbAccess.AddOrUpdateItem(path, item);
        }
        public static void AddOrUpdateUser(string path, UserModel item)
        {
            XmlDbAccess.AddOrUpdateUser(path, item);
        }
        public static List<HobbyItemModel> LoadHoppies(string path)
        {
            return XmlDbAccess.LoadHoppies(path);
        }
        public static List<HobbyItemModel> LoadHoppiesByUser(string path, string User)
        {
            return XmlDbAccess.LoadHoppiesByUser(path, User);
        }
        public static (string UserName, int ItemCount, List<string> ItemNames) GetMostActiveUserInfo(string path)
        {
            return XmlDbAccess.GetMostActiveUserInfo(path);
        }
        public static List<HobbyItemModel> LoadItemsAboveValue(string path, decimal minPrice)
        {
            return XmlDbAccess.LoadItemsAboveValue(path, minPrice);

        }

        public static List<UserModel> LoadUsers(string path)
        {
            return XmlDbAccess.LoadUsers(path);
        }

        public static StaffUserModel ValidateStaffUser(string xmlPath, string username, string password)
        {
            return XmlDbAccess.ValidateStaffUser(xmlPath, username, password);
        }

        public static bool IsValidUser(string xmlPath, string username, string password)
        {
            return XmlDbAccess.IsValidUser(xmlPath, username, password);
        }

        public static async Task<decimal> CallPriceServiceAsync(decimal originalPrice, int years, decimal annualDepreciationRate)
        {
            return await ServiceAccess.CallPriceServiceAsync(originalPrice, years, annualDepreciationRate);
        }
        public static decimal ConvertCurrency(decimal amount, string from, string to)

        {
            return ServiceAccess.ConvertCurrency(amount, from, to);
        }
    }
}
