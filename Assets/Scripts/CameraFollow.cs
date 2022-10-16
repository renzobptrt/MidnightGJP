using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow sharedInstance;
    public Transform target = null;

    /* Dejar una pequeña distancia de seguimiento */
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    /*  Tiempo donde la camara se quedara quita y luego 
        comenzara a seguir
    */
    public float dampTime = 0.3f;

    /* Velocidad de la carama */
    public Vector3 velocity = Vector3.zero;

    void Awake()
    {
        /* Para intentar que la actualizacion de 
            frames sea constante al numero que 
            le indique si es que puede.*/
        Application.targetFrameRate = 60;
        sharedInstance = this;
    }

    void Start()
    {
        startPosition = target;
    }

    public void ResetCameraPosition()
    {
        Vector3 destination;
        destination = new Vector3(target.position.x, offset.y, offset.z);

        this.transform.position = destination;
    }

    void Update()
    {
        Vector3 initialPosition = startPosition.position;//Posicion inicial de la camara, debera ser del vehiculo
        /* Fondos siempre se configuran en la cámara */
        Vector3 destination, startDestination;

        destination = new Vector3(target.position.x, offset.y, offset.z);
        startDestination = new Vector3(initialPosition.x, offset.y, offset.z);
        /* Mueve la camara de forma suave */
        if (destination.x <= initialPosition.x - 2)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, startDestination, ref velocity, dampTime);
        }
        else
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, dampTime);
        }
    }

    private Transform startPosition = null;
}
