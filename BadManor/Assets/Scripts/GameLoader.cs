using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameLoader : MonoBehaviour
    {
    public GameObject gM;

    private void Awake()
    {
        gM = gM == null ? Instantiate(gM) : gM;
    }
}
}
