![Unity Minigames](./docs/banner.png)

# Unity Minigames

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![Unity](https://img.shields.io/badge/Unity-000000?style=flat&logo=unity&logoColor=white)

Two small 3D minigames built for a Unity workshop: a physics ball-roller with an AI enemy chasing
you, and a platform-and-portal runner with an optional collectible side quest.

## Play it

Playable builds are attached to the [latest release](../../releases/latest):

- **Windows** — download `Windows.zip`, extract, run `My project.exe`
- **Linux** — download `Ubuntu.zip`, extract, run `Ubuntu.x86_64`

Those builds contain the full Unity project — 7 scenes, both game modes. This
repository holds only the C# scripts pulled out of that project (no scenes,
prefabs or meshes), so there is nothing to open in the Unity editor here. See
[ARCHITECTURE.md](./ARCHITECTURE.md) for what the code does and how the two game
modes fit together.

## Architecture

![Unity Minigames architecture: BallRunner and Freeway/Terrain share one menu, pause and victory pipeline](./docs/architecture.png)

See [ARCHITECTURE.md](./ARCHITECTURE.md) for the full breakdown.

## License

PolyForm Noncommercial 1.0.0 ([LICENSE](./LICENSE)). Personal, non-commercial use only —
the code and the playable build alike.
