using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float minLateralForce = -15.0f, maxLateralForce = 15.0f;

    /// <summary>
    /// Tiempo que vamos a tener que esperar entre el lanzamiento de un meteorito y el siguiente.
    /// </summary>
    public float minTimeBetweenStones = 1f, maxTimeBetweenStones = 3f;

    /// <summary>
    /// Cordenadas X y Z de la posición de inicio.
    /// </summary>
    public float minX = -30f, maxX = 30f, minZ = -30f, maxZ = 30f;

    private bool enableStones = true;
    private Rigidbody rigibody;

    public int amoutStone = 20;


    // Use this for initialization
    void Start () {
        StartCoroutine(ThrowStones()); //La corrutina se va a ejecutar despues de todos los updates.
	}


    private IEnumerator ThrowStones()
    {
        // Paramos la corrutina antes de hacer nada y esperamos dos segundos para continuarla.
        yield return new WaitForSeconds(3.0f);

        while (enableStones)
        {
            //Decidimos que tipo piedra vamos a lanzar
            GameObject stone = Instantiate(stones[UnityEngine.Random.Range(0, stones.Length)]);

            //Le damos una posicion y un giro inicial
            stone.transform.position = new Vector3(UnityEngine.Random.Range(minX, maxX), -30.0f, UnityEngine.Random.Range(minZ, maxZ));
            stone.transform.rotation = UnityEngine.Random.rotation;

            //Seleccionamos el rigibody del GameObject
            rigibody = stone.GetComponent<Rigidbody>();

            //Aplicamos la fuerza de giro
            rigibody.AddTorque(Vector3.up * torque, ForceMode.Impulse);
            rigibody.AddTorque(Vector3.right * torque, ForceMode.Impulse);
            rigibody.AddTorque(Vector3.forward * torque, ForceMode.Impulse);

            //Aplicamos la fuerza de impulso
            rigibody.AddForce(Vector3.up * UnityEngine.Random.Range(minAntiGravity, maxAntiGravity), ForceMode.Impulse);
            rigibody.AddForce(Vector3.right * UnityEngine.Random.Range(minLateralForce, maxLateralForce), ForceMode.Impulse);

            //Incrementamos el valor de piedras creadas
            GameManager.stonesThrown++;

            if (GameManager.stonesThrown == amoutStone)
            {
                enableStones = false;
                yield return new WaitForSeconds(6.0f);
            }
            else
            {
                //Paamos la corrutina y le decimos a Unity cada cuanto tiempo la debe volver a llamar.
                yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeBetweenStones, maxTimeBetweenStones));
            }
           
        }
        SceneManager.LoadScene("Final");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
