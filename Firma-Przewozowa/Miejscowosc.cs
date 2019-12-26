using System;

public class Miejscowosc
{
    string nazwa;
    int odleglosc_km;
    int czas_przejazdu_h;
    public Miejscowosc(string n, int o)
    {
        this.nazwa = n;
        this.odleglosc_km = o;
        this.czas_przejazdu_h = this.odleglosc_km / 60;
    }
}