using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int alph;
    public bool save;
    public bool go;
    public GameObject[] meshes;

    public GameObject currAlpha;
    // Start is called before the first frame update
    void Start()
    {
        save = false;
        alph = Random.Range(0, meshes.Length);

        currAlpha = Instantiate(meshes[alph], gameObject.transform, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (save)
        {
            spawning(); ;
        }

        if (go)
        {
            Destroy(currAlpha);
            save = true;
            go = false;
        }
    }

    private void spawning()
    {
        save = false;
        currAlpha = Instantiate(meshes[alph], gameObject.transform, true);
        alph = Random.Range(0, meshes.Length);
    }
}
