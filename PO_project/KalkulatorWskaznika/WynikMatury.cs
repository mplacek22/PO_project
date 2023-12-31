﻿using PO_project.Enums;
using System.ComponentModel.DataAnnotations;

namespace PO_project.KalkulatorWskaznika
{
    public class WynikMatury
    {
        [Range(0, 100)]
        public int Podstawa { get; set; } = 0;

        [Range(0, 100)]
        public int Rozszerzenie { get; set; } = 0;
    }
}
