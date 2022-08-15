using UnityEngine;
using System.Collections;

public class Frenado : MonoBehaviour 
{
	public float VelEntrada = 0;
	public string TagDeposito = "Deposito";
	
	int Contador = 0;
	int CantMensajes = 10;
	float TiempFrenado = 0.5f;
	float Tempo = 0f;
	
	Vector3 Destino;
	
	public bool frenando = false;
	
	//-----------------------------------------------------//
	
	// Use this for initialization
	void Start () 
	{
		Frenar();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void FixedUpdate ()
	{
		if(frenando)
		{
			Tempo += T.GetFDT();
			if(Tempo >= (TiempFrenado / CantMensajes) * Contador)
			{
				Contador++;
			}
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == TagDeposito)
		{
			Deposito2 dep = other.GetComponent<Deposito2>();

			if(dep.Vacio)
			{	
				if(this.GetComponent<Player>().ConBolasas())
				{
					dep.Entrar(this.GetComponent<Player>());
					Destino = other.transform.position;
					transform.forward = Destino - transform.position;
					Frenar();
				}				
			}
		}
	}
	
	//-----------------------------------------------------------//
	
	public void Frenar()
	{
		GetComponent<ControlDireccion>().enabled = false;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		
		frenando = true;
		
		Tempo = 0;
		Contador = 0;
	}
	
	public void RestaurarVel()
	{
		GetComponent<ControlDireccion>().enabled = true;
		frenando = false;
		Tempo = 0;
		Contador = 0;
	}
}
