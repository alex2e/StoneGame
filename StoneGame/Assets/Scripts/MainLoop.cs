using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour {
    /// <summary>
    /// Array de GameObjects que va a representar los 3 tipos de piedra que hemos creado.
    /// </summary>
    public GameObject[] stones = new GameObject[3];

    /// <summary>
    /// Fuerza de torsión que vamos a aplicar en cada uno de los ejes, para que la piedra tenga rotación inicial al crearse.
    /// </summary>
    public float torque = 5.0f;

    /// <summary>
    /// Valores máximos y mínimos que tendremos al crear los meteoritos, que será un número aleatorio entre 20 y 40.
    /// </summary>
    public float minAntiGravity = 20.0f, maxAntiGravity = 40.0f;

    /// <summary>
    /// Fuerza lateral con la que se se van a crear las piedras
    /// </summary>
    public float minLateralForce = -15.0f, maxLateralForce = -15.0f;

    /// <summary>
    /// Tiempo que vamos a tener que esperar entre el lanzamiento de un meteorito y el siguiente.
    /// </summary>
    public float minTimeBetweenStones = 1f, maxTimeBetweenStones = 3f;

    /// <summary>
    /// Cordenadas X y Z de la posición de inicio.
    /// </summary>
    public float minX = -30f, maxX = 30f, minZ = -30f, maxZ = 30f;





    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
