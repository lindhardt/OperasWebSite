﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OperasWebSites.Models
{
    public class OperasInitializer : DropCreateDatabaseAlways<OperasDB>
    {
        protected override void Seed(OperasDB context)
        {
            var operas = new List<Opera>
            {
                new Opera
                {
                    Title = "Cosi Fan Tutte",
                    Year = 1790,
                    Composer = "Mozart"
                },
                new Opera {
                    Title = "Rigoletto",
                    Year = 1851,
                    Composer = "Giuseppe Verdi",
                },
                new Opera {
                    Title = "Nixon in China",
                    Year = 1987,
                    Composer = "John Adams"
                },
                new Opera {
                    Title = "Wozzeck",
                    Year = 1922,
                    Composer = "Alban Berg"
                }
            };

            operas.ForEach(s =>
           context.Operas.Add(s));

            context.SaveChanges();
        }
    }
}