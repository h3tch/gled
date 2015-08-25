﻿using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace gled
{
    class GLPass : GLObject
    {
        public string vert = null;
        public string tess = null;
        public string eval = null;
        public string geom = null;
        public string frag = null;
        public string geomout = null;
        public string fragout = null;
        public string[] option = null;
        public GLObject glvert = null;
        public GLObject gltess = null;
        public GLObject gleval = null;
        public GLObject glgeom = null;
        public GLObject glfrag = null;
        public GLObject glgeomout = null;
        public GLObject glfragout = null;
        public GLCamera glcamera = null;
        public List<MultiDrawCall> calls = new List<MultiDrawCall>();
        public int g_view = -1;
        public int g_proj = -1;
        public int g_viewproj = -1;
        public int g_info = -1;

        public class MultiDrawCall
        {
            public int vi;
            public int ib;
            public List<DrawCall> cmd;
        }

        public struct DrawCall
        {
            public PrimitiveType mode;
            public int indexcount;
            public DrawElementsType indextype;
            public IntPtr baseindex;
            public int instancecount;
            public int basevertex;
            public int baseinstance;
        }

        public GLPass(string name, string annotation, string text, Dictionary<string, GLObject> classes)
            : base(name, annotation)
        {
            // PARSE TEXT
            var args = Text2Args(text);

            // PARSE ARGUMENTS
            Args2Prop(this, args);

            // parse draw call arguments
            List<int> arg = new List<int>();
            foreach (var call in args)
            {
                // skip if arg is not a draw command
                if (!call[0].Equals("draw") || call.Length < 5)
                    continue;

                // parse draw call arguments
                arg.Clear();
                GLVertinput vi = null;
                GLBuffer ib = null;
                GLObject obj;
                PrimitiveType mode = 0;
                DrawElementsType type = 0;
                int val;

                for (var i = 1; i < call.Length; i++)
                {
                    if (vi == null && classes.TryGetValue(call[i], out obj) && obj.GetType() == typeof(GLVertinput))
                        vi = (GLVertinput)obj;
                    else if (ib == null && classes.TryGetValue(call[i], out obj) && obj.GetType() == typeof(GLBuffer))
                        ib = (GLBuffer)obj;
                    else if (type == 0 && Enum.TryParse(call[i], true, out type)) { }
                    else if (mode == 0 && Enum.TryParse(call[i], true, out mode)) { }
                    else if (Int32.TryParse(call[i], out val))
                        arg.Add(val);
                }

                // check for validity of the draw call
                if (vi == null)
                    throw new Exception("");
                if (mode == 0)
                    throw new Exception("");
                if (ib != null && type == 0)
                    throw new Exception("");
                if (arg.Count == 0)
                    throw new Exception("");

                // get index buffer object (if present) and find existing MultiDraw class
                MultiDrawCall multidrawcall = calls.Find(x => x.vi == vi.glname && x.ib == (ib != null ? ib.glname : 0));
                if (multidrawcall == null)
                {
                    multidrawcall = new MultiDrawCall();
                    multidrawcall.cmd = new List<DrawCall>();
                    multidrawcall.vi = vi.glname;
                    multidrawcall.ib = ib != null ? ib.glname : 0;
                    calls.Add(multidrawcall);
                }

                // add new draw command to the MultiDraw class
                DrawCall drawcall = new DrawCall();
                drawcall.mode          = mode;
                drawcall.indextype     = type;
                drawcall.indexcount    = arg.Count >= 1 ? arg[0] : 0;
                drawcall.instancecount = arg.Count >= 2 ? arg[1] : 1;
                drawcall.baseindex     = (IntPtr)(arg.Count >= 3 ? arg[2] : 0);
                drawcall.baseinstance  = arg.Count >= 4 ? arg[3] : 0;
                drawcall.basevertex    = arg.Count >= 5 ? arg[4] : 0;
                multidrawcall.cmd.Add(drawcall);
            }

            // GET CAMERA OBJECT
            GLObject cam;
            classes.TryGetValue(GLCamera.cameraname, out cam);
            if (cam.GetType() == typeof(GLCamera))
                glcamera = (GLCamera)cam;

            // CREATE OPENGL OBJECT
            glname = GL.CreateProgram();

            // attach shader objects
            glvert = attach(vert, classes);
            gltess = attach(tess, classes);
            gleval = attach(eval, classes);
            glgeom = attach(geom, classes);
            glfrag = attach(frag, classes);

            // link program
            GL.LinkProgram(glname);

            // detach shader objects
            if (glvert != null)
                GL.DetachShader(glname, glvert.glname);
            if (gltess != null)
                GL.DetachShader(glname, gltess.glname);
            if (gleval != null)
                GL.DetachShader(glname, gleval.glname);
            if (glgeom != null)
                GL.DetachShader(glname, glgeom.glname);
            if (glfrag != null)
                GL.DetachShader(glname, glfrag.glname);

            // check for link errors
            int status;
            GL.GetProgram(glname, GetProgramParameterName.LinkStatus, out status);
            if (status != 1)
                throw new Exception("ERROR in pass " + name + ":\n" + GL.GetProgramInfoLog(glname));
            
            // GET PROGRAM UNIFORMS
            g_view = GL.GetUniformLocation(glname, "g_view");
            g_proj = GL.GetUniformLocation(glname, "g_proj");
            g_viewproj = GL.GetUniformLocation(glname, "g_viewproj");
            g_info = GL.GetUniformLocation(glname, "g_info");
            
        }

        private GLObject attach(string sh, Dictionary<string, GLObject> classes)
        {
            if (sh == null)
                return null;
            GLObject glsh;
            if (classes.TryGetValue(sh, out glsh) && glsh.GetType() == typeof(GLShader))
                GL.AttachShader(glname, glsh.glname);
            else
                throw new Exception("ERROR in pass " + name + ": Invalid name '" + sh + "'.");
            return glsh;
        }
        
        public void Exec(int width, int height)
        {
            GL.ClearColor(Color.SkyBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Viewport(0, 0, width, height);

            GL.UseProgram(glname);

            if (g_view >= 0)
                GL.UniformMatrix4(g_view, false, ref glcamera.view);
            if (g_proj >= 0)
                GL.UniformMatrix4(g_proj, false, ref glcamera.proj);
            if (g_viewproj >= 0)
                GL.UniformMatrix4(g_proj, false, ref glcamera.viewproj);
            if (g_info >= 0)
                GL.Uniform4(g_proj, ref glcamera.info);

            foreach (var call in calls)
            {
                // bind vertex buffer to input stream
                // (needs to be done before binding an ElementArrayBuffer)
                GL.BindVertexArray(call.vi);
                // bin index buffer to ElementArrayBuffer target
                if (call.ib != 0)
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, call.ib);
                // execute multiple indirect draw commands
                foreach (var draw in call.cmd)
                    GL.DrawElementsInstancedBaseVertexBaseInstance(draw.mode, draw.indexcount, draw.indextype, draw.baseindex, draw.instancecount, draw.basevertex, draw.baseinstance);
                    //GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 8);
            }

            GL.UseProgram(0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public override void Delete()
        {
            if (glname > 0)
            {
                GL.DeleteProgram(glname);
                glname = 0;
            }
        }
    }
}
