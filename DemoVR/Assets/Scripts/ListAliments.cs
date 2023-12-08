using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAlimant : MonoBehaviour
{

    public class Tracking {
        public string nom;
        public bool status;
    }

    public class Aliments
    {
        public string name;
        public string description;
        public string type;
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //Aliment 1
    // Chocolatine
    // Result : Pas bien
    public ArrayList myTracking;

    // Start is called before the first frame update
    void Start()
    {
        myTracking = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
