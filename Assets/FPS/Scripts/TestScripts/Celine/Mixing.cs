using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixing : MonoBehaviour
{
    HoldingSomething holdingPaint;
    [SerializeField] Transform location;

    public static Mixing instance;

    public GameObject panel;

    public bool sand;
    public bool gravel;
    public bool water;
    public bool glue;
    public bool rice;
    public bool dirt;
    public bool milk;
    public bool cementKey;

    public GameObject CementKey;
    public GameObject Sand;
    public GameObject Water;
    public GameObject Gravel;
    public GameObject Glue;
    public GameObject Rice;
    public GameObject Dirt;
    public GameObject Milk;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        location = GameObject.FindGameObjectWithTag("Location").transform;
        holdingPaint = location.gameObject.GetComponent<HoldingSomething>();     
    }

    private void Update()
    {
        if (Sand.activeInHierarchy == false)
        {
            Sand.transform.SetParent(null);
        } 
        
        if (Water.activeInHierarchy == false)
        {
            Water.transform.SetParent(null);
        }
        
        if (Gravel.activeInHierarchy == false)
        {
            Gravel.transform.SetParent(null);
        }
        
        if (Glue.activeInHierarchy == false)
        {
            Glue.transform.SetParent(null);
        } 
        
        if (Rice.activeInHierarchy == false)
        {
            Rice.transform.SetParent(null);
        }
        
        if (Dirt.activeInHierarchy == false)
        {
            Dirt.transform.SetParent(null);
        } 

        if (Milk.activeInHierarchy == false)
        {
            Milk.transform.SetParent(null);
        }

        if (CementKey.activeInHierarchy == false)
        {
            CementKey.transform.SetParent(null);
            holdingPaint.holding = false;
        }
    }

    public void Mix()
    {
        if (!cementKey)
        {
            if (sand == true && water == true && gravel == true)
            {
                if (!glue && !rice && !dirt && !milk)
                {
                    CementKey.SetActive(true);
                    cementKey = true;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "sand")
        {
            sand = true;
            holdingPaint.holding = false;
            Sand.SetActive(false);
           
        }
        
        if (other.name == "emmer")
        {
            water = true;
            holdingPaint.holding = false;
            Water.SetActive(false);
        }

        if (other.name == "gravel")
        {
            gravel = true;
            holdingPaint.holding = false;
            Gravel.SetActive(false);
        }
        
        if (other.name == "glue")
        {
            glue = true; 
            holdingPaint.holding = false;
            Glue.SetActive(false);
        }
        
        if (other.name == "dirt")
        {
            dirt = true;
            holdingPaint.holding = false;
            Dirt.SetActive(false);
        }
        
        if (other.name == "rice")
        {
            rice = true;
            holdingPaint.holding = false;
            Rice.SetActive(false);
        }
        
        if (other.name == "milk")
        {
            milk = true;
            holdingPaint.holding = false;
            Milk.SetActive(false);
        }


        
    }

    private void OnTriggerStay(Collider other)
    {
        panel.SetActive(true);

        if (other.tag == "Player" && Input.GetKey(KeyCode.U))
        {
            if (gravel == true)
            {
                Gravel.GetComponent<ResetPositionPaint>().ResetPos();
            }
            
            if (sand == true)
            {
                Sand.GetComponent<ResetPositionPaint>().ResetPos();
            }
            
            if (water == true)
            {
                Water.GetComponent<ResetPositionPaint>().ResetPos();
            }
            
            if (glue == true)
            {
                Glue.GetComponent<ResetPositionPaint>().ResetPos();
            }
            
            if (rice == true)
            {
                Rice.GetComponent<ResetPositionPaint>().ResetPos();
            }
            
            if (dirt == true)
            {
                Dirt.GetComponent<ResetPositionPaint>().ResetPos();
            }
            
            if (milk == true)
            {
                Milk.GetComponent<ResetPositionPaint>().ResetPos();
            }
            

            sand = false;
            gravel = false;
            water = false;
            rice = false;
            glue = false;
            dirt = false;
            milk = false;

            Milk.SetActive(true);
            Sand.SetActive(true);
            Water.SetActive(true);
            Gravel.SetActive(true);
            Glue.SetActive(true);
            Rice.SetActive(true);
            Dirt.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        panel.SetActive(false);
    }
}
