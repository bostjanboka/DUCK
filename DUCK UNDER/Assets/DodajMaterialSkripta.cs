using UnityEngine;
using System.Collections;

public class DodajMaterialSkripta : MonoBehaviour {

    // Use this for initialization
    public Material[] material;
    public Material[] materialA;

    static public Material[] avto;
    static public Material[] avtoT;

    public Material cloneM;

    static Material[] barveAvto;
    static Material[] barveAvtoT;
    void Start () {

        avto = new Material[6];
        avtoT = new Material[6];
        for (int i = 0; i < material.Length; i++)
        {
            avto[i] = Material.Instantiate(material[i]) as Material;
        }


        barveAvto = new Material[5];
        barveAvtoT = new Material[5];
        barveAvto[0] = Material.Instantiate(avto[0]) as Material;
        barveAvto[1] = Material.Instantiate(avto[0]) as Material;
        barveAvto[2] = Material.Instantiate(avto[0]) as Material;
        barveAvto[3] = Material.Instantiate(avto[0]) as Material;
        barveAvto[4] = Material.Instantiate(avto[0]) as Material;

        barveAvto[0].color = new Color(0.988f, 0.745f, 0.122f);
        barveAvto[1].color = new Color(0.063f, 0.616f, 0.349f);
        barveAvto[2].color = new Color(0.863f, 0.2672f, 0.216f);
        barveAvto[3].color = new Color (0.263f, 0.522f, 0.96f);
        barveAvto[4].color = new Color (1f, 1f, 1f);

        
        for(int i=0; i < materialA.Length; i++)
        {
            avtoT[i] = Material.Instantiate(materialA[i]);
            Color zac = material[i].color;
            avtoT[i].color = new Color(zac.r, zac.g, zac.b, 0.2f);
        }
        for(int i=0; i < barveAvtoT.Length; i++)
        {
            barveAvtoT[i] = Material.Instantiate(barveAvto[i]);
            Color zac = barveAvtoT[i].color;
            barveAvtoT[i].color = new Color(zac.r, zac.g, zac.b, 0.2f);
        }
        
        
    }

    static public int getStevilkaBarve()
    {
        return Random.Range(0, barveAvto.Length);
    }
	
	static public Material[] getMaterial(int i, int id)
    {
        if(id == 1)
        {
            avto[0] = barveAvto[i];
            return avto;
        }
        return null;
    }

    static public Material[] getMaterialA(int i, int id)
    {
        if(id == 1)
        {
            avtoT[0] = barveAvtoT[i];
            return avtoT;
        }
        return null;
    }
}
