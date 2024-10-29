using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace veeb_Milovzorova.Models
{
    public class Kasutaja
    {
        public int Id { get; set; }
        public string KasutajaNimi { get; set; }
        public string Parool { get; set; }
        public string Eesnimi { get; set; }
        public string Perenimi { get; set; }

        public Kasutaja(int id, string kasutajaNimi, string parool, string eesnimi, string perenimi)
        {
            Id = id;
            KasutajaNimi = kasutajaNimi;
            Parool = parool;
            Eesnimi = eesnimi;
            Perenimi = perenimi;
        }
    }
}