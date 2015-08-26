using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.UI;
using System.Web.Hosting; 

namespace Infrastructure.Utility
{
    public enum WatermarkPosition
    {
        WM_TOP_LEFT,
        WM_TOP_RIGHT,
        WM_BOTTOM_RIGHT,
        WM_BOTTOM_LEFT
    }
    public class HandleImage
    {
        private string _oldPath;
        private string _newPath;
        private int _wmtType;
        private string _waterMarkContent;
        private Color _graphicsColor;
        private Font _fontStyle;
        private WatermarkPosition _watermarkPosition;
        private float _waterHeight;
        private float _waterWidth;
        private string _newImageName;

        /// <summary>
        /// 原图片路径
        /// </summary>
        public string oldPath
        {
            get { return _oldPath; }
            set {
                _oldPath = value;
                if (string.IsNullOrEmpty(_oldPath))
                {
                    _oldPath = "/Images/quan.jpg";
                }
            }
        }
        /// <summary>
        /// 新图片路径
        /// </summary>
        public string newPath
        {
            get { return _newPath; }
            set
            {
                _newPath = value;
                if (string.IsNullOrEmpty(_newPath))
                {
                    _newPath = "/Images";
                }
                if (Directory.Exists(_newPath))
                {
                    Directory.CreateDirectory(_newPath);
                }
            }
        }
        /// <summary>
        /// 水印类型，1为文字水印，2为图片水印
        /// </summary>
        public int wmtType
        {
            get { return _wmtType; }
            set { _wmtType = value; }
        }
        /// <summary>
        /// 水印内容，如果是文字水印，则这里是文字，否则为图片路径
        /// </summary>
        public string waterMarkContent
        {
            get { return _waterMarkContent; }
            set { _waterMarkContent = value; }
        }
        /// <summary>
        /// 画布的颜色
        /// </summary>
        public Color graphicsColor
        {
            set {
                _graphicsColor = value;
            }
            get {
                if (_graphicsColor != null)
                {
                    return Color.White;
                }
                return _graphicsColor; 
            }
        }
        /// <summary>
        /// 字体属性
        /// </summary>
        public Font fontStyle
        {
            set { _fontStyle = value; }
            get {
                if (_fontStyle == null)
                {
                    return new Font("arial", 10, FontStyle.Regular);
                }
                return _fontStyle; 
            }
        }
        /// <summary>
        /// 水印位置
        /// </summary>
        public WatermarkPosition watermarkPosition
        {
            set { _watermarkPosition = value;}
            get { return _watermarkPosition; }
        }
        /// <summary>
        /// 偏移高度
        /// </summary>
        public float waterHeight
        {
            set { _waterHeight = value; }
            get { return waterHeight; }
        }
        /// <summary>
        /// 偏移宽度
        /// </summary>
        public float waterWidth
        {
            set { _waterWidth = value; }
            get { return waterWidth; }
        }
        /// <summary>
        /// 新图片名称
        /// </summary>
        public string newImageName
        {
            set { _newImageName = value; }
            get { return _newImageName; }
        }

        public HandleImage()
        {
            this._oldPath = "/Images/quan.jpg";
            this._newPath = "/Images";
            this._wmtType = 1;
            this._waterMarkContent = "mcake";
            this._graphicsColor = Color.White;
            this._fontStyle = new Font("arial", 10, FontStyle.Regular);
            this._watermarkPosition = WatermarkPosition.WM_BOTTOM_RIGHT;
            this._waterHeight = .99f;
            this._waterWidth = .99f;
            this._newImageName = "mcake";
        }

