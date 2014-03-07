using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;// = new List<IFurniture>();

        public Company(string initialName, string initialRegistrationNumber)
        {
            this.Name = initialName;
            this.RegistrationNumber = initialRegistrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company name cannot be null or empty");
                }
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Company name has to be with more than 5 letters");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                ulong number;
                if (!ulong.TryParse(value, out number))
                {
                    throw new ArgumentOutOfRangeException("Registration Number of a company needs to have only digits");
                }
                if (value.Length < 10)
                {
                    throw new ArgumentOutOfRangeException("Registration Number of a company needs to be more than 10 digits");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(furnitures); }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(fur => fur.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            var company = new StringBuilder();

            string countFurniture = this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no";
            string wordFurniture = this.Furnitures.Count != 1 ? "furnitures" : "furniture";

            company.AppendLine(string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber, countFurniture, wordFurniture));
            
            if (this.furnitures.Count != 0)
            {
                var sortFurniture = this.furnitures.OrderBy(fur => fur.Price).ThenBy(fur => fur.Model);

                foreach (var fur in sortFurniture)
                {
                    company.AppendLine(fur.ToString());
                }
            }
            return company.ToString().TrimEnd();
        }
    }
}
