﻿using System.Collections.Generic;

namespace Cw13.Models
{
    public class Klient
    {
        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public virtual ICollection<Zamowienie> Zamowienia { get; set; }
    }
}