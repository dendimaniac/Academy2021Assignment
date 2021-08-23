using ColorSwitch.Core;
using UnityEngine;

namespace ColorSwitch
{
    public class TriangleObstacleController : ObstacleController
    {
        public override void Init(GameColor expectedGameColor)
        {
            base.Init(expectedGameColor);
            var randomObstacleSectionIndex = Random.Range(0, obstacleColorSectionList.Count);
            obstacleColorSectionList[randomObstacleSectionIndex].OverrideDefaultGameColor(expectedGameColor);
        }
    }
}