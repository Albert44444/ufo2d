using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]

    float speed;
    int puntuacio = 0;
    int totalpickups;
    [SerializeField]
    TextMeshProUGUI textpuntuacio;
    
    [SerializeField]
    TextMeshProUGUI TextVictoria;


    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        totalpickups = GameObject.FindGameObjectsWithTag("Pickup").Length;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movment = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movment*speed);
       


    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.CompareTag("Pickup"))
        {
            puntuacio++; 
            textpuntuacio.text = puntuacio.ToString();
            Destroy(colision.gameObject);
            totalpickups--;


        }
        if (totalpickups == 0)
        {
            TextVictoria.text = "Albert has guanyat victoria!! ";
            TextVictoria.gameObject.SetActive(true);
        }
    }
}
