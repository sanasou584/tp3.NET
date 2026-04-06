using System.ComponentModel.DataAnnotations;

namespace Tp3EFcoreRelations.Models
{
    public class Movie
    {
        [Key]
        public Guid Id {  get; set; } = Guid.NewGuid(); //generation automatique de cle primaire
        [Required(ErrorMessage ="Le nomdu film est requis")] //controle de saisie pour indiquer
        [StringLength(100,ErrorMessage ="le nom ne doit pas depasser 100 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage ="ladate d'ajout est requise")]
        public DateTime MavieAdded { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Le genre est requis")]
        public Guid GenreId { get; set; } //Cle etrangere
        public Genre ? Genre { get; set; } //Relation
        public string? PhotoPath { get; set; } //Stocke le chemin de l'image uploadee

    }
}
