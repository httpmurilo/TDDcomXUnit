﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        LeilaoEmAndamento,
        LeilaoFinalizado,
    }
   public class Leilao
    {

        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
        }

        public void RecebeLance(Interessado cliente, double valor)
        {
            _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {

        }

        public void TerminaPregao()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null,0))
                .OrderBy(l => l.Valor)
                .LastOrDefault();
        }//definindo um valor default apartir de um objeto que sera usado quando o IE tiver vazio
    }
}

    