using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
	
    public GameObject bullet;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	//Se aperta o botão esquerdo do mouse
        if (Input.GetButtonDown("Fire1"))
        {
        	//Armazena na variável 'createdBullet' a função que instancia o objeto bullet
            GameObject createdBullet = Instantiate(bullet);
            //Transforma a posição do objeto dentro da variável 'createdBullet' para a mesma posição do objeto que esse script está anexado
            createdBullet.transform.position = transform.position;
            //Armazena na variável 'bulletRB' a variável 'createdBullet' com o componente Rigidbody
            Rigidbody bulletRB = createdBullet.GetComponent<Rigidbody>();
            //Armazena na variável 'cam' o componente filho da Camera do jogo
            Camera cam = GetComponentInChildren<Camera>();
            //Modifica a velocidade do objeto dentro da variável 'bulletRB'
            bulletRB.velocity = cam.transform.rotation * Vector3.forward * speed;
        }

        
        
    }
}
