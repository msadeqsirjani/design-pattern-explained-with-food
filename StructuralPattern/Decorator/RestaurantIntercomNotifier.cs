﻿namespace StructuralPattern.Decorator;

public class RestaurantIntercomNotifier : Notifier
{
    public override Task HandleTableReadyMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(":: Restaurant Intercom - Your table is ready");
        Console.ResetColor();
        return Task.CompletedTask;
    }
}