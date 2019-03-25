using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PolinomScript : MonoBehaviour
{

    public List<Vector2> PunctePeGrafic;
    [SerializeField]
    private InputField fieldValue;
    [SerializeField]
    private InputField fieldValue2;
    [SerializeField]
    private InputField value1;
    [SerializeField]
    private InputField value2;
    [SerializeField]
    private InputField valueR;
    [SerializeField]
    private Text myText1;
    [SerializeField]
    private Text myText2;
    [SerializeField]
    private Text rezultText;
    [SerializeField]
    private GameObject myImage;
    [SerializeField]
    private GameObject punct;
    [SerializeField]
    private Transform chartContainer;
    private List<double> inputList;
    private List<double> inputList2;
    private Polinom rezultat;
    private Polinom polinom1;
    private Polinom polinom2;
    private Polinom polinom;
    private bool check1;
    private bool check2;

    void Start()
    {
        check1 = false;
        check2 = false;
        inputList = new List<double>();
        inputList2 = new List<double>();
        fieldValue = fieldValue.GetComponent<InputField>();
        fieldValue2 = fieldValue2.GetComponent<InputField>();
        value1 = value1.GetComponent<InputField>();
        value2 = value2.GetComponent<InputField>();
    }
    private void Awake()
    {
        myText1 = myText1.GetComponent<Text>();
        myText2 = myText2.GetComponent<Text>();
        rezultText = rezultText.GetComponent<Text>();

    }
    public void ShowPolinom1()
    {
        try
        {
            string str = fieldValue.text;
            if (str != null)
            {
                inputList.Clear();
                inputList = (str.Trim().Split(null)).Select(Double.Parse).ToList();
                inputList.Reverse();
                polinom1 = new Polinom(inputList);
                myText1.text = polinom1.ToString();
                check1 = true;
                //FieldValue.text = ""; - clear the field
            }
            
        }
        catch(Exception)
        {
            Debug.LogError("Incorrect format");
        }

    }

    public void ShowPolinom2()
    {
        try
        {
            string str2 = fieldValue2.text;

            if (str2 != null)
            {
                inputList2.Clear();
                inputList2 = (str2.Trim().Split(null)).Select(Double.Parse).ToList();
                inputList2.Reverse();
                polinom2 = new Polinom(inputList2);
                myText2.text = polinom2.ToString();
                check2 = true;
            }
            
        }
        catch(Exception)
        {
            Debug.LogError("Incorrect format");
        }
    }

    //adunare
    public void ShowAdunare()
    {
        if (check1 && check2)
        {
            rezultat = (polinom1 + polinom2);
            rezultText.text = rezultat.ToString();
        }
        else
        {
            Debug.Log("You need to have 2 polinomyals for this operation");
        }
    }
    //scadere
    public void ShowScadere()
    {
        if (check1 && check2)
        {
            rezultat = (polinom1 - polinom2);
            rezultText.text = rezultat.ToString();
        }
        else
        {
            Debug.Log("You need to have 2 polinomyals for this operation");
        }
    }
    // inmultire
    public void ShowInmultire()
    {
        if (check1 && check2)
        {
            rezultat = (polinom1 * polinom2);
            rezultText.text = rezultat.ToString();
        }
        else
        {
            Debug.Log("You need to have 2 polinomyals for this operation");
        }

    }
    //derivare
    public void ShowDerivareP1()
    {
        rezultat = polinom1.Derivare();
        rezultText.text = rezultat.ToString();
    }
    public void ShowDerivareP2()
    {
        rezultat = polinom2.Derivare();
        rezultText.text = rezultat.ToString();
    }
    //integrare
    public void ShowIntegrareP1()
    {
        rezultat = polinom1.Integrare();
        rezultText.text = rezultat.ToString();

    }
    public void ShowIntegrareP2()
    {
        rezultat = polinom2.Integrare();
        rezultText.text = rezultat.ToString();
    }

    // integrare rezultat final
    public void IntegrareRezultat()
    {
        rezultText.text = rezultat.Integrare().ToString();

    }
    // derivare rezultat final
    public void DerivareRezultat()
    {
        rezultText.text = rezultat.Derivare().ToString();
    }
    // valoare pt rezultat final
    public void ValoareRezultat()
    {
        if (valueR.text != null)
        {
            double result = Double.Parse(valueR.text);
            rezultText.text = rezultat.CalculeazaValoarea(result).ToString();
            valueR.gameObject.SetActive(false);
        }
    }
    public void ShowValueR()
    {
        valueR.gameObject.SetActive(true);

    }

    public void ShowValueP1()
    {
        value1.gameObject.SetActive(true);

    }

    public void CalculWihValue1()
    {
        if (value1.text != null)
        {
            double result = Double.Parse(value1.text);
            rezultText.text = polinom1.CalculeazaValoarea(result).ToString();
            value1.gameObject.SetActive(false);
            //Debug.Log("Valoarea Polinomului1 in punctul dat este: " + polinom1.CalculeazaValoarea(result));
        }
        else
        {
            Debug.Log("Please insert a number!");
        }
    }

    public void ShowValueP2()
    {
        value2.gameObject.SetActive(true);

    }
    public void CalculWihValue2()
    {
        if (value2.text != null)
        {
            int result = Int32.Parse(value2.text);
            rezultText.text = polinom2.CalculeazaValoarea(result).ToString();
            value2.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Please insert a number!");
        }
    }
    //Grafic
    public void GraficP1()
    {
        myImage.gameObject.SetActive(true);
        PlotChart(polinom1);
    }

    public void GraficP2()
    {
        myImage.gameObject.SetActive(true);
        PlotChart(polinom2);

    }
    public void GraficR()
    {
        myImage.gameObject.SetActive(true);
        PlotChart(rezultat);
    }
    public void CloseGrafic()
    {
        myImage.gameObject.SetActive(false);
        foreach (Transform child in chartContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    //grafic function
    public void PlotChart(Polinom polinom)
    {

        List<Vector2> PunctePeGrafic = new List<Vector2>();
        for (float i = -10; i <= 10; i += 0.02f)
        {
            var temp = new Vector2();
            temp.x = i;
            temp.y = Mathf.Clamp((float)polinom.CalculeazaValoarea(i), -10, 10);
            PunctePeGrafic.Add(temp);

        }
        foreach (var item in PunctePeGrafic)
        {
            Instantiate(punct, new Vector2(item.x, item.y), Quaternion.identity, chartContainer);
        }

    }
}