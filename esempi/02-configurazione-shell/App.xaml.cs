﻿namespace ConfigurazioneShell;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);
		window.Title = "Configurazione shell";
		return window;
    }
}
