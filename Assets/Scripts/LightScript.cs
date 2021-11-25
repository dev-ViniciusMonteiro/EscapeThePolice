using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.alura.com.br/curso-online-criacao-de-jogos-com-unity
public class LightScript : MonoBehaviour
{
    //luz
    Light lightSettings;
    bool change = false;
    public bool changeColor = false;
    public float timeToChange;
    public float timeScale;

    private void Awake()
    {//pega componente
        lightSettings = GetComponent<Light>();
    }
    private void Start()
    {//pega cor
        lightSettings.color = Color.white;
    }

    private void Update()
    {//se e pra mudar cor
        if (changeColor)
        {
            lightSettings.range = timeToChange;

            if (change)
                timeToChange -= Time.deltaTime * timeScale;
            else
                timeToChange += Time.deltaTime * timeScale;

            if (lightSettings.range <= 10)
                change = false;
            else if (lightSettings.range >= 13)
                change = true;
        }
    }

}
