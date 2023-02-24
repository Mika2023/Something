using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bModel
{
    public abstract class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
    }
}
