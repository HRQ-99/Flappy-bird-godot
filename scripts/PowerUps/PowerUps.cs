using Godot;
using System.Collections.Generic;

public interface IPowerUps {

  enum PowerUpsList {
    SpeedBoost, ScoreBoost, PipeDestroyer, Shield, PowerUpSpawnBoost
  }

  static readonly List<PowerUpsList> PowerUpsEnumList = [.. System.Enum.GetValues<PowerUpsList>()];

  const string SceneDirectoryPath = "scenes/PowerUps/";

  static readonly Dictionary<PowerUpsList, PackedScene> PowerUpScenes = new(){
    {PowerUpsList.SpeedBoost, ResourceLoader.Load<PackedScene>(SceneDirectoryPath + "SpeedBoostPowerUp.tscn")},
    {PowerUpsList.ScoreBoost, ResourceLoader.Load<PackedScene>(SceneDirectoryPath + "ScoreBoostPowerUp.tscn")},
    {PowerUpsList.PipeDestroyer, ResourceLoader.Load<PackedScene>(SceneDirectoryPath + "PipeDestroyerPowerUp.tscn")},
    {PowerUpsList.Shield, ResourceLoader.Load<PackedScene>(SceneDirectoryPath + "ShieldPowerUp.tscn")},
    {PowerUpsList.PowerUpSpawnBoost, ResourceLoader.Load<PackedScene>(SceneDirectoryPath + "PowerUpSpawnBoost.tscn")},
  };

  protected abstract void PowerActivate(Node2D bodyEntered);
  protected abstract void MusicFadeOut(Node2D bodyEntered);
  protected abstract void MusicFadeIn();
  protected abstract void PowerExpired();
}