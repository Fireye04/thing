using Godot;
using System;
using System.Collections;

public partial class DialogueBox : Node2D
{

	ArrayList ChoiceButtons = new ArrayList();
	
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		add_text("gay sex");
		add_choice("why0");
		add_choice("bc i said so 1");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void add_text(string text) {
		GetNode<HBoxContainer>("HBoxContainer").GetNode<Label>("Prompt").Text = text;
	}
	
	public void add_choice(string choice_text) {
		var CButtonScene = GD.Load<PackedScene>("res://Scenes/ChoiceButton.tscn");
		ChoiceButton CButton = (ChoiceButton) CButtonScene.Instantiate();
		CButton.SetChoiceIndex(ChoiceButtons.Count);
		ChoiceButtons.Add(CButton);
		CButton.Text = choice_text;
		CButton.ChoiceSelected += OnChoiceSelected;
		GetNode<HBoxContainer>("HBoxContainer").GetNode<VBoxContainer>("VBoxContainer").AddChild(CButton);

	}

	private void OnChoiceSelected(int choice_index) {
		GD.Print(choice_index);
	}
}
