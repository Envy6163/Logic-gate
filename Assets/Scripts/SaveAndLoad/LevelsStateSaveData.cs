using Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class LevelsStateSaveData 
{
    private AutoExpandList<bool> states=new();
    public bool this[int index]
    {
        get
        {
            return states[index];
        }
        set
        {
            states[index] = value;
        }
    }
}

