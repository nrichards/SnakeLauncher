//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Map"",
            ""id"": ""895ae27b-57db-4fe5-b029-0e915e30521d"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""2fbdbfef-9e84-4561-8820-4a944f3b246f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Do Action"",
                    ""type"": ""Button"",
                    ""id"": ""84b1b4f7-0c45-49ba-88f0-464788a1680f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Tilt"",
                    ""type"": ""Button"",
                    ""id"": ""89046342-f852-4d60-90b9-39711d874e95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b2eaf626-b7d9-40d2-97b8-962fec1f869f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Do Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c04038c7-290e-4177-a68b-0183e81acdd6"",
                    ""path"": ""<Gamepad>/rightTriggerButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""DualSense"",
                    ""action"": ""Do Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fe24e7d-9017-4c07-81ef-0473a2e05893"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Do Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ace1c110-bc7b-46d3-9bf3-04749cb89989"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": ""DualSense"",
                    ""action"": ""Tilt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""7be77cb8-9cc7-4afd-a4e2-d5c127b7e5e4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tilt"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a21f7bd-3022-4e27-be65-c102272bc080"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""DualSense"",
            ""bindingGroup"": ""DualSense"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualSenseGamepadHID>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<VirtualMouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Map
        m_Map = asset.FindActionMap("Map", throwIfNotFound: true);
        m_Map_Click = m_Map.FindAction("Click", throwIfNotFound: true);
        m_Map_DoAction = m_Map.FindAction("Do Action", throwIfNotFound: true);
        m_Map_Tilt = m_Map.FindAction("Tilt", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Map
    private readonly InputActionMap m_Map;
    private List<IMapActions> m_MapActionsCallbackInterfaces = new List<IMapActions>();
    private readonly InputAction m_Map_Click;
    private readonly InputAction m_Map_DoAction;
    private readonly InputAction m_Map_Tilt;
    public struct MapActions
    {
        private @Controls m_Wrapper;
        public MapActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Map_Click;
        public InputAction @DoAction => m_Wrapper.m_Map_DoAction;
        public InputAction @Tilt => m_Wrapper.m_Map_Tilt;
        public InputActionMap Get() { return m_Wrapper.m_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapActions set) { return set.Get(); }
        public void AddCallbacks(IMapActions instance)
        {
            if (instance == null || m_Wrapper.m_MapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MapActionsCallbackInterfaces.Add(instance);
            @Click.started += instance.OnClick;
            @Click.performed += instance.OnClick;
            @Click.canceled += instance.OnClick;
            @DoAction.started += instance.OnDoAction;
            @DoAction.performed += instance.OnDoAction;
            @DoAction.canceled += instance.OnDoAction;
            @Tilt.started += instance.OnTilt;
            @Tilt.performed += instance.OnTilt;
            @Tilt.canceled += instance.OnTilt;
        }

        private void UnregisterCallbacks(IMapActions instance)
        {
            @Click.started -= instance.OnClick;
            @Click.performed -= instance.OnClick;
            @Click.canceled -= instance.OnClick;
            @DoAction.started -= instance.OnDoAction;
            @DoAction.performed -= instance.OnDoAction;
            @DoAction.canceled -= instance.OnDoAction;
            @Tilt.started -= instance.OnTilt;
            @Tilt.performed -= instance.OnTilt;
            @Tilt.canceled -= instance.OnTilt;
        }

        public void RemoveCallbacks(IMapActions instance)
        {
            if (m_Wrapper.m_MapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMapActions instance)
        {
            foreach (var item in m_Wrapper.m_MapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MapActions @Map => new MapActions(this);
    private int m_DualSenseSchemeIndex = -1;
    public InputControlScheme DualSenseScheme
    {
        get
        {
            if (m_DualSenseSchemeIndex == -1) m_DualSenseSchemeIndex = asset.FindControlSchemeIndex("DualSense");
            return asset.controlSchemes[m_DualSenseSchemeIndex];
        }
    }
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IMapActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnDoAction(InputAction.CallbackContext context);
        void OnTilt(InputAction.CallbackContext context);
    }
}
