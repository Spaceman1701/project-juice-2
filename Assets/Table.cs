using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public int tableIndex;

    // Start is called before the first frame update
    void Start()
    {
        if(tableIndex == null){
            Debug.LogError("Table doesn't have an index");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getTableIndex(){
        return tableIndex;
    }
}
