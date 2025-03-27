using Project.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.API.Models.Pharmacist
{
    public class PharmacistPostModel
    {
        public string name { get; set; }
        public string password { get; set; }

        public long pharmacyId { get; set; }



    }
}
