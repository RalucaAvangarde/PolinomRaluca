using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraficScript : MonoBehaviour
{
    public GameObject punct;
    public List<Vector2> punctePeGrafic;
    public Transform ChartContainer;
    private Polinom polinom;
    // Start is called before the first frame update
    public void Start()
    {
        polinom = new Polinom();
        punctePeGrafic = new List<Vector2>();
        for (float i = -10; i <= 10; i += 0.1f)
        {
            var temp = new Vector2();
            temp.x = i;
            //temp.y = temp.y = (float)polinom.CalculeazaValoarea((int)i);// i;//(float)Math.Cos(i + 0.5f); // temp.y = CaculeazaValoarea(i)
            punctePeGrafic.Add(temp);
        }

        foreach (var item in punctePeGrafic)
        {
            Instantiate(punct, new Vector2(item.x, item.y), Quaternion.identity, ChartContainer);
        }

    }


}
