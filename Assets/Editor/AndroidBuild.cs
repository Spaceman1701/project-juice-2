using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AndroidBuild : MonoBehaviour
{

    [MenuItem("AutoBuilder/Quest")]
    static void PerformBuild()
    {
        string[] scenes = { "Assets/Scenes/MainScene.unity" };

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = scenes;
        buildPlayerOptions.locationPathName = "./thebuild";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.AutoRunPlayer;


        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
