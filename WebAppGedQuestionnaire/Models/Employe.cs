using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Models
{

    [Table(name: "TBL_EMPLOYE", Schema = "dbo")]
    public class Employe
    {
        [Key]
        [Column(Order = 0), StringLength(20)]
        public string Matricule { get; set; }

        [Column(Order = 1), StringLength(150)]
        public string NomPrenoms { get; set; }

        [Column(Order = 2), StringLength(150)]
        public string Contact { get; set; }

        [Column(Order = 3), StringLength(150)]
        public string Fonction { get; set; }

        [Column(Order = 4), StringLength(150)]
        public string Direction { get; set; }

        [Column(Order = 5), StringLength(150)]
        public string Service { get; set; }

        [Column(Order = 6), StringLength(150)]
        public string Categorie { get; set; }

        [Column(Order = 7), StringLength(150)]
        public string Mail { get; set; }

        [Column(Order = 8), StringLength(150)]
        public string Equipe { get; set; }

        [Column(Order = 9), StringLength(150)]
        public string Statut { get; set; }

        [Column(Order = 10), StringLength(100)]
        public string Site { get; set; }

        [Column(Order = 11), StringLength(6)]
        public string Date_Sortie { get; set; }

        [Column(Order = 12), StringLength(10)]
        public string Anciennete { get; set; }




        public List<Realiser> Realisers { get; set; }

        public List<Cocher> Cochers { get; set; }




    }
}
