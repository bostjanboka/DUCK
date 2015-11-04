using UnityEngine;
using System.Collections;

public class DodajMaterialSkripta : MonoBehaviour {

    // Use this for initialization
    static public Material[] material;
    static public Material[] materialA;

    public Material cloneM;
	void Start () {
        material = new Material[5];
        material[0] = Material.Instantiate(cloneM) as Material;
        material[1] = Material.Instantiate(cloneM) as Material;
        material[2] = Material.Instantiate(cloneM) as Material;
        material[3] = Material.Instantiate(cloneM) as Material;
        material[4] = Material.Instantiate(cloneM) as Material;
        material[0].color = new Color(0.988f, 0.745f, 0.122f);
        material[1].color = new Color(0.063f, 0.616f, 0.349f);
        material[2].color = new Color(0.863f, 0.2672f, 0.216f);
        material[3].color = new Color (0.263f, 0.522f, 0.96f);
        material[4].color = new Color (1f, 1f, 1f);

        materialA = new Material[material.Length];
        for(int i=0; i < material.Length; i++)
        {
            materialA[i] = Material.Instantiate(material[i]);
            Color zac = materialA[i].color;
            materialA[i].color = new Color(zac.r, zac.g, zac.b, 0.2f);
        }
        
        
    }

    static public int getStevilkaBarve()
    {
        return Random.Range(0, material.Length);
    }
	
	static public Material getMaterial(int i)
    {
        return material[i];
    }

    static public Material getMaterialA(int i)
    {
        return materialA[i];
    }
}
