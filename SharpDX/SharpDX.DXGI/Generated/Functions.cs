// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

//------------------------------------------------------------------------------
// <auto-generated>
//     Types declaration for SharpDX.DXGI namespace.
//     This code was generated by a tool.
//     Date : 6/25/2016 10:38:14 PM
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;
using System.Security;
namespace SharpDX.DXGI {

#pragma warning disable 419
#pragma warning disable 1587
#pragma warning disable 1574

        /// <summary>	
        /// Functions	
        /// </summary>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='SharpDX.DXGI.DXGI']/*"/>	
    static  partial class DXGI {   
        
        /// <summary>Constant CreateFactoryDebug.</summary>
        /// <unmanaged>DXGI_CREATE_FACTORY_DEBUG</unmanaged>
        public const int CreateFactoryDebug = 1;
        
        /// <summary>	
        /// <p>Creates a DXGI 1.1 factory that you can use to generate other  DXGI objects.</p>	
        /// </summary>	
        /// <param name="riid"><dd>  <p>The globally unique identifier (<see cref="System.Guid"/>) of the <strong><see cref="SharpDX.DXGI.Factory1"/></strong> object referenced by  the <em>ppFactory</em> parameter.</p> </dd></param>	
        /// <param name="factoryOut"><dd>  <p>Address of a reference to an <strong><see cref="SharpDX.DXGI.Factory1"/></strong> object.</p> </dd></param>	
        /// <returns><p>Returns <see cref="SharpDX.Result.Ok"/> if successful; an error code otherwise. For a list of error codes, see DXGI_ERROR.</p></returns>	
        /// <remarks>	
        /// <p>Use a DXGI 1.1 factory to generate objects that <strong>enumerate adapters</strong>,  <strong>create swap chains</strong>, and <strong>associate a window</strong> with  the alt+enter key sequence for toggling to and from the full-screen display mode.  </p><p>If the <strong>CreateDXGIFactory1</strong> function succeeds, the reference count on the <strong><see cref="SharpDX.DXGI.Factory1"/></strong> interface is incremented. To avoid a memory leak, when you finish using the interface, call the <strong>IDXGIFactory1::Release</strong> method to release the interface.</p><p>This entry point is not supported by DXGI 1.0, which shipped in Windows?Vista and Windows Server?2008. DXGI 1.1 support is required, which is available on  Windows?7, Windows Server?2008?R2, and as an update to Windows?Vista with Service Pack?2 (SP2) (KB 971644) and Windows Server?2008 (KB 971512).</p><p><strong>Note</strong>??Do not mix the use of DXGI 1.0 (<strong><see cref="SharpDX.DXGI.Factory"/></strong>) and DXGI 1.1 (<strong><see cref="SharpDX.DXGI.Factory1"/></strong>) in an application. Use <strong><see cref="SharpDX.DXGI.Factory"/></strong> or <strong><see cref="SharpDX.DXGI.Factory1"/></strong>, but not both in an application.</p><p><strong>Note</strong>??<strong>CreateDXGIFactory1</strong> fails if your app's <strong>DllMain</strong> function calls it. For more info about how DXGI responds from <strong>DllMain</strong>, see DXGI Responses from DLLMain.</p><p><strong>Note</strong>??Starting with Windows?8, all DXGI factories (regardless if they were created with <strong>CreateDXGIFactory</strong> or <strong>CreateDXGIFactory1</strong>) enumerate adapters identically. The enumeration order of adapters, which you retrieve with <strong><see cref="SharpDX.DXGI.Factory.GetAdapter"/></strong> or <strong><see cref="SharpDX.DXGI.Factory1.GetAdapter1"/></strong>, is as follows: </p><ul> <li>Adapter with the output on which the desktop primary is displayed. This adapter corresponds with an index of zero.</li> <li>Adapters with outputs.</li> <li>Adapters without outputs.</li> </ul><p><strong>Windows?Phone?8:</strong> This API is supported.</p><p><strong>Windows Phone 8.1:</strong> This API is supported.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='CreateDXGIFactory1']/*"/>	
        /// <msdn-id>ff471318</msdn-id>	
        /// <unmanaged>HRESULT CreateDXGIFactory1([In] const GUID&amp; riid,[Out] void** ppFactory)</unmanaged>	
        /// <unmanaged-short>CreateDXGIFactory1</unmanaged-short>	
        public static void CreateDXGIFactory1(System.Guid riid, out System.IntPtr factoryOut) {
            unsafe {
                SharpDX.Result __result__;
                fixed (void* factoryOut_ = &factoryOut)
                    __result__= 
    				CreateDXGIFactory1_(&riid, factoryOut_);		
                __result__.CheckError();
            }
        }
        [DllImport("dxgi.dll", EntryPoint = "CreateDXGIFactory1", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern int CreateDXGIFactory1_(void* arg0,void* arg1);
        
        /// <summary>	
        /// <p>Creates a DXGI 1.3 factory that you can use to generate other  DXGI objects.</p><p>In Windows?8, any DXGI factory created while DXGIDebug.dll was present on the system would load and use it. Starting in Windows?8.1, apps explicitly request that DXGIDebug.dll be loaded instead. Use <strong>CreateDXGIFactory2</strong> and specify the <see cref="SharpDX.DXGI.DXGI.CreateFactoryDebug"/> flag to request DXGIDebug.dll; the DLL will be loaded if it is present on the system.</p>	
        /// </summary>	
        /// <param name="flags"><dd>  <p>Valid values include the <strong><see cref="SharpDX.DXGI.DXGI.CreateFactoryDebug"/> (0x01)</strong> flag, and zero.</p> <p><strong>Note</strong>??This flag will be set by the D3D runtime if:</p><ul> <li>The system creates an implicit factory during device creation.</li> <li>The <see cref="SharpDX.Direct3D11.DeviceCreationFlags.Debug"/> flag is specified during device creation, for example using <strong><see cref="SharpDX.Direct3D11.D3D11.CreateDevice"/></strong> (or the swapchain method, or the Direct3D 10 equivalents).</li> </ul> </dd></param>	
        /// <param name="riid"><dd>  <p>The globally unique identifier (<see cref="System.Guid"/>) of the <strong><see cref="SharpDX.DXGI.Factory2"/></strong> object referenced by  the <em>ppFactory</em> parameter.</p> </dd></param>	
        /// <param name="factoryOut"><dd>  <p>Address of a reference to an <strong><see cref="SharpDX.DXGI.Factory2"/></strong> object.</p> </dd></param>	
        /// <returns><p>Returns <see cref="SharpDX.Result.Ok"/> if successful; an error code otherwise. For a list of error codes, see DXGI_ERROR.</p></returns>	
        /// <remarks>	
        /// <p>This function accepts a flag indicating whether DXGIDebug.dll is loaded. The function otherwise behaves identically to <strong>CreateDXGIFactory1</strong>.</p><p><strong>Windows Phone 8.1:</strong> This API is supported.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='CreateDXGIFactory2']/*"/>	
        /// <msdn-id>dn268307</msdn-id>	
        /// <unmanaged>HRESULT CreateDXGIFactory2([In] unsigned int Flags,[In] const GUID&amp; riid,[Out] void** ppFactory)</unmanaged>	
        /// <unmanaged-short>CreateDXGIFactory2</unmanaged-short>	
        public static void CreateDXGIFactory2(int flags, System.Guid riid, out System.IntPtr factoryOut) {
            unsafe {
                SharpDX.Result __result__;
                fixed (void* factoryOut_ = &factoryOut)
                    __result__= 
    				CreateDXGIFactory2_(flags, &riid, factoryOut_);		
                __result__.CheckError();
            }
        }
        [DllImport("dxgi.dll", EntryPoint = "CreateDXGIFactory2", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern int CreateDXGIFactory2_(int arg0,void* arg1,void* arg2);
    }
        /// <summary>	
        /// Functions	
        /// </summary>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='SharpDX.DXGI.ResultCode']/*"/>	
    public  partial class ResultCode {   
        
        /// <summary>Constant CannotProtectContent.</summary>
        /// <unmanaged>DXGI_ERROR_CANNOT_PROTECT_CONTENT</unmanaged>
        public static readonly SharpDX.ResultDescriptor CannotProtectContent = new SharpDX.ResultDescriptor(-0x07785ffd6, "SharpDX.DXGI", "DXGI_ERROR_CANNOT_PROTECT_CONTENT", "CannotProtectContent");
        
        /// <summary>Constant AccessLost.</summary>
        /// <unmanaged>DXGI_ERROR_ACCESS_LOST</unmanaged>
        public static readonly SharpDX.ResultDescriptor AccessLost = new SharpDX.ResultDescriptor(-0x07785ffda, "SharpDX.DXGI", "DXGI_ERROR_ACCESS_LOST", "AccessLost");
        
        /// <summary>Constant WaitTimeout.</summary>
        /// <unmanaged>DXGI_ERROR_WAIT_TIMEOUT</unmanaged>
        public static readonly SharpDX.ResultDescriptor WaitTimeout = new SharpDX.ResultDescriptor(-0x07785ffd9, "SharpDX.DXGI", "DXGI_ERROR_WAIT_TIMEOUT", "WaitTimeout");
        
        /// <summary>Constant FrameStatisticsDisjoint.</summary>
        /// <unmanaged>DXGI_ERROR_FRAME_STATISTICS_DISJOINT</unmanaged>
        public static readonly SharpDX.ResultDescriptor FrameStatisticsDisjoint = new SharpDX.ResultDescriptor(-0x07785fff5, "SharpDX.DXGI", "DXGI_ERROR_FRAME_STATISTICS_DISJOINT", "FrameStatisticsDisjoint");
        
        /// <summary>Constant SessionDisconnected.</summary>
        /// <unmanaged>DXGI_ERROR_SESSION_DISCONNECTED</unmanaged>
        public static readonly SharpDX.ResultDescriptor SessionDisconnected = new SharpDX.ResultDescriptor(-0x07785ffd8, "SharpDX.DXGI", "DXGI_ERROR_SESSION_DISCONNECTED", "SessionDisconnected");
        
        /// <summary>Constant HwProtectionOufOfMemory.</summary>
        /// <unmanaged>DXGI_ERROR_HW_PROTECTION_OUTOFMEMORY</unmanaged>
        public static readonly SharpDX.ResultDescriptor HwProtectionOufOfMemory = new SharpDX.ResultDescriptor(-0x07785ffd0, "SharpDX.DXGI", "DXGI_ERROR_HW_PROTECTION_OUTOFMEMORY", "HwProtectionOufOfMemory");
        
        /// <summary>Constant NotCurrent.</summary>
        /// <unmanaged>DXGI_ERROR_NOT_CURRENT</unmanaged>
        public static readonly SharpDX.ResultDescriptor NotCurrent = new SharpDX.ResultDescriptor(-0x07785ffd2, "SharpDX.DXGI", "DXGI_ERROR_NOT_CURRENT", "NotCurrent");
        
        /// <summary>Constant RestrictToOutputStale.</summary>
        /// <unmanaged>DXGI_ERROR_RESTRICT_TO_OUTPUT_STALE</unmanaged>
        public static readonly SharpDX.ResultDescriptor RestrictToOutputStale = new SharpDX.ResultDescriptor(-0x07785ffd7, "SharpDX.DXGI", "DXGI_ERROR_RESTRICT_TO_OUTPUT_STALE", "RestrictToOutputStale");
        
        /// <summary>Constant DeviceReset.</summary>
        /// <unmanaged>DXGI_ERROR_DEVICE_RESET</unmanaged>
        public static readonly SharpDX.ResultDescriptor DeviceReset = new SharpDX.ResultDescriptor(-0x07785fff9, "SharpDX.DXGI", "DXGI_ERROR_DEVICE_RESET", "DeviceReset");
        
        /// <summary>Constant DriverInternalError.</summary>
        /// <unmanaged>DXGI_ERROR_DRIVER_INTERNAL_ERROR</unmanaged>
        public static readonly SharpDX.ResultDescriptor DriverInternalError = new SharpDX.ResultDescriptor(-0x07785ffe0, "SharpDX.DXGI", "DXGI_ERROR_DRIVER_INTERNAL_ERROR", "DriverInternalError");
        
        /// <summary>Constant InvalidCall.</summary>
        /// <unmanaged>DXGI_ERROR_INVALID_CALL</unmanaged>
        public static readonly SharpDX.ResultDescriptor InvalidCall = new SharpDX.ResultDescriptor(-0x07785ffff, "SharpDX.DXGI", "DXGI_ERROR_INVALID_CALL", "InvalidCall");
        
        /// <summary>Constant NotFound.</summary>
        /// <unmanaged>DXGI_ERROR_NOT_FOUND</unmanaged>
        public static readonly SharpDX.ResultDescriptor NotFound = new SharpDX.ResultDescriptor(-0x07785fffe, "SharpDX.DXGI", "DXGI_ERROR_NOT_FOUND", "NotFound");
        
        /// <summary>Constant WasStillDrawing.</summary>
        /// <unmanaged>DXGI_ERROR_WAS_STILL_DRAWING</unmanaged>
        public static readonly SharpDX.ResultDescriptor WasStillDrawing = new SharpDX.ResultDescriptor(-0x07785fff6, "SharpDX.DXGI", "DXGI_ERROR_WAS_STILL_DRAWING", "WasStillDrawing");
        
        /// <summary>Constant NameAlreadyExists.</summary>
        /// <unmanaged>DXGI_ERROR_NAME_ALREADY_EXISTS</unmanaged>
        public static readonly SharpDX.ResultDescriptor NameAlreadyExists = new SharpDX.ResultDescriptor(-0x07785ffd4, "SharpDX.DXGI", "DXGI_ERROR_NAME_ALREADY_EXISTS", "NameAlreadyExists");
        
        /// <summary>Constant Unsupported.</summary>
        /// <unmanaged>DXGI_ERROR_UNSUPPORTED</unmanaged>
        public static readonly SharpDX.ResultDescriptor Unsupported = new SharpDX.ResultDescriptor(-0x07785fffc, "SharpDX.DXGI", "DXGI_ERROR_UNSUPPORTED", "Unsupported");
        
        /// <summary>Constant RemoteClientDisconnected.</summary>
        /// <unmanaged>DXGI_ERROR_REMOTE_CLIENT_DISCONNECTED</unmanaged>
        public static readonly SharpDX.ResultDescriptor RemoteClientDisconnected = new SharpDX.ResultDescriptor(-0x07785ffdd, "SharpDX.DXGI", "DXGI_ERROR_REMOTE_CLIENT_DISCONNECTED", "RemoteClientDisconnected");
        
        /// <summary>Constant DeviceRemoved.</summary>
        /// <unmanaged>DXGI_ERROR_DEVICE_REMOVED</unmanaged>
        public static readonly SharpDX.ResultDescriptor DeviceRemoved = new SharpDX.ResultDescriptor(-0x07785fffb, "SharpDX.DXGI", "DXGI_ERROR_DEVICE_REMOVED", "DeviceRemoved");
        
        /// <summary>Constant DeviceHung.</summary>
        /// <unmanaged>DXGI_ERROR_DEVICE_HUNG</unmanaged>
        public static readonly SharpDX.ResultDescriptor DeviceHung = new SharpDX.ResultDescriptor(-0x07785fffa, "SharpDX.DXGI", "DXGI_ERROR_DEVICE_HUNG", "DeviceHung");
        
        /// <summary>Constant SdkComponentMissing.</summary>
        /// <unmanaged>DXGI_ERROR_SDK_COMPONENT_MISSING</unmanaged>
        public static readonly SharpDX.ResultDescriptor SdkComponentMissing = new SharpDX.ResultDescriptor(-0x07785ffd3, "SharpDX.DXGI", "DXGI_ERROR_SDK_COMPONENT_MISSING", "SdkComponentMissing");
        
        /// <summary>Constant AccessDenied.</summary>
        /// <unmanaged>DXGI_ERROR_ACCESS_DENIED</unmanaged>
        public static readonly SharpDX.ResultDescriptor AccessDenied = new SharpDX.ResultDescriptor(-0x07785ffd5, "SharpDX.DXGI", "DXGI_ERROR_ACCESS_DENIED", "AccessDenied");
        
        /// <summary>Constant RemoteOufOfMemory.</summary>
        /// <unmanaged>DXGI_ERROR_REMOTE_OUTOFMEMORY</unmanaged>
        public static readonly SharpDX.ResultDescriptor RemoteOufOfMemory = new SharpDX.ResultDescriptor(-0x07785ffdc, "SharpDX.DXGI", "DXGI_ERROR_REMOTE_OUTOFMEMORY", "RemoteOufOfMemory");
        
        /// <summary>Constant MoreData.</summary>
        /// <unmanaged>DXGI_ERROR_MORE_DATA</unmanaged>
        public static readonly SharpDX.ResultDescriptor MoreData = new SharpDX.ResultDescriptor(-0x07785fffd, "SharpDX.DXGI", "DXGI_ERROR_MORE_DATA", "MoreData");
        
        /// <summary>Constant ModeChangeInProgress.</summary>
        /// <unmanaged>DXGI_ERROR_MODE_CHANGE_IN_PROGRESS</unmanaged>
        public static readonly SharpDX.ResultDescriptor ModeChangeInProgress = new SharpDX.ResultDescriptor(-0x07785ffdb, "SharpDX.DXGI", "DXGI_ERROR_MODE_CHANGE_IN_PROGRESS", "ModeChangeInProgress");
        
        /// <summary>Constant Nonexclusive.</summary>
        /// <unmanaged>DXGI_ERROR_NONEXCLUSIVE</unmanaged>
        public static readonly SharpDX.ResultDescriptor Nonexclusive = new SharpDX.ResultDescriptor(-0x07785ffdf, "SharpDX.DXGI", "DXGI_ERROR_NONEXCLUSIVE", "Nonexclusive");
        
        /// <summary>Constant GraphicsVidpnSourceInUse.</summary>
        /// <unmanaged>DXGI_ERROR_GRAPHICS_VIDPN_SOURCE_IN_USE</unmanaged>
        public static readonly SharpDX.ResultDescriptor GraphicsVidpnSourceInUse = new SharpDX.ResultDescriptor(-0x07785fff4, "SharpDX.DXGI", "DXGI_ERROR_GRAPHICS_VIDPN_SOURCE_IN_USE", "GraphicsVidpnSourceInUse");
        
        /// <summary>Constant NotCurrentlyAvailable.</summary>
        /// <unmanaged>DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</unmanaged>
        public static readonly SharpDX.ResultDescriptor NotCurrentlyAvailable = new SharpDX.ResultDescriptor(-0x07785ffde, "SharpDX.DXGI", "DXGI_ERROR_NOT_CURRENTLY_AVAILABLE", "NotCurrentlyAvailable");
    }
}
