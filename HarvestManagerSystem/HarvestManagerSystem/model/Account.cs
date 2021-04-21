using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class Account
    {
        string name;
        string passwword;

        public string Name { get => name; set => name = value; }
        public string Passwword { get => passwword; set => passwword = value; }
    }
}
