using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatbaseProject.src
{
    /// <summary>
    /// Třída `Rental_ExtraService` reprezentuje vazební tabulku mezi `Rental` a `ExtraService`.
    /// Umožňuje definovat, kolik konkrétních extra služeb bylo přidáno k výpůjčce.
    /// </summary>
    public class Rental_ExtraService
    {
        /// <summary>
        /// Primární klíč - ID výpůjčky (FK do tabulky `Rental`).
        /// </summary>
        [Key, Column(Order = 1)]
        public int RentalId { get; set; }

        /// <summary>
        /// Primární klíč - ID extra služby (FK do tabulky `ExtraService`).
        /// </summary>
        [Key, Column(Order = 2)]
        public int ExtraServiceId { get; set; }

        /// <summary>
        /// Počet využitých jednotek dané služby během výpůjčky.
        /// Výchozí hodnota je 1.
        /// </summary>
        public int Quantity { get; set; } = 1;

        /// <summary>
        /// Navigační vlastnost na výpůjčku (`Rental`).
        /// Tato vlastnost slouží k propojení s entitou `Rental`.
        /// </summary>
        [ForeignKey(nameof(RentalId))]
        public virtual Rental Rental { get; set; }

        /// <summary>
        /// Navigační vlastnost na extra službu (`ExtraService`).
        /// Tato vlastnost slouží k propojení s entitou `ExtraService`.
        /// </summary>
        [ForeignKey(nameof(ExtraServiceId))]
        public virtual ExtraService ExtraService { get; set; }
    }
}