        /// <summary>
        /// 给原图片加水印
        /// </summary>
        public void addWaterMark()
        {
            string picurl = HttpContext.Current.Server.MapPath(this._oldPath);
            Image image = Image.FromFile(picurl);
            //先转位图,将原图像画到位图上,再保存位图,以免发送错误：无法从带有索引像素格式的图像创建 Graphics 对象
            Bitmap b = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(b);
            g.Clear(this.graphicsColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            switch (wmtType)
            {
                case 1:
                    addWatermarkText(g, this.waterMarkContent, this.watermarkPosition, image.Width, image.Height);
                    break;
                case 2:
                    addWatermarkImage(g, HttpContext.Current.Server.MapPath(this.waterMarkContent), this.watermarkPosition, image.Width, image.Height);
                    break;
                default:
                    addWatermarkText(g, this.waterMarkContent, this.watermarkPosition, image.Width, image.Height);
                    break;
            }
            this._newPath = HttpContext.Current.Request.ApplicationPath + this._newPath;
            if (!Directory.Exists(this._newPath))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(this._newPath));
            }
            b.Save(HttpContext.Current.Server.MapPath(_newPath + "/" + this.newImageName + ".jpg"));
            b.Dispose();
            image.Dispose();
        }

        /// <summary>
        ///  加水印文字
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="_watermarkText">水印文字内容</param>
        /// <param name="_watermarkPosition">水印位置</param>
        /// <param name="_width">被加水印图片的宽</param>
        /// <param name="_height">被加水印图片的高</param>
        private void addWatermarkText(Graphics picture, string _watermarkText, WatermarkPosition _watermarkPosition, int _width, int _height)
        {
            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
            //Font crFont = null;
            SizeF crSize = new SizeF();
            for (int i = 0; i < 7; i++)
            {
                //crFont = new Font("arial", 10, FontStyle.Regular);
                crSize = picture.MeasureString(_watermarkText, this.fontStyle);

                if ((ushort)crSize.Width < (ushort)_width)
                    break;
            }

            float xpos = 0;
            float ypos = 0;

            switch (_watermarkPosition)
            {
                case WatermarkPosition.WM_TOP_LEFT:
                    xpos = ((float)_width * (float).01) + (crSize.Width / 2);
                    ypos = (float)_height * (float).01;
                    break;
                case WatermarkPosition.WM_TOP_RIGHT:
                    xpos = ((float)_width * (float).99) - (crSize.Width / 2);
                    ypos = (float)_height * (float).01;
                    break;
                case WatermarkPosition.WM_BOTTOM_RIGHT:
                    xpos = ((float)_width * this._waterWidth) - (crSize.Width / 2);
                    ypos = ((float)_height * this._waterHeight) - crSize.Height;
                    break;
                case WatermarkPosition.WM_BOTTOM_LEFT:
                    xpos = ((float)_width * (float).01) + (crSize.Width / 2);
                    ypos = ((float)_height * (float).99) - crSize.Height;
                    break;
            }
            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;

            SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));
            picture.DrawString(_watermarkText, this.fontStyle, semiTransBrush2, xpos + 1, ypos + 1, StrFormat);

            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
            picture.DrawString(_watermarkText, this.fontStyle, semiTransBrush, xpos, ypos, StrFormat);

            semiTransBrush2.Dispose();
            semiTransBrush.Dispose();
        }

        /// <summary>
        ///  加水印图片
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="WaterMarkPicPath">水印图片的地址</param>
        /// <param name="_watermarkPosition">水印位置</param>
        /// <param name="_width">被加水印图片的宽</param>
        /// <param name="_height">被加水印图片的高</param>
        private void addWatermarkImage(Graphics picture, string waterMarkPicPath, WatermarkPosition _watermarkPosition, int _width, int _height)
        {
            Image watermark = new Bitmap(waterMarkPicPath);

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float[][] colorMatrixElements = {
                                                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;
            int WatermarkWidth = 0;
            int WatermarkHeight = 0;
            double bl = 1d;
            //计算水印图片的比率
            //取背景的1/4宽度来比较
            if ((_width > watermark.Width * 4) && (_height > watermark.Height * 4))
            {
                bl = 1;
            }
            else if ((_width > watermark.Width * 4) && (_height < watermark.Height * 4))
            {
                bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

            }
            else

                if ((_width < watermark.Width * 4) && (_height > watermark.Height * 4))
                {
                    bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
                }
                else
                {
                    if ((_width * watermark.Height) > (_height * watermark.Width))
                    {
                        bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

                    }
                    else
                    {
                        bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);

                    }

                }

            WatermarkWidth = Convert.ToInt32(watermark.Width * bl);
            WatermarkHeight = Convert.ToInt32(watermark.Height * bl);

            switch (_watermarkPosition)
            {
                case WatermarkPosition.WM_TOP_LEFT:
                    xpos = 10;
                    ypos = 10;
                    break;
                case WatermarkPosition.WM_TOP_RIGHT:
                    xpos = _width - WatermarkWidth - 10;
                    ypos = 10;
                    break;
                case WatermarkPosition.WM_BOTTOM_RIGHT:
                    xpos = _width - WatermarkWidth - 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
                case WatermarkPosition.WM_BOTTOM_LEFT:
                    xpos = 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
            }

            picture.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

            watermark.Dispose();
            imageAttributes.Dispose();
        }

        #region
        ///// <summary>
        ///// 给原图片加水印
        ///// </summary>
        ///// <param name="oldpath">原图的图片路径</param>
        ///// <param name="wmtType">水印类型，1为文字水印，2为图片水印</param>
        ///// <param name="sWaterMarkContent">水印内容，如果是文字水印，则这里是文字，否则为图片路径</param>
        //public static void addWaterMark(string oldpath, int wmtType, string sWaterMarkContent)
        //{
        //    string picurl = HttpContext.Current.Server.MapPath(oldpath);
        //    Image image = Image.FromFile(picurl);
        //    //先转位图,将原图像画到位图上,再保存位图,以免发送错误：无法从带有索引像素格式的图像创建 Graphics 对象
        //    Bitmap b = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
        //    Graphics g = Graphics.FromImage(b);
        //    g.Clear(Color.White);
        //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //    g.DrawImage(image, 0, 0, image.Width, image.Height);
        //    switch (wmtType)
        //    {
        //        case 1:
        //            addWatermarkText(g, sWaterMarkContent, "WM_BOTTOM_RIGHT", image.Width, image.Height);
        //            break;
        //        case 2:
        //            addWatermarkImage(g, HttpContext.Current.Server.MapPath(sWaterMarkContent), "WM_BOTTOM_RIGHT", image.Width, image.Height);
        //            break;
        //        default:
        //            break;
        //    }
        //    b.Save(HttpContext.Current.Server.MapPath("~/images/coupon/" + sWaterMarkContent + ".jpg"));
        //    b.Dispose();
        //    image.Dispose();
        //}

        //#region -----------水印文字
        ///// <summary>
        /////  加水印文字
        ///// </summary>
        ///// <param name="picture">imge 对象</param>
        ///// <param name="_watermarkText">水印文字内容</param>
        ///// <param name="_watermarkPosition">水印位置</param>
        ///// <param name="_width">被加水印图片的宽</param>
        ///// <param name="_height">被加水印图片的高</param>
        //private static void addWatermarkText(Graphics picture, string _watermarkText, string _watermarkPosition, int _width, int _height)
        //{
        //    int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
        //    Font crFont = null;
        //    SizeF crSize = new SizeF();
        //    for (int i = 0; i < 7; i++)
        //    {
        //        crFont = new Font("arial", 10, FontStyle.Regular);
        //        crSize = picture.MeasureString(_watermarkText, crFont);

        //        if ((ushort)crSize.Width < (ushort)_width)
        //            break;
        //    }
            

        //    float xpos = 0;
        //    float ypos = 0;

        //    switch (_watermarkPosition)
        //    {
        //        case "WM_TOP_LEFT":
        //            xpos = ((float)_width * (float).01) + (crSize.Width / 2);
        //            ypos = (float)_height * (float).01;
        //            break;
        //        case "WM_TOP_RIGHT":
        //            xpos = ((float)_width * (float).99) - (crSize.Width / 2);
        //            ypos = (float)_height * (float).01;
        //            break;
        //        case "WM_BOTTOM_RIGHT":
        //            xpos = ((float)_width * (float).94) - (crSize.Width / 2);
        //            ypos = ((float)_height * (float).85) - crSize.Height;
        //            break;
        //        case "WM_BOTTOM_LEFT":
        //            xpos = ((float)_width * (float).01) + (crSize.Width / 2);
        //            ypos = ((float)_height * (float).99) - crSize.Height;
        //            break;
        //    }
        //    StringFormat StrFormat = new StringFormat();
        //    StrFormat.Alignment = StringAlignment.Center;

        //    SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));
        //    picture.DrawString(_watermarkText, crFont, semiTransBrush2, xpos + 1, ypos + 1, StrFormat);

        //    SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
        //    picture.DrawString(_watermarkText, crFont, semiTransBrush, xpos, ypos, StrFormat);

        //    semiTransBrush2.Dispose();
        //    semiTransBrush.Dispose();
        //}

        //#endregion

        //#region -----------加水印图片

        ///// <summary>
        /////  加水印图片
        ///// </summary>
        ///// <param name="picture">imge 对象</param>
        ///// <param name="WaterMarkPicPath">水印图片的地址</param>
        ///// <param name="_watermarkPosition">水印位置</param>
        ///// <param name="_width">被加水印图片的宽</param>
        ///// <param name="_height">被加水印图片的高</param>
        //private static void addWatermarkImage(Graphics picture, string WaterMarkPicPath, string _watermarkPosition, int _width, int _height)
        //{
        //    Image watermark = new Bitmap(WaterMarkPicPath);

        //    ImageAttributes imageAttributes = new ImageAttributes();
        //    ColorMap colorMap = new ColorMap();

        //    colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
        //    colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
        //    ColorMap[] remapTable = { colorMap };

        //    imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

        //    float[][] colorMatrixElements = {
        //                                        new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
        //                                        new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
        //                                        new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
        //                                        new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
        //                                        new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
        //                                    };

        //    ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

        //    imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

        //    int xpos = 0;
        //    int ypos = 0;
        //    int WatermarkWidth = 0;
        //    int WatermarkHeight = 0;
        //    double bl = 1d;
        //    //计算水印图片的比率
        //    //取背景的1/4宽度来比较
        //    if ((_width > watermark.Width * 4) && (_height > watermark.Height * 4))
        //    {
        //        bl = 1;
        //    }
        //    else if ((_width > watermark.Width * 4) && (_height < watermark.Height * 4))
        //    {
        //        bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

        //    }
        //    else

        //        if ((_width < watermark.Width * 4) && (_height > watermark.Height * 4))
        //        {
        //            bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
        //        }
        //        else
        //        {
        //            if ((_width * watermark.Height) > (_height * watermark.Width))
        //            {
        //                bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

        //            }
        //            else
        //            {
        //                bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);

        //            }

        //        }

        //    WatermarkWidth = Convert.ToInt32(watermark.Width * bl);
        //    WatermarkHeight = Convert.ToInt32(watermark.Height * bl);

        //    switch (_watermarkPosition)
        //    {
        //        case "WM_TOP_LEFT":
        //            xpos = 10;
        //            ypos = 10;
        //            break;
        //        case "WM_TOP_RIGHT":
        //            xpos = _width - WatermarkWidth - 10;
        //            ypos = 10;
        //            break;
        //        case "WM_BOTTOM_RIGHT":
        //            xpos = _width - WatermarkWidth - 10;
        //            ypos = _height - WatermarkHeight - 10;
        //            break;
        //        case "WM_BOTTOM_LEFT":
        //            xpos = 10;
        //            ypos = _height - WatermarkHeight - 10;
        //            break;
        //    }

        //    picture.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

        //    watermark.Dispose();
        //    imageAttributes.Dispose();
        //}


        //#endregion
        #endregion


    }
}
