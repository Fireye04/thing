using Godot;
using System;
using System.Collections;

public partial class DialogueBox : Node2D
{

	ArrayList ChoiceButtons = new ArrayList();
	 
	private string Prompt;
	private VBoxContainer Choices;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Prompt = GetNode<HBoxContainer>("HBoxContainer").GetNode<Label>("Prompt").Text;
		Choices = GetNode<HBoxContainer>("HBoxContainer").GetNode<VBoxContainer>("VBoxContainer");
		add_text("gay sex");
		add_choice("why0");
		add_choice("bc i said so1");
	}

	public void ClearDialogueBox() {
		Prompt = "";
		for (int i = 0; i < ChoiceButtons.Count; i++) {
			ChoiceButton item = (ChoiceButton) ChoiceButtons[i];
			Choices.RemoveChild(item);
		}
		
		ChoiceButtons.Clear();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void add_text(string text) {
		Prompt = text;
	}
	
	public void add_choice(string choice_text) {
		var CButtonScene = GD.Load<PackedScene>("res://Scenes/ChoiceButton.tscn");
		ChoiceButton CButton = (ChoiceButton) CButtonScene.Instantiate();
		CButton.SetChoiceIndex(ChoiceButtons.Count);
		ChoiceButtons.Add(CButton);
		CButton.Text = choice_text;
		CButton.ChoiceSelected += OnChoiceSelected;
		Choices.AddChild(CButton);

	}

	private void OnChoiceSelected(int choice_index) {
		GD.Print(choice_index);
	}
}
