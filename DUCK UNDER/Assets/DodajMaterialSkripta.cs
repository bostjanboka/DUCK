using UnityEngine;
using System.Collections;

public class DodajMaterialSkripta : MonoBehaviour {

    // Use this for initialization
    public Material[] material;
    public Material[] materialA;

    static public Material[] avto;
    static public Material[] avtoT;

    static public Material[][] sportX;
    static public Material[][] sportXT;

    static public Material[][] avtoX;
    static public Material[][] avtoXT;

    static public Material[][] kombiX;
    static public Material[][] kombiXT;

    static public Material[][] pickX;
    static public Material[][] pickXT;

    static public Material[][] manX;
    static public Material[][] manXT;

    public Material cloneM;

    static Material[] barveAvto;
    static Material[] barveAvtoT;
    static Color[] barve;
    void Start () {

        

        barve = new Color[5];
        barve[0] = new Color(0.988f, 0.745f, 0.122f);
        barve[1] = new Color(0.063f, 0.616f, 0.349f);
        barve[2] = new Color(0.863f, 0.2672f, 0.216f);
        barve[3] = new Color(0.263f, 0.522f, 0.96f);
        barve[4] = new Color(1f, 1f, 1f);

        Color[] barveT = new Color[5];
        barveT[0] = new Color(0.988f, 0.745f, 0.122f, 0.2f);
        barveT[1] = new Color(0.063f, 0.616f, 0.349f, 0.2f);
        barveT[2] = new Color(0.863f, 0.2672f, 0.216f, 0.2f);
        barveT[3] = new Color(0.263f, 0.522f, 0.96f, 0.2f);
        barveT[4] = new Color(1f, 1f, 1f, 0.2f);

        avtoX = new Material[5][];
        avtoXT = new Material[5][];

        avtoX[0] = new Material[6];
        avtoX[0][0] = Material.Instantiate(material[0]) as Material;
        avtoX[0][1] = Material.Instantiate(material[1]) as Material;
        avtoX[0][2] = Material.Instantiate(material[2]) as Material;
        avtoX[0][3] = Material.Instantiate(material[3]) as Material;
        avtoX[0][4] = Material.Instantiate(material[4]) as Material;
        avtoX[0][5] = Material.Instantiate(material[5]) as Material;


        avtoXT[0] = new Material[6];
        avtoXT[0][0] = Material.Instantiate(materialA[0]) as Material;
        avtoXT[0][1] = Material.Instantiate(materialA[1]) as Material;
        avtoXT[0][2] = Material.Instantiate(materialA[2]) as Material;
        avtoXT[0][3] = Material.Instantiate(materialA[3]) as Material;
        avtoXT[0][4] = Material.Instantiate(materialA[4]) as Material;
        avtoXT[0][5] = Material.Instantiate(materialA[5]) as Material;

        for (int i = 1; i < avtoX.Length; i++)
        {
            avtoX[i] = new Material[6];
            avtoXT[i] = new Material[6];

            avtoX[i][0] = Material.Instantiate(avtoX[0][0]) as Material;
            avtoX[i][0].color = barve[i];


            avtoXT[i][0] = Material.Instantiate(avtoXT[0][0]) as Material;
            avtoXT[i][1] = Material.Instantiate(avtoXT[0][1]) as Material;
            avtoXT[i][0].color = barveT[i];
            for (int j = 1; j < avtoX[i].Length; j++)
            {
                avtoX[i][j] = avtoX[0][j];


                avtoXT[i][j] = avtoXT[0][j];
                Color zac = avtoXT[i][j].color;
                avtoXT[i][j].color = new Color(zac.r, zac.g, zac.b, 0.2f);
            }
        }

        kombiX = new Material[5][];
        kombiXT = new Material[5][];

        kombiX[0] = new Material[7];
        kombiX[0][0] = Material.Instantiate(material[0]) as Material;
        kombiX[0][1] = Material.Instantiate(material[0]) as Material;
        kombiX[0][2] = Material.Instantiate(material[4]) as Material;
        kombiX[0][3] = Material.Instantiate(material[5]) as Material;
        kombiX[0][4] = Material.Instantiate(material[1]) as Material;
        kombiX[0][5] = Material.Instantiate(material[3]) as Material;
        kombiX[0][6] = Material.Instantiate(material[2]) as Material;

        kombiXT[0] = new Material[7];
        kombiXT[0][0] = Material.Instantiate(materialA[0]) as Material;
        kombiXT[0][1] = Material.Instantiate(materialA[0]) as Material;
        kombiXT[0][2] = Material.Instantiate(materialA[4]) as Material;
        kombiXT[0][3] = Material.Instantiate(materialA[5]) as Material;
        kombiXT[0][4] = Material.Instantiate(materialA[1]) as Material;
        kombiXT[0][5] = Material.Instantiate(materialA[3]) as Material;
        kombiXT[0][6] = Material.Instantiate(materialA[2]) as Material;
        for (int i=1; i < kombiX.Length; i++)
        {
            kombiX[i] = new Material[7];
            kombiXT[i] = new Material[7];

            kombiX[i][0] = Material.Instantiate(kombiX[0][0]) as Material;
            kombiX[i][1] = Material.Instantiate(kombiX[0][1]) as Material;
            kombiX[i][0].color = barve[i];
            kombiX[i][1].color = barve[i];

            kombiXT[i][0] = Material.Instantiate(kombiXT[0][0]) as Material;
            kombiXT[i][1] = Material.Instantiate(kombiXT[0][1]) as Material;
            kombiXT[i][0].color = barveT[i];
            kombiXT[i][1].color = barveT[i];
            for (int j=2; j < kombiX[i].Length; j++)
            {
                kombiX[i][j] = kombiX[0][j];

                
                kombiXT[i][j] = kombiXT[0][j];
                Color zac = kombiXT[i][j].color;
                kombiXT[i][j].color = new Color(zac.r, zac.g, zac.b, 0.2f);
            }
        }

        pickX = new Material[5][];
        pickXT = new Material[5][];

        pickX[0] = new Material[7];
        pickX[0][0] = Material.Instantiate(material[0]) as Material;
        pickX[0][1] = Material.Instantiate(material[1]) as Material;
        pickX[0][2] = Material.Instantiate(material[2]) as Material;
        pickX[0][3] = Material.Instantiate(material[0]) as Material;
        pickX[0][4] = Material.Instantiate(material[3]) as Material;
        pickX[0][5] = Material.Instantiate(material[5]) as Material;
        pickX[0][6] = Material.Instantiate(material[4]) as Material;

        pickXT[0] = new Material[7];
        pickXT[0][0] = Material.Instantiate(materialA[0]) as Material;
        pickXT[0][1] = Material.Instantiate(materialA[1]) as Material;
        pickXT[0][2] = Material.Instantiate(materialA[2]) as Material;
        pickXT[0][3] = Material.Instantiate(materialA[0]) as Material;
        pickXT[0][4] = Material.Instantiate(materialA[3]) as Material;
        pickXT[0][5] = Material.Instantiate(materialA[5]) as Material;
        pickXT[0][6] = Material.Instantiate(materialA[4]) as Material;
        for (int i = 1; i < pickX.Length; i++)
        {
            pickX[i] = new Material[7];
            pickXT[i] = new Material[7];

            pickX[i][0] = Material.Instantiate(pickX[0][0]) as Material;
            pickX[i][3] = Material.Instantiate(pickX[0][3]) as Material;
            pickX[i][0].color = barve[i];
            pickX[i][3].color = barve[i];

            pickXT[i][0] = Material.Instantiate(pickXT[0][0]) as Material;
            pickXT[i][3] = Material.Instantiate(pickXT[0][3]) as Material;
            pickXT[i][0].color = barveT[i];
            pickXT[i][3].color = barveT[i];
            for (int j = 1; j < pickX[i].Length; j++)
            {
                if(j != 3)
                {
                    pickX[i][j] = pickX[0][j];


                    pickXT[i][j] = pickXT[0][j];
                    Color zac = pickXT[i][j].color;
                    pickXT[i][j].color = new Color(zac.r, zac.g, zac.b, 0.2f);
                }
                
            }
        }


        sportX = new Material[5][];
        sportXT = new Material[5][];

        sportX[0] = new Material[6];
        sportX[0][0] = Material.Instantiate(material[2]) as Material;
        sportX[0][1] = Material.Instantiate(material[0]) as Material;
        sportX[0][2] = Material.Instantiate(material[1]) as Material;
        sportX[0][3] = Material.Instantiate(material[5]) as Material;
        sportX[0][4] = Material.Instantiate(material[4]) as Material;
        sportX[0][5] = Material.Instantiate(material[3]) as Material;


        sportXT[0] = new Material[6];
        sportXT[0][0] = Material.Instantiate(materialA[2]) as Material;
        sportXT[0][1] = Material.Instantiate(materialA[0]) as Material;
        sportXT[0][2] = Material.Instantiate(materialA[1]) as Material;
        sportXT[0][3] = Material.Instantiate(materialA[5]) as Material;
        sportXT[0][4] = Material.Instantiate(materialA[4]) as Material;
        sportXT[0][5] = Material.Instantiate(materialA[3]) as Material;

        for (int i = 1; i < sportX.Length; i++)
        {
            sportX[i] = new Material[6];
            sportXT[i] = new Material[6];

            sportX[i][1] = Material.Instantiate(sportX[0][1]) as Material;
            sportX[i][1].color = barve[i];


            sportXT[i][1] = Material.Instantiate(sportXT[0][1]) as Material;
  
            sportXT[i][1].color = barveT[i];
            for (int j = 0; j < sportX[i].Length; j++)
            {
                if(j != 1)
                {
                    sportX[i][j] = sportX[0][j];


                    sportXT[i][j] = sportXT[0][j];
                    Color zac = sportXT[i][j].color;
                    sportXT[i][j].color = new Color(zac.r, zac.g, zac.b, 0.2f);
                }
                
            }
        }


        manX = new Material[5][];
        manXT = new Material[5][];

        manX[0] = new Material[8];
        manX[0][0] = Material.Instantiate(material[6]) as Material;
        manX[0][1] = Material.Instantiate(material[1]) as Material;
        manX[0][2] = Material.Instantiate(material[0]) as Material;
        manX[0][3] = Material.Instantiate(material[5]) as Material;
        manX[0][4] = Material.Instantiate(material[4]) as Material;
        manX[0][5] = Material.Instantiate(material[7]) as Material;
        manX[0][6] = Material.Instantiate(material[2]) as Material;
        manX[0][7] = Material.Instantiate(material[3]) as Material;


        manXT[0] = new Material[8];
        manXT[0][0] = Material.Instantiate(materialA[6]) as Material;
        manXT[0][1] = Material.Instantiate(materialA[1]) as Material;
        manXT[0][2] = Material.Instantiate(materialA[0]) as Material;
        manXT[0][3] = Material.Instantiate(materialA[5]) as Material;
        manXT[0][4] = Material.Instantiate(materialA[4]) as Material;
        manXT[0][5] = Material.Instantiate(materialA[7]) as Material;
        manXT[0][6] = Material.Instantiate(materialA[2]) as Material;
        manXT[0][7] = Material.Instantiate(materialA[3]) as Material;

        for (int i = 1; i < manX.Length; i++)
        {
            manX[i] = new Material[7];
            manXT[i] = new Material[7];

            manX[i][2] = Material.Instantiate(manX[0][2]) as Material;
            manX[i][2].color = barve[i];


            manXT[i][2] = Material.Instantiate(manXT[0][2]) as Material;
            manXT[i][2].color = barveT[i];

            for (int j = 0; j < manX[i].Length; j++)
            {
                if (j != 2)
                {
                    manX[i][j] = manX[0][j];

                    manXT[i][j] = manXT[0][j];
                    Color zac = manXT[i][j].color;
                    manXT[i][j].color = new Color(zac.r, zac.g, zac.b, 0.2f);
                }
                
            }
        }


    }

    static public int getStevilkaBarve()
    {
        return Random.Range(0, barve.Length);
    }
	
	static public Material[] getMaterial(int i, int id)
    {
        switch (id)
        {
            case 1: return avtoX[i];
            case 2: return kombiX[i];
            case 3: return pickX[i];
            case 4: return sportX[i];
            case 5: return manX[i];
        }
        return null;
    }

    static public Material[] getMaterialA(int i, int id)
    {
        switch (id)
        {
            case 1: return avtoXT[i];
            case 2: return kombiXT[i];
            case 3: return pickXT[i];
            case 4: return sportXT[i];
            case 5: return manXT[i];
        }
        return null;
    }
}
