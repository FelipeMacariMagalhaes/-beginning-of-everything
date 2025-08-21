using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Metodo : MonoBehaviour
{
    public int n;
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    void Start()
    {

        Repetir2(n);
    }

    void Repetir2(int n)
    {

        for (int i = 1; i < n; i++)
        {
            string resultado = "";
            for (int j = 1; j < i; j++)
            {
                resultado += j + " ";
            }
            Debug.Log(resultado);
        }

    }
}

