﻿namespace System.Windows.Forms
{
    class ImageViewer : Panel
    {
        public ImageViewer() : base()
        {
            Image = new PictureBox();
            Image.Location = new Drawing.Point(0, 0);
            Image.Name = "pictureImg";
            Image.Size = new Drawing.Size(1, 1);
            Image.SizeMode = PictureBoxSizeMode.AutoSize;
            Image.TabIndex = 0;
            Image.TabStop = false;
            Image.Click += new EventHandler(HandleClick);
            Controls.Add(Image);
        }

        public PictureBox Image { get; private set; }

        private void HandleClick(object s, EventArgs e) => OnClick(e);
    }
}
