using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatbaseProject.src
{
    /// <summary>
    /// Třída `Rental` reprezentuje záznam o výpůjčce auta.
    /// Odpovídá tabulce `Rental` v databázi.
    /// </summary>
    public class Rental : IValidatableObject
    {
        /// <summary>
        /// Primární klíč tabulky `Rental`.
        /// Unikátní identifikátor pro každou výpůjčku.
        /// </summary>
        [Key]
        public int RentalId { get; set; }

        /// <summary>
        /// ID zákazníka, který provedl výpůjčku.
        /// Cizí klíč propojený s tabulkou `Customer`.
        /// </summary>
        [Required]
        public int CustomerId { get; set; }

        /// <summary>
        /// Navigační vlastnost na entitu `Customer`.
        /// Umožňuje přístup k detailům zákazníka, který výpůjčku provedl.
        /// </summary>
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// ID auta, které bylo vypůjčeno.
        /// Cizí klíč propojený s tabulkou `Car`.
        /// </summary>
        [Required]
        public int CarId { get; set; }

        /// <summary>
        /// Navigační vlastnost na entitu `Car`.
        /// Umožňuje přístup k detailům auta, které bylo vypůjčeno.
        /// </summary>
        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; }

        /// <summary>
        /// Datum a čas zahájení výpůjčky.
        /// Povinný atribut.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Datum a čas ukončení výpůjčky.
        /// Povinný atribut.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Celková cena výpůjčky.
        /// Povinný atribut.
        /// </summary>
        [Required]
        public double TotalPrice { get; set; }

        /// <summary>
        /// Navigační vlastnost na vazební tabulku `Rental_ExtraService`.
        /// Obsahuje seznam extra služeb připojených k této výpůjčce.
        /// </summary>
        public virtual ICollection<Rental_ExtraService> RentalExtraServices { get; set; }

        /// <summary>
        /// Konstruktor třídy `Rental`.
        /// Inicializuje kolekci `RentalExtraServices` jako prázdný `HashSet`,
        /// aby se předešlo výjimkám při práci s null hodnotami.
        /// </summary>
        public Rental()
        {
            RentalExtraServices = new HashSet<Rental_ExtraService>();
        }

        /// <summary>
        /// Ruční validace dat výpůjčky.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Kontrola, že EndDate není menší než StartDate
            if (EndDate < StartDate)
            {
                yield return new ValidationResult(
                    "Datum návratu nemůže být menší než datum vypůjčení.",
                    new[] { nameof(EndDate) }
                );
            }

            // Kontrola, že TotalPrice není záporné číslo
            if (TotalPrice < 0)
            {
                yield return new ValidationResult(
                    "Cena nemůže být záporná.",
                    new[] { nameof(TotalPrice) }
                );
            }
        }
    }
}
