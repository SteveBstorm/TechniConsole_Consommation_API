using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Consommation_API
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NbPlayerMin { get; set; }
        public int NbPlayerMax { get; set; }
        public int? Age { get; set; }
        public bool IsCoop { get; set; }
    }

    public class Member
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pseudo { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class Profil : Member
    {
        public List<Game> favoriteList { get; set; }
    }
}
