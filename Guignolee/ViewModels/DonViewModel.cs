using Guignolee.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Guignolee.ViewModels
{
    public class DonViewModel : ValidableViewModel
    {
        private readonly Don _don;

        public DonViewModel(Don don)
        {
            _don = don;
        }

        public int Id => _don.Id;

        [Required(ErrorMessage = "Obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Entre 2 et 50 caractères.")]
        [RegularExpression(@"^\d[A-Z][a-z] +$", ErrorMessage = "Que des chiffres, lettres et espaces")]
        public string Donateur
        {
            get { return _don.Donateur; }
            set
            {
                if (_don.Donateur != value && Validate(value))
                {
                    _don.Donateur = value;
                }
                else
                {
                    Validate(value);
                }
            }
        }

        [Required(ErrorMessage = "Obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Entre 2 et 50 caractères.")]
        [RegularExpression(@"^\d[A-Z][a-z] +$", ErrorMessage = "Que des chiffres, lettres et espaces")]
        public string Contenu
        {
            get { return _don.Contenu; }
            set
            {
                if (_don.Contenu != value && Validate(value))
                {
                    _don.Contenu = value;
                }
                else
                {
                    Validate(value);
                }
            }
        }

        [Required(ErrorMessage = "Obligatoire.")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "1 à 3 chiffres.")]
        public int Quantite
        {
            get { return _don.Quantite; }
            set
            {
                if (Quantite != value && Validate(value))
                {
                    _don.Quantite = value;

                }
                else
                {
                    Validate(value);
                }
            }
        }

        public bool EstPerissable
        {
            get { return _don.EstPerissable; }
            set
            {
                if (_don.EstPerissable != value)
                {
                    _don.EstPerissable = value;
                }
                else
                {
                    Validate(value);
                }
            }
        }

        public bool EstRemis
        {
            get { return _don.EstRemis; }
            set
            {
                if (_don.EstRemis != value)
                {
                    _don.EstRemis = value;
                }
            }
        }

        public DateTime DateReception => _don.DateReception;

        public string Details
        {
            get
            {
                return $"{_don.Quantite} article(s) - {_don.Donateur} - reçu le {_don.DateReception:dd-MM-yyyy}";
            }
        }
    }
}
