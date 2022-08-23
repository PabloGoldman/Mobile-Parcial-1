using UnityEngine;
using System.Collections;

public class ControlDireccion : MonoBehaviour 
{
	public enum TipoInput {Mouse, Kinect, AWSD, Arrows}
	public TipoInput InputAct = ControlDireccion.TipoInput.Mouse;

	public Transform ManoDer;
	public Transform ManoIzq;
	
	public float MaxAng = 90;
	public float DesSencibilidad = 90;
	
	float Giro = 0;
	
	public bool Habilitado = true;
		
	void Update () 
	{
		switch(InputAct)
		{
            case TipoInput.AWSD:
                if (Habilitado) {
                    if (Input.GetKey(KeyCode.A)) 
					{
						GetComponent<CarController>().SetGiro(-1);
                    }
                    if (Input.GetKey(KeyCode.D)) 
					{
						GetComponent<CarController>().SetGiro(1);
                    }
                }
                break;
            case TipoInput.Arrows:
                if (Habilitado) {
                    if (Input.GetKey(KeyCode.LeftArrow)) 
					{
						GetComponent<CarController>().SetGiro(-1);
					}
					if (Input.GetKey(KeyCode.RightArrow)) 
					{
						GetComponent<CarController>().SetGiro(1);
					}
				}
                break;
        }		
	}

	public float GetGiro()
	{
		return Giro;
	}
}
