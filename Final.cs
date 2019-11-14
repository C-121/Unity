using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    public ColPlayer jugador;
    public int MonedasParaGanar;
    public float tiempoParaPerder;
   	public Text textoTiempo;
    public GameObject imagenVictoria;
    public GameObject imagenDerrota;
    public GameObject imagenDerrotaTiempo;


    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
    	textoTiempo.text = Mathf.Round(tiempoParaPerder - jugador.tiempoSeg) + "";
    	if(jugador.monedas >= MonedasParaGanar){
    		imagenVictoria.SetActive(true);
    		Invoke("CargarEscena", 2f);
    	}    
    	if(jugador.vida <= 0){
    		imagenDerrota.SetActive(true);
    		Invoke("CargarEscena", 2f);
    	}
    	if(jugador.tiempoSeg > tiempoParaPerder){
    		imagenDerrotaTiempo.SetActive(true);
    		Invoke("CargarEscena", 2f);	
    	}
    }

    void CargarEscena(){
    	SceneManager.LoadScene("SampleScene");
    }
}
