using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatbaseProject.src
{
    /// <summary>
    /// Třída `ExtraService` reprezentuje doplňkovou službu, kterou lze přidat k výpůjčce.
    /// Odpovídá tabulce `ExtraService` v databázi.
    /// </summary>
    public class ExtraService
    {
        /// <summary>
        /// Primární klíč tabulky `ExtraService`.
        /// Unikátní identifikátor každé služby.
        /// </summary>
        [Key]
        public int ExtraServiceId { get; set; }

        /// <summary>
        /// Název doplňkové služby (např. GPS, dětská sedačka).
        /// Povinný atribut s maximální délkou 50 znaků.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; }

        /// <summary>
        /// Cena za den využití služby.
        /// Povinný atribut.
        /// </summary>
        [Required]
        public float PricePerDay { get; set; }

        /// <summary>
        /// Navigační vlastnost na vazební tabulku `Rental_ExtraService`.
        /// Obsahuje seznam výpůjček, ke kterým byla tato služba přidána.
        /// </summary>
        public virtual ICollection<Rental_ExtraService> RentalExtraServices { get; set; }

        /// <summary>
        /// Konstruktor třídy `ExtraService`.
        /// Inicializuje kolekci `RentalExtraServices` jako prázdný `HashSet`,
        /// aby se předešlo výjimkám při práci s null hodnotami.
        /// </summary>
        public ExtraService()
        {
            RentalExtraServices = new HashSet<Rental_ExtraService>();
        }
    }
}
