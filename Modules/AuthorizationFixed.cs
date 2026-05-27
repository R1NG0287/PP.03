// <copyright file="AuthorizationFixed.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules;

public record LoginResult(bool isSuccess, string message);

public class AuthorizationFixed
{
    private readonly Dictionary<string, string> users = new ()
    {
        ["admin"] = "Admin123",
        ["user"] = "User12345",
    };

    public LoginResult Login(string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            return new LoginResult(false, "Логин и пароль обязательны.");
        }

        if (!this.users.TryGetValue(login, out var storedPassword))
        {
            return new LoginResult(false, "Пользователь не найден.");
        }

        if (storedPassword != password)
        {
            return new LoginResult(false, "Неверный пароль.");
        }

        return new LoginResult(true, "Вход выполнен.");
    }
}
