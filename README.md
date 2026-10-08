# Tic-Tac-Toe

A simple console-based **Tic-Tac-Toe game written in C#**.

This project was created as a **laboratory work** and focuses on implementing the game logic, separating the main components, and testing their behavior.

## Features

- 🎮 Console-based two-player gameplay
- 📐 Customizable board size from **3×3 to 50×50**
- ❌ Cross and ⭕ Circle player symbols
- 🔍 Winner detection for:
  - rows
  - columns
  - main diagonal
  - secondary diagonal
- 🚫 Invalid moves and input are handled by the game
- 🧪 Automated unit and integration-style tests
- 📊 Code coverage report included in the repository

The game checks for a winner after every move, so there is no need to wait until the board is full.

## Project Structure

```text
mrzetyt-tic-tac-toe/
├── README.md
│
├── Lab1PPOIS/
│   ├── Field.cs
│   ├── Game.cs
│   ├── IField.cs
│   ├── IPlayer.cs
│   ├── Player.cs
│   ├── Lab1PPOIS.csproj
│   └── Lab1PPOIS.sln
│
└── Lab1PPOIS.Tests/
    ├── FieldTests.cs
    ├── GameTests.cs
    ├── PlayerTests.cs
    ├── GlobalUsings.cs
    ├── Lab1PPOIS.Tests.csproj
    └── coverage.cobertura.xml
```

### `Lab1PPOIS`

The main application.

- **`Game.cs`** — console interface, game flow, player turns and input handling.
- **`Field.cs`** — board representation, cell operations and winner detection.
- **`Player.cs`** — player symbol and move logic.
- **`IField.cs`** — field interface.
- **`IPlayer.cs`** — player interface.
- **`Lab1PPOIS.csproj`** — .NET project configuration.

### `Lab1PPOIS.Tests`

The testing project.

It contains tests for the field, player and game behavior, including valid and invalid game scenarios. The project uses **NUnit** together with the .NET test infrastructure. 

The repository also contains a **Cobertura coverage report**. The recorded report shows **100% line coverage and 100% branch coverage** for the main `Lab1PPOIS` package.

## How to Run

### Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git

### Clone the repository

```bash
git clone https://github.com/mrzetyt/tic-tac-toe.git
cd tic-tac-toe
```

### Run the game

From the `Lab1PPOIS` directory:

```bash
cd Lab1PPOIS
dotnet run
```

The application opens the main menu:

```text
Main Menu
1. Start game
2. Exit
```

Choose the board size, select the first player's symbol, and start playing.

Player moves are entered as coordinates:

```text
row column
```

For example:

```text
0 0
1 1
2 2
```

Coordinates start from `0`.

## Running Tests

From the repository root:

```bash
dotnet test
```

The test project covers the main game components:

- `Field`
- `Player`
- `Game`

The tests include winner detection, board operations, player moves, menu behavior, invalid input and draw scenarios. 

## Technology Stack

- **C#**
- **.NET 8**
- **NUnit**
- **Coverlet**
- **Cobertura**

The main application is configured as a .NET 8 executable, while the test project targets .NET 8 and uses NUnit and Coverlet for testing and coverage collection. 

## About

This repository is primarily an educational project and a practical exercise in developing a small C# application with separate application and testing projects.

Despite its simple gameplay, the project demonstrates several useful software development practices: separating responsibilities into classes, using interfaces, validating user input, writing automated tests, and measuring code coverage.
