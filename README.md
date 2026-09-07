![Unity Minigames](./docs/banner.png)

# Unity Minigames

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![Unity](https://img.shields.io/badge/Unity-000000?style=flat&logo=unity&logoColor=white)

Two small 3D minigames built for a Unity workshop: a physics ball-roller with an AI enemy chasing
you, and a platform-and-portal runner with an optional collectible side quest.

## Showcase

No screenshot here on purpose — this repo holds the C# scripts pulled out of the Unity project,
not the project itself (no scenes, prefabs or meshes included), so there's nothing to actually
open and run. See [ARCHITECTURE.md](./ARCHITECTURE.md) for what the code does and how the two
game modes fit together.

## Architecture

![Unity Minigames architecture: BallRunner and Freeway/Terrain share one menu, pause and victory pipeline](./docs/architecture.png)

See [ARCHITECTURE.md](./ARCHITECTURE.md) for the full breakdown.

## License

MIT — see [LICENSE](./LICENSE).
