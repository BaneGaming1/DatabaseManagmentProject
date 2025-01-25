using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatbaseProject.src
{
    /// <summary>
    /// Třída `Customer` reprezentuje zákazníka v systému.
    /// Odpovídá tabulce `Customer` v databázi.
    /// </summary>
    public class Customer : IValidatableObject
    {
        /// <summary>
        /// Primární klíč tabulky `Customer`.
        /// Unikátní identifikátor pro každého zákazníka.
        /// </summary>
        [Key]
        public int CustomerId { get; set; }

        /// <summary>
        /// Jméno zákazníka.
        /// Povinný atribut s maximální délkou 50 znaků.
        /// </summary>
        [Required(ErrorMessage = "Jméno je povinné.")]
        [StringLength(50, ErrorMessage = "Jméno může mít maximálně 50 znaků.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Příjmení zákazníka.
        /// Povinný atribut s maximální délkou 50 znaků.
        /// </summary>
        [Required(ErrorMessage = "Příjmení je povinné.")]
        [StringLength(50, ErrorMessage = "Příjmení může mít maximálně 50 znaků.")]
        public string LastName { get; set; }

        /// <summary>
        /// E-mail zákazníka.
        /// Povinný atribut s validací formátu.
        /// </summary>
        [Required(ErrorMessage = "E-mail je povinný.")]
        [StringLength(100, ErrorMessage = "E-mail může mít maximálně 100 znaků.")]
        [EmailAddress(ErrorMessage = "E-mail musí být ve správném formátu.")]
        public string Email { get; set; }

        /// <summary>
        /// Datum narození zákazníka.
        /// Povinný atribut.
        /// </summary>
        [Required(ErrorMessage = "Datum narození je povinné.")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Indikuje, zda je zákazník aktivní.
        /// Výchozí hodnota je `true`.
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Datum poslední výpůjčky zákazníka.
        /// Nepovinný atribut, může být `null`, pokud zákazník nemá žádné výpůjčky.
        /// </summary>
        public DateTime? LastRentalDate { get; set; }

        /// <summary>
        /// Navigační vlastnost na výpůjčky (`Rental`).
        /// Obsahuje seznam výpůjček, které zákazník provedl.
        /// </summary>
        public virtual ICollection<Rental> Rentals { get; set; }

        /// <summary>
        /// Konstruktor třídy `Customer`.
        /// Inicializuje kolekci `Rentals` jako prázdný `HashSet`,
        /// aby se předešlo výjimkám při práci s null hodnotami.
        /// </summary>
        public Customer()
        {
            Rentals = new HashSet<Rental>();
        }

        /// <summary>
        /// Ruční validace složitějších pravidel.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validace věku (musí být starší než 18 let)
            if (DateOfBirth > DateTime.Now.AddYears(-18))
            {
                yield return new ValidationResult(
                    "Zákazník musí být starší než 18 let.",
                    new[] { nameof(DateOfBirth) }
                );
            }
        }
    }
}
