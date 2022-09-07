using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    //Puntos 
    //GameObject son los objetos UI (Text, Image, Button, Panel)
    public GameObject txtPuntos;
    private int puntos;

    //Agregar tiempo
    private float tiempo = 0.0f;
    private int hora = 0;
    private int minuto = 0;
    private int segundo = 0;
    private string tiempos;

    //Personaje
    //Transform  se utiliza para mover, rotar los objetos 3D
    private float velocidad = 3f;
    public Transform myObjeto;

    //Agregar sonido
    public AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip;

    //velocidad de rotación
    public float velRot = 180.0f;
    //vector para almacenar la rotación de la cámara
    Vector3 currentRot;
    //límites de la rotación
    float minRot = -30.0f;
    float maxRot = 90.0f;
    float rotX;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        myObjeto = GetComponent<Transform>();
        currentRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        minuto = Mathf.FloorToInt(tiempo / 60);
        segundo = Mathf.FloorToInt(tiempo - minuto * 60);
        if (segundo > 60)
        {
            minuto++;
            segundo = 0;
        }
        //Debug.Log("Tiempo: " + minuto + ":" + segundo);
        tiempos = minuto.ToString() + ":" + segundo.ToString();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myObjeto.transform.position += Vector3.left * velocidad * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myObjeto.transform.position += Vector3.right * velocidad * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            myObjeto.transform.position += Vector3.forward * velocidad * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            myObjeto.transform.position += Vector3.back * velocidad * Time.deltaTime;
        }
        /*if (Input.GetKey(KeyCode.Space))
        {
            myObjeto.transform.position += Vector3.up * velocidad * Time.deltaTime;
        }*/
        currentRot.x -= Input.GetAxis("Mouse Y") * velRot * Time.deltaTime;
        currentRot.y += Input.GetAxis("Mouse X") * velRot * Time.deltaTime;
        currentRot.x = Mathf.Clamp(currentRot.x, minRot, maxRot);
        transform.localEulerAngles = currentRot;

    }

    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject.tag == "rubi")
        {
            //Debug.Log("Choque con el rubi");
            Destroy(objeto.gameObject);
            audioSource.PlayOneShot(clip);
            puntos += 1;
            txtPuntos.GetComponent<Text>().text = puntos.ToString();
        }
    }
}
