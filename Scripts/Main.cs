using Godot;
using System;

public class Main : Control
{	
	public override void _Ready()
	{		
		SceneManager.Instance._main2D = GetNode<Node>("Main2D");
	}

    public void OnPlayBtnPressed()
    {	
        SceneManager.Instance.LoadLevel("Level_0");
    }
}
