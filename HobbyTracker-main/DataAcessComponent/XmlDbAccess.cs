using HobbyTracker.BusinessEntityComponent;
using HobbyTracker.SecurityComponent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace HobbyTracker.DataAccessComponent
{
    public class XmlDbAccess
    {
        public static void DeleteHobby(string path, int id)
        {
            if (!File.Exists(path)) return;

            XDocument doc = XDocument.Load(path);

            XElement categoriesElement = doc.Root.Element("Hobbies");

            var hobbyToDelete = categoriesElement.Elements("Hobby")
                .FirstOrDefault(c => (int)c.Element("Id") == id);

            if (hobbyToDelete != null)
            {
                hobbyToDelete.Remove();
                doc.Save(path);
            }
        }
        public static void AddOrUpdateItem(string path, HobbyItemModel item)
        {
            XElement hobbiesElement = null;
            XDocument doc;

            // If file doesn't exist, create a new one with root and hobbies node
            if (!File.Exists(path))
            {
                doc = new XDocument(
                    new XElement("HobbyTracker",
                        new XElement("Hobbies")
                    )
                );
            }
            else
            {
                doc = XDocument.Load(path);
                hobbiesElement = doc.Root.Element("Hobbies");
                if (hobbiesElement == null)
                {
                    doc = new XDocument(
                                        new XElement("HobbyTracker",
                                            new XElement("Hobbies")
                                        )
                                    );

                }

            }
            hobbiesElement = doc.Root.Element("Hobbies");

            // Get the highest existing ID
            int nextId = 1;
            if (hobbiesElement.Elements("Hobby").Any())
            {
                nextId = hobbiesElement.Elements("Hobby")
                                     .Max(x => (int)x.Element("Id")) + 1;
            }


            // Check if category with same ID exists
            XElement existingHobby = hobbiesElement?.Elements("Hobby")
                .FirstOrDefault(c => (int)c.Element("Id") == item.Id);

            if (existingHobby != null)
            {
                // Update existing
                existingHobby.Element("Name").Value = item.Name;
                existingHobby.Element("Category").Value = item.Category;
                existingHobby.Element("Price").Value = item.Price.ToString();
                existingHobby.Element("PersonalValue").Value = item.PersonalValue.ToString();
                existingHobby.Element("YearsToEstimate").Value = item.YearsToEstimate.ToString();
                existingHobby.Element("DepreciationRate").Value = item.DepreciationRate.ToString();
                existingHobby.Element("DepreciatedPrice").Value = item.DepreciatedPrice.ToString();
                //existingHobby.Element("User").Value = item.User;
                existingHobby.Element("ConvertedPrice").Value = item.ConvertedPrice.ToString();




            }
            else
            {
                // Add new
                hobbiesElement.Add(new XElement("Hobby",
                    new XElement("Id", nextId),
                    new XElement("Name", item.Name),
                    new XElement("Category", item.Category),
                    new XElement("Price", item.Price),
                    new XElement("PersonalValue", item.PersonalValue),
                    new XElement("YearsToEstimate", item.YearsToEstimate),
                    new XElement("DepreciationRate", item.DepreciationRate),
                    new XElement("DepreciatedPrice", item.DepreciatedPrice),
                    new XElement("User", item.User),
                    new XElement("ConvertedPrice", item.ConvertedPrice)




                ));
            }

            // Save changes
            doc.Save(path);
        }
        public static void AddOrUpdateUser(string path, UserModel item)
        {
            XElement userElement = null;
            XDocument doc;

            // If file doesn't exist, create a new one with root and users node
            if (!File.Exists(path))
            {
                doc = new XDocument(
                    new XElement("HobbyTracker",
                        new XElement("Users")
                    )
                );
            }
            else
            {
                doc = XDocument.Load(path);
                userElement = doc.Root.Element("Users");
                if (userElement == null)
                {
                    doc = new XDocument(
                                        new XElement("HobbyTracker",
                                            new XElement("Users")
                                        )
                                    );

                }

            }
            userElement = doc.Root.Element("Users");

            // Get the highest existing ID
            int nextId = 1;
            if (userElement.Elements("User").Any())
            {
                nextId = userElement.Elements("User")
                                     .Max(x => (int)x.Element("Id")) + 1;
            }


            // Check if category with same ID exists
            XElement existingUser = userElement?.Elements("User")
                .FirstOrDefault(c => (int)c.Element("Id") == item.Id);

            if (existingUser != null)
            {
                // Update existing
                existingUser.Element("UserName").Value = item.UserName;
                existingUser.Element("Password").Value = item.Password;


            }
            else
            {
                // Add new
                userElement.Add(new XElement("User",
                    new XElement("Id", nextId),
                    new XElement("UserName", item.UserName),
                    new XElement("Password", item.Password)
                ));
            }

            // Save changes
            doc.Save(path);
        }
        public static List<HobbyItemModel> LoadHoppies(string path)
        {
            if (!File.Exists(path))
                return new List<HobbyItemModel>(); // return empty if not found

            XDocument doc = XDocument.Load(path);

            return doc.Root.Element("Hobbies").Elements("Hobby")
                .Select(c => new HobbyItemModel
                {
                    Id = Convert.ToInt32(c.Element("Id")?.Value),
                    Name = c.Element("Name")?.Value,
                    DepreciationRate = decimal.Parse(c.Element("DepreciationRate")?.Value),
                    Category = c.Element("Category")?.Value,
                    PersonalValue = Convert.ToInt32(c.Element("PersonalValue")?.Value),
                    YearsToEstimate = Convert.ToInt32(c.Element("YearsToEstimate")?.Value),
                    Price = Convert.ToDecimal(c.Element("Price")?.Value),
                    DepreciatedPrice = Convert.ToDecimal(c.Element("DepreciatedPrice")?.Value),
                    User = c.Element("User")?.Value,
                    ConvertedPrice = Convert.ToDecimal(c.Element("ConvertedPrice")?.Value)




                }).ToList();
        }
        public static List<HobbyItemModel> LoadHoppiesByUser(string path, string User)
        {
            if (!File.Exists(path))
                return new List<HobbyItemModel>(); // return empty if not found

            XDocument doc = XDocument.Load(path);

            return doc.Root.Element("Hobbies").Elements("Hobby")
                    .Where(c => string.Equals(c.Element("User")?.Value, User, StringComparison.OrdinalIgnoreCase)) // Filter
                .Select(c => new HobbyItemModel
                {
                    Id = Convert.ToInt32(c.Element("Id")?.Value),
                    Name = c.Element("Name")?.Value,
                    DepreciationRate = decimal.Parse(c.Element("DepreciationRate")?.Value),
                    Category = c.Element("Category")?.Value,
                    PersonalValue = Convert.ToInt32(c.Element("PersonalValue")?.Value),
                    YearsToEstimate = Convert.ToInt32(c.Element("YearsToEstimate")?.Value),
                    Price = Convert.ToDecimal(c.Element("Price")?.Value),
                    DepreciatedPrice = Convert.ToDecimal(c.Element("DepreciatedPrice")?.Value),
                    User = c.Element("User")?.Value,
                    ConvertedPrice = Convert.ToDecimal(c.Element("ConvertedPrice")?.Value)

                }).ToList();
        }

        public static (string UserName, int ItemCount, List<string> ItemNames) GetMostActiveUserInfo(string path)
        {
            if (!File.Exists(path))
                return ("No Data", 0, new List<string>());

            XDocument doc = XDocument.Load(path);

            var hobbies = doc.Root?
                .Element("Hobbies")?
                .Elements("Hobby")
                .Where(h => !string.IsNullOrWhiteSpace(h.Element("User")?.Value));

            if (hobbies == null || !hobbies.Any())
                return ("No Hobbies Found", 0, new List<string>());

            var mostActiveGroup = hobbies
                .GroupBy(h => h.Element("User")?.Value.Trim())
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            if (mostActiveGroup == null)
                return ("No User Found", 0, new List<string>());

            string userName = mostActiveGroup.Key;
            int itemCount = mostActiveGroup.Count();
            List<string> itemNames = mostActiveGroup
                .Select(h => h.Element("Name")?.Value ?? "Unnamed Item")
                .ToList();

            return (userName, itemCount, itemNames);
        }
        public static List<HobbyItemModel> LoadItemsAboveValue(string path, decimal minPrice)
        {
            if (!File.Exists(path)) return new List<HobbyItemModel>();

            XDocument doc = XDocument.Load(path);
            return doc.Root.Element("Hobbies")?.Elements("Hobby")
                .Where(x => decimal.TryParse(x.Element("Price")?.Value, out decimal p) && p >= minPrice)
                .Select(x => new HobbyItemModel
                {
                    Name = x.Element("Name")?.Value,
                    Category = x.Element("Category")?.Value,
                    Price = decimal.TryParse(x.Element("Price")?.Value, out decimal price) ? price : 0,
                    User = x.Element("User")?.Value,
                    ConvertedPrice = Convert.ToDecimal(x.Element("ConvertedPrice")?.Value)
                }).ToList();
        }

        public static List<UserModel> LoadUsers(string path)
        {
            if (!File.Exists(path))
                return new List<UserModel>(); // return empty if not found

            XDocument doc = XDocument.Load(path);

            var users = doc.Root?.Elements("Users").Elements("User") ?? Enumerable.Empty<XElement>();
            if (users.Count() > 0)
            {
                return doc.Root.Element("Users").Elements("User")
                    .Select(c => new UserModel
                    {
                        Id = Convert.ToInt32(c.Element("Id")?.Value),
                        UserName = c.Element("UserName")?.Value,
                        Password = c.Element("Password")?.Value,




                    }).ToList();
            }
            else
                return new List<UserModel>();
        }
        public static StaffUserModel ValidateStaffUser(string xmlPath, string username, string password)
        {
            if (!File.Exists(xmlPath))
                return null;

            try
            {
                XDocument doc = XDocument.Load(xmlPath);

                var user = doc.Descendants("User")
                              .Where(x => (string)x.Element("Username") == username &&
                                          (string)x.Element("Password") == password)
                              .Select(x => new StaffUserModel
                              {
                                  Username = (string)x.Element("Username"),
                                  Access = (string)x.Element("Access")
                              })
                              .FirstOrDefault();

                return user;
            }
            catch
            {
                return null; // or handle logging
            }
        }

        public static bool IsValidUser(string xmlPath, string username, string password)
        {
            if (!File.Exists(xmlPath))
                return false;

            try
            {
                XDocument doc = XDocument.Load(xmlPath);

                return doc.Descendants("Users").Descendants("User")
              .Any(x =>
                  (string)x.Element("UserName") == username &&
                  (string)x.Element("Password") == CryptoHelper.Encrypt(password)
              );


            }
            catch
            {
                return false; // or handle logging
            }
        }

    }
}
