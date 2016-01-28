﻿using OpenTK.Graphics.OpenGL4;
using System;

namespace App
{
    class GLFragoutput : GLObject
    {
        #region PROPERTIES
        [Field] public int width { get; protected set; }
        [Field] public int height { get; protected set; }
        #endregion

        #region FIELDS
        private int numAttachments = 0;
        private DrawBuffersEnum[] attachmentPoints = new DrawBuffersEnum[]
        {
            DrawBuffersEnum.ColorAttachment0,
            DrawBuffersEnum.ColorAttachment1,
            DrawBuffersEnum.ColorAttachment2,
            DrawBuffersEnum.ColorAttachment3,
            DrawBuffersEnum.ColorAttachment4,
            DrawBuffersEnum.ColorAttachment5,
            DrawBuffersEnum.ColorAttachment6,
            DrawBuffersEnum.ColorAttachment7,
            DrawBuffersEnum.ColorAttachment8,
            DrawBuffersEnum.ColorAttachment9,
            DrawBuffersEnum.ColorAttachment10,
            DrawBuffersEnum.ColorAttachment11,
            DrawBuffersEnum.ColorAttachment12,
            DrawBuffersEnum.ColorAttachment13,
            DrawBuffersEnum.ColorAttachment14,
            DrawBuffersEnum.ColorAttachment15,
        };
        #endregion

        /// <summary>
        /// Create OpenGL framebuffer object for fragment output.
        /// </summary>
        /// <param name="params">Input parameters for GLObject creation.</param>
        public GLFragoutput(Compiler.Block block, Dict<GLObject> scene, bool debugging)
            : base(block.Name, block.Anno)
        {
            var err = new CompileException($"fragoutput '{name}'");

            // PARSE ARGUMENTS
            Cmds2Fields(this, block, err);

            // CREATE OPENGL OBJECT
            glname = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, glname);

            // PARSE COMMANDS
            foreach (var cmd in block)
                Attach(err + $"command '{cmd.Name}'", cmd, scene);

            // if any errors occurred throw exception
            if (err.HasErrors())
                throw err;

            // CHECK FOR OPENGL ERRORS
            Bind();
            var status = GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer);
            Unbind();

