using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PolinomScript : MonoBehaviour
{
    public GameObject MyImage;
    public GameObject MyImage2;
    public GameObject MyImageR;
    public GameObject Punct;
    public List<Vector2> PunctePeGrafic;
    public Transform ChartContainer;
    public Transform ChartContainer2;
    public Transform ChartContainerR;
    public InputField FieldValue;
    public InputField FieldValue2;
    public InputField Value1;
    public InputField Value2;
    public InputField ValueR;
    public Text MyText1;
    public Text MyText2;
    public Text RezultText;
    private List<double> inputList;
    private List<double> inputList2;
    private Polinom rezultat;
    private Polinom polinom1;
    private Polinom polinom2;
    

    void Start()
    {
        inputList = new List<double>();
        inputList2 = new List<double>();
        FieldValue = FieldValue.GetComponent<InputField>();
        FieldValue2 = FieldValue2.GetComponent<InputField>();
        Value1 = Value1.GetComponent<InputField>();
        Value2 = Value2.GetComponent<InputField>();
        polinom1 = new Polinom(inputList);//new List<double>() { 1, 2, 4 });
        polinom2 = new Polinom(inputList2);//new List<double>() { -2, 4 });
    }
    private void Awake()
    {
        MyText1 = MyText1.GetComponent<Text>();
        MyText2 = MyText2.GetComponent<Text>();
        RezultText = RezultText.GetComponent<Text>();

    }
    public void ShowPolinom1()
    {

        string str = FieldValue.text;
        if (str != null )
        {
            inputList.Clear();
            inputList = (str.Trim().Split(null)).Select(Double.Parse).ToList();
            inputList.Reverse();
            polinom1 = new Polinom(inputList);
            MyText1.text = polinom1.ToString();
            //FieldValue.text = ""; - clear the field
        }
        else
        {
            Debug.Log("Incorrect format");
        }

       
    }

    public void ShowPolinom2()
    {
        string str2 = FieldValue2.text;

        if (str2 != null) //&& !(str2.All(Char.IsDigit)))
        {
            inputList2.Clear();
            inputList2 = (str2.Trim().Split(null)).Select(Double.Parse).ToList();
            inputList2.Reverse();
            polinom2 = new Polinom(inputList2);
            MyText2.text =polinom2.ToString();
            //FieldValue2.text=""; //- clear the field
        }
        else
        {
            Debug.Log("Incorrect format");
        }
    }

    //adunare
    public void ShowAdunare()
    {
        rezultat = (polinom1 + polinom2);
        RezultText.text = rezultat.ToString();
       // Debug.Log("Adunare: " + (polinom1 + polinom2));
    }
    //scadere
    public void ShowScadere()
    {
        rezultat = (polinom1 - polinom2);
        RezultText.text = rezultat.ToString();
    }
    // inmultire
    public void ShowInmultire()
    {
        rezultat = (polinom1 * polinom2);
        RezultText.text = rezultat.ToString(); 
        
    }
    //derivare
    public void ShowDerivareP1()
    {
        rezultat = polinom1.Derivare();
        RezultText.text = rezultat.ToString(); 
        //Debug.Log("Derivare: " + (polinom1.Derivare()));
    }
    public void ShowDerivareP2()
    {
        rezultat = polinom2.Derivare();
        RezultText.text = rezultat.ToString();
        //Debug.Log("Derivare: " + (polinom2.Derivare()));
    }
    //integrare
    public void ShowIntegrareP1()
    {
        rezultat = polinom1.Integrare();
        RezultText.text = rezultat.ToString();
        Debug.Log("Integrare: " + (polinom1.Integrare()));
    }
    public void ShowIntegrareP2()
    {
        rezultat = polinom2.Integrare();
        RezultText.text = rezultat.ToString();
        Debug.Log("Integrare: " + (polinom2.Integrare()));
    }

    // integrare rezultat final
    public void IntegrareRezultat()
    {
        RezultText.text = rezultat.Integrare().ToString();
        /*
        if (RezultText.text ==(polinom1+polinom2).ToString())
        {
            RezultText.text = ((polinom1 + polinom2).Integrare()).ToString(); //integrare adunare
        }
        else if (RezultText.text == (polinom2.Derivare().ToString()))
        {
            RezultText.text = polinom2.Derivare().Integrare().ToString(); //integrare p2 derivat
        }
        */

    }
    // derivare rezultat final
    public void DerivareRezultat()
    {
        RezultText.text = rezultat.Derivare().ToString();
    }
    // valoare pt rezultat final
    public void ValoareRezultat()
    {
        if (ValueR.text != null)
        {
            double result = Double.Parse(ValueR.text);
            RezultText.text = rezultat.CalculeazaValoarea(result).ToString();
            ValueR.gameObject.SetActive(false);
        }
    }
    public void ShowValueR()
    {
        ValueR.gameObject.SetActive(true);

    }
    //activeaza input field pt a introduce valoare+ calcul polinom in punctul dat
    public void ShowValueP1()
    {
        Value1.gameObject.SetActive(true);

    }
   
    public void CalculWihValue1()
    {
        if (Value1.text != null)
        {
            double result = Double.Parse(Value1.text);
            RezultText.text = polinom1.CalculeazaValoarea(result).ToString();
            Debug.Log("Valoarea Polinomului1 in punctul dat este: " + polinom1.CalculeazaValoarea(result));
            Value1.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Please insert a number!");
        }
    }

    public void ShowValueP2()
    {
        Value2.gameObject.SetActive(true);

    }
    public void CalculWihValue2()
    {
        if (Value2.text != null)
        {
            int result = Int32.Parse(Value2.text);
            RezultText.text = polinom2.CalculeazaValoarea(result).ToString();
            Debug.Log("Valoarea Polinomului2 in punctul dat este: " + polinom2.CalculeazaValoarea(result));
            Value2.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Please insert a number!");
        }
    }

    public void GraficP1()
    {
        MyImage.gameObject.SetActive(true);
        polinom1.PlotChart(Punct, ChartContainer);
    }

    public void GraficP2()
    {
        MyImage2.gameObject.SetActive(true);
        polinom2.PlotChart(Punct, ChartContainer2);
    }
    public void GraficR()
    {
        MyImageR.gameObject.SetActive(true);
        rezultat.PlotChart(Punct, ChartContainerR);
    }
    public void CloseGrafic()
    {
        MyImage.gameObject.SetActive(false);
        MyImage2.gameObject.SetActive(false);
        MyImageR.gameObject.SetActive(false);
    }
    
}
