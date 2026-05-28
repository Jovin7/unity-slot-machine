using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "PaylineDatabase",
    menuName = "Slot Machine/Payline Database")]
public class PaylineDatabase : ScriptableObject
{
    public List<Payline> paylines;
}
