using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineCreation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Parts{
    public int healthPoints;
    public float weight;

    public Parts(int hp, float weight){

        healthPoints = hp;
        
    }
    
}
public class Hull : Parts{
    public float strength;

    public Hull(int hp, float wT, float hullStrength) : base(hp, wT){
        strength = hullStrength;
    }
}
public class Body : Parts{
    public bool Drone;

    public Body(int hp, float wT, bool Dronesub) : base(hp, wT){
        Drone = Dronesub;
    }
}
public class Rear : Parts{
    public int thrust;

    public Rear(int hp, float wT, int pThrust ) : base(hp, wT){
      thrust = pThrust;
    }
}

