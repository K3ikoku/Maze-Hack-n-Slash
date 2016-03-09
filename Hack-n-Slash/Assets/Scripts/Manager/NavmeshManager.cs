using UnityEngine;
using System.Collections;

namespace Pathfinding
{


    public class NavmeshManager : MonoBehaviour
    {
        void Awake()
        {
            AstarPath.active.Scan();
        }
    }
}
