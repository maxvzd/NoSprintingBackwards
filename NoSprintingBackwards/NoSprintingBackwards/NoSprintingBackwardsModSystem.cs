using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace NoSprintingBackwards;

public class NoSprintingBackwardsModSystem : ModSystem
{
    private ICoreClientAPI? _coreApi;

    public override void StartClientSide(ICoreClientAPI api)
    {
        _coreApi = api;
        api.Event.RegisterGameTickListener(OnClientTick, 0);
    }

    private void OnClientTick(float dt)
    {
        var player = _coreApi?.World.Player;

        var controls = player?.Entity.Controls;

        if (controls is not null && !controls.Forward)
        {
            controls.Sprint = false;
        }
    }
}