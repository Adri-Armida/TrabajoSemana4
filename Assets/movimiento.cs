using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour {
	static public int puntos = 0;
	private float velocidad = 2.0f;
	public Rigidbody rb;
	private float velocidadInicio = 100.0f;
	bool activo = false;
	public ParticleSystem Particulas;
	private float Tiempo = 0f;
	public bool dentro = false;

	static movimiento Instance;

	// Use this for initialization
	void Start () {
		 rb = GetComponent<Rigidbody>();

		Particulas.Stop ();
		if (Instance != null) 
		{
			GameObject.Destroy(gameObject);
		} 
		else 
		{
			GameObject.DontDestroyOnLoad(gameObject);
			Instance = this;
		}


		//movimiento automatico para delante de la bola
		rb.AddForce(-velocidadInicio * velocidad, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		TocarMoneda ();
		if (Input.GetTouch(0).phase == TouchPhase.Began) 
		{
			if(activo == false) //izquierda
			{
				//rb.transform.Translate(-0.5f, 0.0f, 0.0f);
				//rb.transform.Rotate (0, 10, 0);
				rb.AddForce(150, 0, -200);
				activo = true;
			}
			else if(activo == true) //delante
			{
				//rb.transform.Translate(0, 90, 0);
				//rb.transform.Translate(0.0f, -0.5f, 0.0f);
				//rb.transform.Rotate (-5, 0, 0);
				rb.AddForce(-200, 0, 200);
				activo = false;
			}
		}

	
	}

	void TocarMoneda(){
		if (dentro == true) {
			Tiempo = Tiempo + 1 * Time.deltaTime;
			if (Tiempo > 2f) {
				Particulas.Stop ();
				dentro = false;
				Tiempo = 0f;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Moneda") {
			Particulas.Play ();
			dentro = true;
		}

		if (other.gameObject.tag == "Fin") {
			rb.transform.Translate(new Vector3(3.24f,0.19f,0.24f));
			Application.LoadLevel ("mapa2");

		}
			                       
	}


	void OnGUI(){
		if(puntos != 160)
			GUILayout.Label("Puntuacion: " + puntos);
	
	}
}
