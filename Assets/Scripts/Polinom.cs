using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class Polinom : MonoBehaviour
{
    public List<double> Coeficienti { get; set; }
    public int Grad { get; set; }
    private GameObject points;

    public Polinom(List<double> coeficienti)
    {
        Coeficienti = new List<double>();
        Coeficienti = coeficienti;
        Grad = Coeficienti.Count - 1;
    }


    public Polinom()
    {
        Coeficienti = new List<double>();
        Grad = 0;
    }

    public override string ToString()
    {
        var result = "";
        for (int i = Grad; i >= 0; i--)
        {
            var sign = Coeficienti[i] >= 0 ? "+" : "";
            if (Coeficienti[i] != 0 && i != 0)
            {
                result += (sign + Coeficienti[i] + "X^" + i);

            }
            else if (i == 0)
            {
                result += (sign + Coeficienti[i]);

            }

        }
        return result;
    }

    public double CalculeazaValoarea(double punct)
    {
        var val = 0d;
        for (int i = Grad; i >= 0; i--)
        {
            val += Coeficienti[i] * System.Math.Pow(punct, i);
        }
        return val;
    }

    public void Print()
    {
        Debug.Log((ToString()));
    }

    //adunare
    public static Polinom operator +(Polinom a, Polinom b)
    {
        var result = new Polinom();
        var ListMaxim = new List<double>();
        var maxGrad = 0;
        var minGrad = 0;

        if (a.Grad > b.Grad)
        {
            maxGrad = a.Grad;
            ListMaxim = a.Coeficienti;
            minGrad = b.Grad;
        }
        else
        {
            maxGrad = b.Grad;
            ListMaxim = b.Coeficienti;
            minGrad = a.Grad;
        }

        for (int i = 0; i <= maxGrad; i++)
        {
            if (i <= minGrad)
            {
                result.Coeficienti.Add(a.Coeficienti[i] + b.Coeficienti[i]); //make the sum betwen a and b, else copy from polinom whith bigger grad 
            }
            else
            {
                result.Coeficienti.Add(ListMaxim[i]);
            }

        }

        result.Grad = result.Coeficienti.Count - 1;

        return result;
    }

    //scadere
    public static Polinom operator -(Polinom a, Polinom b)
    {
        var result = new Polinom();

        var ListMaxim = new List<double>();
        var maxGrad = 0;
        var minGrad = 0;

        if (a.Grad > b.Grad)
        {
            maxGrad = a.Grad;
            ListMaxim = a.Coeficienti;
            minGrad = b.Grad;
        }
        else
        {
            maxGrad = b.Grad;
            ListMaxim = b.Coeficienti;
            minGrad = a.Grad;
        }

        for (int i = 0; i <= maxGrad; i++)
        {
            if (i <= minGrad)
            {
                result.Coeficienti.Add(a.Coeficienti[i] - b.Coeficienti[i]);
            }
            else
            {
                result.Coeficienti.Add(ListMaxim[i]);
            }

        }

        result.Grad = result.Coeficienti.Count - 1;

        return result;
    }
    //inmultire
    public static Polinom operator *(Polinom a, Polinom b)
    {
        var maxGrad = a.Grad + b.Grad + 2;
        var coeficientiProdus = new double[maxGrad];
        var result = new Polinom();

        for (int i = 0; i <= a.Grad; i++)
        {
            for (int j = 0; j <= b.Grad; j++)
            {
                coeficientiProdus[i + j] += a.Coeficienti[i] * b.Coeficienti[j];
            }
        }
        result.Coeficienti = coeficientiProdus.ToList();
        result.Grad = coeficientiProdus.ToList().Count - 1;
        return result;
    }

    //derivare
    //derivare (x^n)' = n*x^n-1
    public Polinom Derivare()
    {
        var coeficientiRezultat = new double[Grad +1];
        if (Grad >= 1)
        {

            for (int i = 1; i <= Grad; i++)
            {

                coeficientiRezultat[i - 1] = (i) * Coeficienti[i];

            }
        }
        else
        {
            coeficientiRezultat[0] = 0;
        }
        return new Polinom(coeficientiRezultat.ToList());
    }

    //         /            x^(n+1)
    //         | x^n dx = -----------
    //         /             n + 1
    public Polinom Integrare()
    {
        var coeficientiRezultat = new double[Grad + 2];

        for (int i = 0; i <= Grad; i++)
        {

            if (i > 0)
            {
                coeficientiRezultat[i + 1] = Coeficienti[i] / (i + 1);

            }
            else
            {
                coeficientiRezultat[i + 1] = Coeficienti[i];

            }


        }


        return new Polinom(coeficientiRezultat.ToList());
    }

    //grafic
    public void PlotChart(GameObject point, Transform chartContainer)
    {
        List<Vector2> PunctePeGrafic = new List<Vector2>();
        for (float i = -10; i <= 10; i += 0.1f)
        {
            var temp = new Vector2();
            temp.x = i;
            temp.y = temp.y = Mathf.Clamp((float)CalculeazaValoarea(i), -10, 10);
            PunctePeGrafic.Add(temp);

        }
        //PunctePeGrafic.Clear();
        foreach (var item in PunctePeGrafic)
        {
            Instantiate(point, new Vector2(item.x, item.y), Quaternion.identity, chartContainer);
        }

    }
}
