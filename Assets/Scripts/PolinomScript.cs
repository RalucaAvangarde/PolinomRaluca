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
    private Polinom rezultPolynomial;
    private Polinom leftPolynomial;
    private Polinom rightPolynomial;
    //private Polinom polinom;

    void Start()
    {
        inputList = new List<double>();
        inputList2 = new List<double>();
        fieldValue = fieldValue.GetComponent<InputField>();
        fieldValue2 = fieldValue2.GetComponent<InputField>();
        value1 = value1.GetComponent<InputField>();
        value2 = value2.GetComponent<InputField>();
        leftPolynomial = new Polinom();
        rightPolynomial = new Polinom();
    }
    private void Awake()
    {
        myText1 = myText1.GetComponent<Text>();
        myText2 = myText2.GetComponent<Text>();
        rezultText = rezultText.GetComponent<Text>();

    }
    public void ShowLeftPolynomial()
    {
        try
        {
            string str = fieldValue.text;
            if (str != null)
            {
                inputList.Clear();
                inputList = (str.Trim().Split(null)).Select(Double.Parse).ToList();
                inputList.Reverse();
                leftPolynomial = new Polinom(inputList);
                myText1.text = leftPolynomial.ToString();

                //FieldValue.text = ""; - clear the field
            }

        }
        catch (Exception)
        {
            Debug.LogError("Incorrect format");
        }

    }

    public void ShowRightPolynomial()
    {
        try
        {
            string str2 = fieldValue2.text;

            if (str2 != null)
            {
                inputList2.Clear();
                inputList2 = (str2.Trim().Split(null)).Select(Double.Parse).ToList();
                inputList2.Reverse();
                rightPolynomial = new Polinom(inputList2);
                myText2.text = rightPolynomial.ToString();

            }

        }
        catch (Exception)
        {
            Debug.LogError("Incorrect format");
        }
    }

    //addition
    public void ShowAddition()
    {

        if (leftPolynomial.IsInitialized && rightPolynomial.IsInitialized)
        {
            rezultPolynomial = (leftPolynomial + rightPolynomial);
            rezultText.text = rezultPolynomial.ToString();
        }
        else
        {
            Debug.Log("You need to have 2 polinomyals for this operation");
        }



    }
    //substraction
    public void ShowSubstraction()
    {
        if (leftPolynomial.IsInitialized && rightPolynomial.IsInitialized)
        {
            rezultPolynomial = (leftPolynomial - rightPolynomial);
            rezultText.text = rezultPolynomial.ToString();
        }
        else
        {
            Debug.Log("You need to have 2 polinomyals for this operation");
        }
    }
    //  multiplication
    public void ShowMultiplication()
    {
        if (leftPolynomial.IsInitialized && rightPolynomial.IsInitialized)
        {
            rezultPolynomial = (leftPolynomial * rightPolynomial);
            rezultText.text = rezultPolynomial.ToString();
        }
        else
        {
            Debug.Log("You need to have 2 polinomyals for this operation");
        }

    }
    //derivation
    public void DerivationLeftPolynomial()
    {
        rezultPolynomial = leftPolynomial.Derivare();
        rezultText.text = rezultPolynomial.ToString();
    }
    public void DerivationRightPolynomial()
    {
        rezultPolynomial = rightPolynomial.Derivare();
        rezultText.text = rezultPolynomial.ToString();
    }
    //integration
    public void IntegrationLeftPolynomial()
    {
        rezultPolynomial = leftPolynomial.Integrare();
        rezultText.text = rezultPolynomial.ToString();

    }
    public void IntegrationRightPolynomial()
    {
        rezultPolynomial = rightPolynomial.Integrare();
        rezultText.text = rezultPolynomial.ToString();
    }

    // final result integration
    public void IntegrationRezult()
    {
        rezultText.text = rezultPolynomial.Integrare().ToString();

    }
    // final result derivation
    public void DerivationRezult()
    {
        rezultText.text = rezultPolynomial.Derivare().ToString();
    }
    // final result value
    public void ValueRezult()
    {
        if (valueR.text != null)
        {
            double result = Double.Parse(valueR.text);
            rezultText.text = rezultPolynomial.CalculeazaValoarea(result).ToString();
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
            rezultText.text = leftPolynomial.CalculeazaValoarea(result).ToString();
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
            rezultText.text = rightPolynomial.CalculeazaValoarea(result).ToString();
            value2.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Please insert a number!");
        }
    }
    //chart
    public void GraficP1()
    {
        myImage.gameObject.SetActive(true);
        PlotChart(leftPolynomial);
    }

    public void GraficP2()
    {
        myImage.gameObject.SetActive(true);
        PlotChart(rightPolynomial);

    }
    public void GraficR()
    {
        myImage.gameObject.SetActive(true);
        PlotChart(rezultPolynomial);
    }
    public void CloseGrafic()
    {
        myImage.gameObject.SetActive(false);
        foreach (Transform child in chartContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    //graph function
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