            // final error checks
            if (HasErrorOrGlError(err, block.File, block.Line, block.Position))
                throw err;
            if (status != FramebufferErrorCode.FramebufferComplete)
                throw err.Add("Could not be created due to an unknown error.",
                    block.File, block.Line, block.Position);
        }

        /// <summary>
        /// Create OpenGL framebuffer object for fragment output.
        /// </summary>
        /// <param name="params">Input parameters for GLObject creation.</param>
        public GLFragoutput(GLParams @params) : base(@params)
        {
            var err = new CompileException($"fragoutput '{@params.name}'");

            // PARSE TEXT
            var body = new Commands(@params.text, @params.file, @params.cmdLine, @params.cmdPos, err);

            // PARSE ARGUMENTS
            body.Cmds2Fields(this, err);

            // CREATE OPENGL OBJECT
            glname = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, glname);
            
            // PARSE COMMANDS
            foreach (var cmd in body)
                Attach(err + $"command {cmd.idx} '{cmd.cmd}'", cmd, @params.scene);

            // if any errors occurred throw exception
            if (err.HasErrors())
                throw err;

            // CHECK FOR OPENGL ERRORS
            Bind();
            var status = GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer);
            Unbind();

            // final error checks
            if (HasErrorOrGlError(err, @params.file, @params.nameLine, @params.namePos))
                throw err;
            if (status != FramebufferErrorCode.FramebufferComplete)
                throw err.Add("Could not be created due to an unknown error.",
                    @params.file, @params.nameLine, @params.namePos);
        }
        
        public void Bind()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, glname);
            // set draw buffers
            if(numAttachments > 0)
                GL.DrawBuffers(numAttachments, attachmentPoints);
            else
                GL.DrawBuffer(DrawBufferMode.None);
        }

        public void Unbind()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
            // set draw buffer
            GL.DrawBuffer(DrawBufferMode.BackLeft);
        }

        public override void Delete()
        {
            if (glname > 0)
            {
                GL.DeleteFramebuffer(glname);
                glname = 0;
            }
        }

        private void Attach(CompileException err, Compiler.Command cmd, Dict<GLObject> classes)
        {
            // get OpenGL image
            GLImage glimg = classes.GetValue<GLImage>(cmd[0].Text);
            if (glimg == null)
            {
                err.Add($"The name '{cmd[0].Text}' does not reference " +
                    "an object of type 'image'.", cmd.File, cmd.Line, cmd.Position);
                return;
            }

            // set width and height for GLPass to set the right viewport size
            if (width == 0 && height == 0)
            {
                width = glimg.width;
                height = glimg.height;
            }

            // get additional optional parameters
            int mipmap = cmd.ArgCount > 1 ? int.Parse(cmd[1].Text) : 0;
            int layer = cmd.ArgCount > 2 ? int.Parse(cmd[2].Text) : 0;

            // get attachment point
            FramebufferAttachment attachment;
            if (!Enum.TryParse(
                $"{cmd.Name}attachment{(cmd.Name.Equals("color") ? "" + numAttachments++ : "")}",
                true, out attachment))
            {
                err.Add($"Invalid attachment point '{cmd.Name}'.", cmd.File, cmd.Line, cmd.Position);
                return;
            }

            // attach texture to framebuffer
            switch (glimg.target)
            {
                case TextureTarget.Texture2DArray:
                case TextureTarget.Texture3D:
                    GL.FramebufferTexture3D(FramebufferTarget.Framebuffer,
                        attachment, glimg.target, glimg.glname, mipmap, layer);
                    break;
                case TextureTarget.Texture1DArray:
                case TextureTarget.Texture2D:
                    GL.FramebufferTexture2D(FramebufferTarget.Framebuffer,
                        attachment, glimg.target, glimg.glname, mipmap);
                    break;
                case TextureTarget.Texture1D:
                    GL.FramebufferTexture1D(FramebufferTarget.Framebuffer,
                        attachment, glimg.target, glimg.glname, mipmap);
                    break;
                default:
                    err.Add($"The texture type '{glimg.target}' of image '{cmd[0].Text}' " +
                        "is not supported.", cmd.File, cmd.Line, cmd.Position);
                    break;
            }
        }

        private void Attach(CompileException err, Commands.Cmd cmd, Dict<GLObject> classes)
        {
            // get OpenGL image
            GLImage glimg = classes.GetValue<GLImage>(cmd.args[0]);
            if (glimg == null)
            {
                err.Add($"The name '{cmd.args[0]}' does not reference " +
                    "an object of type 'image'.", cmd.file, cmd.line, cmd.pos);
                return;
            }

            // set width and height for GLPass to set the right viewport size
            if (width == 0 && height == 0)
            {
                width = glimg.width;
                height = glimg.height;
            }

            // get additional optional parameters
            int mipmap = cmd.args.Length > 1 ? int.Parse(cmd.args[1]) : 0;
            int layer = cmd.args.Length > 2 ? int.Parse(cmd.args[2]) : 0;

            // get attachment point
            FramebufferAttachment attachment;
            if (!Enum.TryParse(
                $"{cmd.cmd}attachment{(cmd.cmd.Equals("color") ? "" + numAttachments++ : "")}",
                true, out attachment))
            {
                err.Add($"Invalid attachment point '{cmd.cmd}'.", cmd.file, cmd.line, cmd.pos);
                return;
            }

            // attach texture to framebuffer
            switch (glimg.target)
            {
                case TextureTarget.Texture2DArray:
                case TextureTarget.Texture3D:
                    GL.FramebufferTexture3D(FramebufferTarget.Framebuffer,
                        attachment, glimg.target, glimg.glname, mipmap, layer);
                    break;
                case TextureTarget.Texture1DArray:
                case TextureTarget.Texture2D:
                    GL.FramebufferTexture2D(FramebufferTarget.Framebuffer,
                        attachment, glimg.target, glimg.glname, mipmap);
                    break;
                case TextureTarget.Texture1D:
                    GL.FramebufferTexture1D(FramebufferTarget.Framebuffer,
                        attachment, glimg.target, glimg.glname, mipmap);
                    break;
                default:
                    err.Add($"The texture type '{glimg.target}' of image '{cmd.args[0]}' " +
                        "is not supported.", cmd.file, cmd.line, cmd.pos);
                    break;
            }
        }
    }
}
