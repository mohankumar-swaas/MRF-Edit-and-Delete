using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRF_Edit_and_Delete.Models.User
{
    public class UserModel
    {
        public int id { get; set; }
        public string Userid { get; set; }
        public string PositionName { get; set; }
        public int Vacancy_For { get; set; }
        public string VacancyField { get; set; }
        public string TerritoryHQ { get; set; }
    }
}