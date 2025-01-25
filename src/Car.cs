using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatbaseProject.src
{
    /// <summary>
    /// Třída `Car` reprezentuje auto, které je možné pronajmout.
    /// Odpovídá tabulce `Car` v databázi.
    /// </summary>
    public class Car : IValidatableObject
    {
        /// <summary>
        /// Primární klíč tabulky `Car`.
        /// Unikátní identifikátor pro každé auto.
        /// </summary>
        [Key]
        public int CarId { get; set; }

        /// <summary>
        /// Registrační značka (SPZ) auta.
        /// Tento atribut je povinný a má maximální délku 20 znaků.
        /// </summary>
        [Required(ErrorMessage = "Registrační značka (SPZ) je povinná.")]
        [StringLength(20, ErrorMessage = "Registrační značka (SPZ) může mít maximálně 20 znaků.")]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Značka auta (např. Toyota, Ford).
        /// Tento atribut je povinný a má maximální délku 50 znaků.
        /// </summary>
        [Required(ErrorMessage = "Značka auta je povinná.")]
        [StringLength(50, ErrorMessage = "Značka auta může mít maximálně 50 znaků.")]
        public string Brand { get; set; }

        /// <summary>
        /// Model auta (např. Corolla, Mustang).
        /// Tento atribut je povinný a má maximální délku 50 znaků.
        /// </summary>
        [Required(ErrorMessage = "Model auta je povinný.")]
        [StringLength(50, ErrorMessage = "Model auta může mít maximálně 50 znaků.")]
        public string Model { get; set; }

        /// <summary>
        /// Typ auta (např. Sedan, SUV, Convertible).
        /// Povinný atribut, reprezentovaný enumerací `CarTypeEnum`.
        /// </summary>
        [Required(ErrorMessage = "Typ auta je povinný.")]
        public CarTypeEnum CarType { get; set; }

        /// <summary>
        /// Denní sazba za pronájem auta.
        /// Povinný atribut.
        /// </summary>
        [Required(ErrorMessage = "Denní sazba je povinná.")]
        [Range(0, double.MaxValue, ErrorMessage = "Denní sazba nemůže být záporná.")]
        public double DailyRate { get; set; }

        /// <summary>
        /// Navigační vlastnost pro související pronájmy (Rental).
        /// Tato vlastnost slouží k propojení s entitami v tabulce `Rental`,
        /// které odkazují na toto auto.
        /// </summary>
        public virtual ICollection<Rental> Rentals { get; set; }

        /// <summary>
        /// Konstruktor třídy `Car`.
        /// Inicializuje navigační kolekci `Rentals`, aby nedocházelo k null hodnotám.
        /// </summary>
        public Car()
        {
            Rentals = new HashSet<Rental>();
        }

        /// <summary>
        /// Ruční validace dat třídy `Car`.
        /// </summary>
        /// <param name="validationContext">Kontext validace.</param>
        /// <returns>Seznam chyb při validaci, pokud existují.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Kontrola, že LicensePlate není prázdný
            if (string.IsNullOrWhiteSpace(LicensePlate))
            {
                yield return new ValidationResult(
                    "Registrační značka (SPZ) nesmí být prázdná.",
                    new[] { nameof(LicensePlate) }
                );
            }

            // Kontrola, že Brand není prázdný
            if (string.IsNullOrWhiteSpace(Brand))
            {
                yield return new ValidationResult(
                    "Značka auta nesmí být prázdná.",
                    new[] { nameof(Brand) }
                );
            }

            // Kontrola, že Model není prázdný
            if (string.IsNullOrWhiteSpace(Model))
            {
                yield return new ValidationResult(
                    "Model auta nesmí být prázdný.",
                    new[] { nameof(Model) }
                );
            }
        }
    }
}
