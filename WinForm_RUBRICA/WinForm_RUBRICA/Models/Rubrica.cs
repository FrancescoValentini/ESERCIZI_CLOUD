﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WinFormRubrica_models.Models {
    public class Rubrica {
        private List<Persona> memoria;
        public string nome { get; }
        public Rubrica(string nome){
            this.nome = nome;
            memoria = new List<Persona>();
        }

        private bool PersonaExist(Persona persona) {
            if (memoria.Any(personaMem => personaMem.telefono == persona.telefono)) {
                return true;
            } else {
                return false;
            }
        }

        public void AddPersona(Persona p){
            if (PersonaExist(p)) { 
                throw new Exception("Persona già in memoria");
            }
            memoria.Add(p);
        }

        public Persona FindPersona(string telefono) {
            foreach (Persona persona in memoria) {
                if (persona.telefono == telefono) {
                   return persona;
                }
            }
            return null;
        }

        public void DeletePersona(string telefono) {
            Persona persona = FindPersona(telefono);
            if (persona != null) {
                memoria.Remove(persona);
            } else {
                throw new Exception("Persona non in memoria");
            }
        }

        public String getPrintableString() {
            String result = "";
            foreach(Persona persona in memoria) {
                result += persona.ToString();
            }
            return result;
        }
        public List<Persona> getPersone() {
            return memoria;
        }
    }
}
