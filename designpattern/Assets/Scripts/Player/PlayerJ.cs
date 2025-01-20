using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    RequireComponent(typeof(Blackboard_Player))
]
public class PlayerJ : EntityJ
{
    protected override StaterType EnityStaterType => StaterType.Player;
}
