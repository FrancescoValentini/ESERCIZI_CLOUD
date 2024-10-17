using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Models.Models {
    public class Persona {
        public string nome { get; set; }
        public string cognome { get; set; }
        public string telefono { get; set; }

        public Persona(string nome, string cognome, string telefono) {
            this.nome = nome;
            this.cognome = cognome;
            this.telefono = telefono;
        }

        public override string ToString() {
            return "Nome: " + this.nome + "\nCognome: " + this.cognome + "\nTelefono: " + this.telefono;
        }
    }

}
