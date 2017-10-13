﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Properties {
    using System;
    
    
    /// <summary>
    ///   Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("App.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        ///   Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Close {
            get {
                object obj = ResourceManager.GetObject("Close", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die System.dll
        ///System.Core.dll
        ///System.Runtime.dll
        ///System.Drawing.dll
        ///System.Windows.Forms.dll
        ///OpenTK.dll ähnelt.
        /// </summary>
        internal static string CSHARP_REFERENCES {
            get {
                return ResourceManager.GetString("CSHARP_REFERENCES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die #define _DBG_BOOL 1
        ///#define _DBG_INT 2
        ///#define _DBG_UINT 3
        ///#define _DBG_FLOAT 4
        ///#define _i2f intBitsToFloat
        ///#define _u2f uintBitsToFloat
        ///
        ///layout(rgba32f) uniform writeonly imageBuffer _dbgOut;
        ///
        ///int _dbgStore(int idx, vec4 val) {
        ///	imageStore(_dbgOut, idx, val);
        ///	return ++idx;
        ///}
        ///int _dbgStore(int idx, ivec4 val) {
        ///	return _dbgStore(idx, vec4(_i2f(val.x), _i2f(val.y), _i2f(val.z), _i2f(val.w)));
        ///}
        ///int _dbgStore(int idx, uvec4 val) {
        ///	return _dbgStore(idx, vec4(_u2f(val.x), _u2f(val.y), _u2f(va [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        /// </summary>
        internal static string dbg {
            get {
                return ResourceManager.GetString("dbg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die &gt;&gt; ähnelt.
        /// </summary>
        internal static string DBG_CLOSE {
            get {
                return ResourceManager.GetString("DBG_CLOSE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die all(equal(_dbgVert, ivec2(gl_InstanceID, gl_VertexID)))
        ///all(equal(_dbgTess, ivec2(gl_InvocationID, gl_PrimitiveID)))
        ///_dbgEval == gl_PrimitiveID
        ///all(equal(_dbgGeom, ivec2(gl_PrimitiveIDIn, gl_InvocationID)))
        ///all(equal(_dbgFrag, ivec4(int(gl_FragCoord.x), int(gl_FragCoord.y), gl_Layer, gl_ViewportIndex)))
        ///all(equal(_dbgComp, gl_GlobalInvocationID)) ähnelt.
        /// </summary>
        internal static string DBG_CONDITIONS {
            get {
                return ResourceManager.GetString("DBG_CONDITIONS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die &lt;&lt; ähnelt.
        /// </summary>
        internal static string DBG_OPEN {
            get {
                return ResourceManager.GetString("DBG_OPEN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die ivec2 _dbgVert
        ///ivec2 _dbgTess
        ///int _dbgEval
        ///ivec2 _dbgGeom
        ///ivec4 _dbgFrag
        ///uvec3 _dbgComp ähnelt.
        /// </summary>
        internal static string DBG_UNIFORMS {
            get {
                return ResourceManager.GetString("DBG_UNIFORMS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die 
        ///uniform ivec2 _dbgFragment;
        ///uniform int _dbgLayer;
        ///uniform int _dbgViewport;
        ///	
        ///void main ()
        ///{
        ///	if (gl_FragCoord.x != _dbgFragment.x
        ///	|| gl_FragCoord.y != _dbgFragment.y)
        ///	{
        ///		&lt;&lt;store_input_varyings&gt;&gt;
        ///	}
        ///
        ///	&lt;&lt;shader_code&gt;&gt;
        ///}
        /// ähnelt.
        /// </summary>
        internal static string dbgBody {
            get {
                return ResourceManager.GetString("dbgBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgAnimate {
            get {
                object obj = ResourceManager.GetObject("ImgAnimate", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgComment {
            get {
                object obj = ResourceManager.GetObject("ImgComment", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgDbg {
            get {
                object obj = ResourceManager.GetObject("ImgDbg", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgDbgStepBack {
            get {
                object obj = ResourceManager.GetObject("ImgDbgStepBack", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgDbgStepBreakpoint {
            get {
                object obj = ResourceManager.GetObject("ImgDbgStepBreakpoint", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgDbgStepInto {
            get {
                object obj = ResourceManager.GetObject("ImgDbgStepInto", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgDbgStepOver {
            get {
                object obj = ResourceManager.GetObject("ImgDbgStepOver", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgNew {
            get {
                object obj = ResourceManager.GetObject("ImgNew", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgOpen {
            get {
                object obj = ResourceManager.GetObject("ImgOpen", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgPause {
            get {
                object obj = ResourceManager.GetObject("ImgPause", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgPick {
            get {
                object obj = ResourceManager.GetObject("ImgPick", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgRun {
            get {
                object obj = ResourceManager.GetObject("ImgRun", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgSave {
            get {
                object obj = ResourceManager.GetObject("ImgSave", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgSaveAll {
            get {
                object obj = ResourceManager.GetObject("ImgSaveAll", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgSaveAs {
            get {
                object obj = ResourceManager.GetObject("ImgSaveAs", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ImgUncomment {
            get {
                object obj = ResourceManager.GetObject("ImgUncomment", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die &lt;?xml version=&apos;1.0&apos;?&gt;
        ///&lt;FxLexer&gt;
        ///  &lt;!-- Light Theme --&gt;
        ///  &lt;Style theme=&apos;DarkTheme&apos; name=&apos;string&apos; fore=&apos;#D69D85&apos;/&gt;
        ///  &lt;Style theme=&apos;DarkTheme&apos; name=&apos;operator&apos; fore=&apos;#A0A0A0&apos;/&gt;
        ///  &lt;Style theme=&apos;DarkTheme&apos; name=&apos;braces&apos; fore=&apos;#606060&apos;/&gt;
        ///  &lt;Style theme=&apos;DarkTheme&apos; name=&apos;punctuation&apos; fore=&apos;#A0A0A0&apos;/&gt;
        ///  &lt;Style theme=&apos;DarkTheme&apos; name=&apos;number&apos; fore=&apos;#B5CEA8&apos;/&gt;
        ///  &lt;Style theme=&apos;DarkTheme&apos; name=&apos;LineComment&apos; fore=&apos;#608B4E&apos;/&gt;
        ///  &lt;Style theme=&apos;DarkTheme&apos; name=&apos;BlockComment&apos; fore=&apos;#82A847&apos;/&gt;
        ///  &lt;Style theme=&apos;DarkThe [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        /// </summary>
        internal static string keywordsXML {
            get {
                return ResourceManager.GetString("keywordsXML", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap logo {
            get {
                object obj = ResourceManager.GetObject("logo", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Maximize {
            get {
                object obj = ResourceManager.GetObject("Maximize", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Minimize {
            get {
                object obj = ResourceManager.GetObject("Minimize", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Normalize {
            get {
                object obj = ResourceManager.GetObject("Normalize", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Settings.xml ähnelt.
        /// </summary>
        internal static string WINDOW_SETTINGS_FILE {
            get {
                return ResourceManager.GetString("WINDOW_SETTINGS_FILE", resourceCulture);
            }
        }
    }
}
