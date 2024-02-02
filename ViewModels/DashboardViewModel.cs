using GenTech.Models;

namespace GenTech.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalCompanies { get; set; }
        public int TotalUsers { get; set; }
        public ICollection<Company> CompaniesList { get; set; }
    }
}
