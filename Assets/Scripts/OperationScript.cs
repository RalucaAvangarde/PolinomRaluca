using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

    
public class OperationScript: MonoBehaviour
{
    private void Start()
    {
        int[] pol1 = { 2, 4, 1};
        int[] pol2 = { 1, 2 };
        int m = pol1.Length;
        int n = pol2.Length;
        int size = Maximum(m,n);
        int[] suma = Addition(pol1, pol2, m, n);
        Afisare(suma,size);
    }

    static int Maximum(int m, int n)
    {
        if (m > n)
        {
            return m;
        }
        else
            return n;
    }
    public int[] Addition(int[] pol1, int[] pol2, int m, int n)
    {
        int size = Maximum(m, n);
        int[] sum = new int[size];
        
        for (int i = 0; i < m; i++)
        {
            sum[i] = pol1[i];
        }
        for (int i = 0; i < n; i++)
        {
            sum[i] += pol2[i];
        }
        return sum;
    }

    public void Afisare(int[] polinom, int lungime)
    {
        for (int i = 0; i < lungime; i++)
        {
            print(polinom[i]);
            if (i!=0)
            {
                print("x^" + i);
            }
            if (i != lungime -1)
            {
                print("+" );
            }
        }
    }

}
