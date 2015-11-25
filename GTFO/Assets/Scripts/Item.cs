using UnityEngine;
using System.Collections;

// Interface, containing only signature (design), not implementation
interface IItem
{
    // classes that implement Item should define this method
    void UseItem();
}
