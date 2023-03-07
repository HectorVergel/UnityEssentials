using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    
    public static void SpawnParticle(string _Path, Vector3 _Position, float _ScreenTime)
    {
        
        ParticleSystem l_pe = Resources.Load<ParticleSystem>("Particles/" + _Path);
        if(l_pe == null) { Debug.Log("No particles matching the path, be sure to put the particles in the folder Particles"); }
        ParticleSystem l_ps = Instantiate(l_pe, _Position, Quaternion.identity);

        Destroy(l_ps, _ScreenTime);
    }

    public static void SpawnParticle(string _Path, Transform _Parent, float _ScreenTime)
    {

        ParticleSystem l_pe = Resources.Load<ParticleSystem>("Particles/" + _Path);
        if (l_pe == null) { Debug.Log("No particles matching the path, be sure to put the particles in the folder Particles"); }
        ParticleSystem l_ps = Instantiate(l_pe, _Parent);

        Destroy(l_ps, _ScreenTime);
    }
    
}
