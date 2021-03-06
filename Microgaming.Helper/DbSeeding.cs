﻿using Microgaming.Assignment;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microgaming.Helper
{
    public class DbSeeding: System.Data.Entity.DropCreateDatabaseIfModelChanges<CharityEntities>
    {
        protected override void Seed(CharityEntities context)
        {
            IList<Standard> defaultStandards = new List<Standard>();

            defaultStandards.Add(new Standard() { StandardName = "Standard 1", Description = "First Standard" });
            defaultStandards.Add(new Standard() { StandardName = "Standard 2", Description = "Second Standard" });
            defaultStandards.Add(new Standard() { StandardName = "Standard 3", Description = "Third Standard" });

            context.Standards.AddRange(defaultStandards);

            base.Seed(context);
        }
    }
}
