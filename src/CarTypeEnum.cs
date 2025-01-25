using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatbaseProject.src
{
    /// <summary>
    /// Výčtový typ `CarTypeEnum` definuje různé kategorie vozidel.
    /// Hodnoty odpovídají číselným identifikátorům uloženým v databázi.
    /// </summary>
    public enum CarTypeEnum
    {
        Sedan = 0,
        Suv = 1,
        Convertible = 2,
        Hatchback = 3,
    }
}
