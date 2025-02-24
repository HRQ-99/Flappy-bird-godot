using Godot;

public partial class Shield : Area2D {

  [Signal] public delegate void ActivateShieldEventHandler();
  [Signal] public delegate void DeactivateShieldEventHandler();

  Shield() {
    // ActivateShield += ((Bird)GetNode<CharacterBody2D>("/root/Level/Bird")).ActivateShield;
    // DeactivateShield += ((Bird)GetNode<CharacterBody2D>("/root/Level/Bird")).ShieldExpired;
  }

  public override void _Ready() {
    ActivateShield += ((Bird)GetParent<CharacterBody2D>()).ActivateShield;
    DeactivateShield += ((Bird)GetParent<CharacterBody2D>()).ShieldExpired;
    EmitSignal(SignalName.ActivateShield);

    GetNode<Timer>("Timer").Start();
  }

  void PowerExpired() {
    Tween tween = CreateTween();
    tween.TweenProperty(this, "scale", new Vector2(0, 0), 0.5);
    tween.Finished += Expired;
  }

  void Expired() {
    EmitSignal(SignalName.DeactivateShield);
    QueueFree();
  }

  void HitPipe(Node2D bodyEntered) {
    if (bodyEntered.IsInGroup("Pipe")) {
      bodyEntered.QueueFree();
      EmitSignal(SignalName.DeactivateShield);
      QueueFree();
    }
  }
}
