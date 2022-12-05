// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""4eaed2e7-8448-463c-8cbf-017eabafe022"",
            ""actions"": [
                {
                    ""name"": ""TurningMovement"",
                    ""type"": ""Button"",
                    ""id"": ""df6dce6b-fa40-4bce-afa5-9ef7a88d76ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SidewaysMovement"",
                    ""type"": ""Button"",
                    ""id"": ""cb31d52b-b90c-4b3a-9bc6-3b9b6d98271f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4745882b-a38e-42cf-983d-dde7e28a5c54"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurningMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""95354df1-6777-43f5-ba32-afa5664aff67"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurningMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fab7e108-09c2-4556-a4ba-036a6e21cad1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurningMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4829bcc3-2b8f-4fd5-bc33-6741176316a6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SidewaysMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f539a289-a74d-42ef-b9e3-1ad58efca3dd"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SidewaysMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""07db607a-af45-4414-b094-60d9434fb993"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SidewaysMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c5b2de22-25e2-4d49-9deb-c9bafed7bd68"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SidewaysMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1d09c5f5-365c-4927-8ec8-0b036f284589"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SidewaysMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_TurningMovement = m_Player.FindAction("TurningMovement", throwIfNotFound: true);
        m_Player_SidewaysMovement = m_Player.FindAction("SidewaysMovement", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_TurningMovement;
    private readonly InputAction m_Player_SidewaysMovement;
    public struct PlayerActions
    {
        private @PlayerController m_Wrapper;
        public PlayerActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @TurningMovement => m_Wrapper.m_Player_TurningMovement;
        public InputAction @SidewaysMovement => m_Wrapper.m_Player_SidewaysMovement;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @TurningMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurningMovement;
                @TurningMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurningMovement;
                @TurningMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurningMovement;
                @SidewaysMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSidewaysMovement;
                @SidewaysMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSidewaysMovement;
                @SidewaysMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSidewaysMovement;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TurningMovement.started += instance.OnTurningMovement;
                @TurningMovement.performed += instance.OnTurningMovement;
                @TurningMovement.canceled += instance.OnTurningMovement;
                @SidewaysMovement.started += instance.OnSidewaysMovement;
                @SidewaysMovement.performed += instance.OnSidewaysMovement;
                @SidewaysMovement.canceled += instance.OnSidewaysMovement;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnTurningMovement(InputAction.CallbackContext context);
        void OnSidewaysMovement(InputAction.CallbackContext context);
    }
}
