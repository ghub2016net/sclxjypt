using System;
using System.Collections.Generic;
using System.Web;
using System.Drawing;
using System.IO;

namespace HzsCommon
{
    /// <summary>
    ///MakeThumbnails 的摘要说明
    /// </summary>
    public class MakeThumbnails
    {
        public MakeThumbnails()
        {

        }

        /// <summary>
        /// 生成缩略图(最终图片固定大小,图片按比例缩小,并为缩略图加上边框,以jpg格式保存)
        /// </summary>
        /// <param name="sourceImg">原图片(物理路径)</param>
        /// <param name="toPath">缩略图存放地址(物理路径,带文件名)</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="backColor">如果图片按比例缩小后不能填充满缩略图,则使用此颜色填充(比如"#FFFFFF")</param>
        /// <param name="borderColor">边框颜色(比如"#999999")</param>
        public static int MakePic(string sourceImg, string toPath, int pW, int pH)
        {
            System.Drawing.Image originalImage = null;
            System.Drawing.Image bitmap = null;
            System.Drawing.Graphics g = null;
            try
            {
                originalImage = System.Drawing.Image.FromFile(sourceImg);
                int oW = originalImage.Width;//原始图片宽
                int oH = originalImage.Height;//原始图片高
                int tW = oW;//最终显示到页面宽
                int tH = oH;//最终显示到页面高
                if (oW > pW)//如果原始宽度大于固定宽度
                {
                    tW = pW;//最终的宽度等于固定的宽度
                    tH = pW * oH / oW;//最终的高度等于固定宽度乘以原始高度除以原始宽度
                    if (tH > pH)
                    {
                        tH = pH;
                        tW = pH * oW / oH;//最终的宽度等于固定高度乘以原始宽度除以原始高度
                    }

                }
                else if (oW < pW)//如果原始宽度小于固定宽度
                {
                    tW = oW;
                    if (oH > pH)
                    {
                        tH = pH;
                        tW = pH * oW / oH;//最终的宽度等于固定高度乘以原始宽度除以原始高度                
                    }
                }
                else//如果原始宽度等于固定宽度
                {
                    if (oH > pH)
                    {
                        tH = pH;
                        tW = pH * oW / oH;//最终的宽度等于固定高度乘以原始宽度除以原始高度                
                    }
                    if (oH < pH)
                    {
                        tH = oH;
                        tW = pH * oW / oH;//最终的宽度等于固定高度乘以原始宽度除以原始高度                
                    }
                    if (oH == pH)
                    {
                        tH = oH;
                        tW = oW;
                    }
                }
                //新建一个bmp图片 
                bitmap = new System.Drawing.Bitmap(tW, tH);
                //新建一个画板 
                g = System.Drawing.Graphics.FromImage(bitmap);
                //设置高质量插值法
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                //设置高质量,低速度呈现平滑程度  
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //if (backColor != "")
                //{
                //    //清空画布并以指定颜色填充 
                //    g.Clear(ColorTranslator.FromHtml(backColor));
                //}
                //在指定位置并且按指定大小绘制原图片的指定部分 
                g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, tW, tH),
                new System.Drawing.Rectangle(0, 0, oW, oH),
                System.Drawing.GraphicsUnit.Pixel);
                //以jpg格式保存缩略图 
                bitmap.Save(toPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return 1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                if (originalImage != null)
                {

                    originalImage.Dispose();
                }
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
                if (g != null)
                {
                    g.Dispose();
                }
            }
        }
        /// <summary>
        /// 生成缩略图(最终图片固定大小,图片按比例缩小,并为缩略图加上边框,以jpg格式保存)
        /// </summary>
        /// <param name="sourceImg">原图片(物理路径)</param>
        /// <param name="toPath">缩略图存放地址(物理路径,带文件名)</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="backColor">如果图片按比例缩小后不能填充满缩略图,则使用此颜色填充(比如"#FFFFFF")</param>
        /// <param name="borderColor">边框颜色(比如"#999999")</param>
        public static int MakePicOnlyWidth(string sourceImg, string toPath, int width, string backColor, string borderColor)
        {

            //创建一个bitmap类型的bmp变量来读取文件。
            //Bitmap bmp = new Bitmap(openFileDialog1 .FileName );
            ////新建第二个bitmap类型的bmp2变量，我这里是根据我的程序需要设置的。
            //Bitmap bmp2 = new Bitmap(1024, 768, PixelFormat.Format16bppRgb555);
            ////将第一个bmp拷贝到bmp2中
            //Graphics draw = Graphics.FromImage(bmp2);
            //draw.DrawImage(bmp,0,0);
            //pictureBox1.Image = (Image)bmp2 ;//读取bmp2到picturebox
            //FILE = openFileDialog1.FileName;
            //openFileDialog1.Dispose();
            //draw.Dispose();
            //bmp.Dispose();//释放bmp文件资源
            System.Drawing.Image originalImage = null;
            System.Drawing.Image bitmap = null;
            System.Drawing.Graphics g = null;
            try
            {
                originalImage = System.Drawing.Image.FromFile(sourceImg);
                //width = originalImage.Width > width ? width : originalImage.Width;
                //height = originalImage.Height > height ? height : originalImage.Height;
                int height = originalImage.Height * 80 / originalImage.Width;
                int towidth = width;
                int toheight = height;

                int x = 0;
                int y = 0;
                int ow = originalImage.Width;
                int oh = originalImage.Height;

                string mode;

                if (ow < towidth || oh < toheight)
                {
                    return -1;
                }
                else
                {
                    if (originalImage.Width / originalImage.Height >= width / height)
                    {
                        mode = "W";
                    }
                    else
                    {
                        mode = "H";
                    }
                    switch (mode)
                    {
                        //原始：  宽度:200 高度:100
                        //缩略后：宽度:80 高度:100*80/200=40

                        case "W"://指定宽，高按比例 
                            toheight = originalImage.Height * 80 / originalImage.Width;
                            break;
                        case "H"://指定高，宽按比例 
                            towidth = originalImage.Width * height / originalImage.Height;
                            break;
                        default:
                            break;
                    }


                    //新建一个bmp图片 
                    bitmap = new System.Drawing.Bitmap(width, height);

                    //新建一个画板 
                    g = System.Drawing.Graphics.FromImage(bitmap);
                    //设置高质量插值法
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                    //设置高质量,低速度呈现平滑程度  
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    if (backColor != "")
                    {
                        //清空画布并以指定颜色填充 
                        g.Clear(ColorTranslator.FromHtml(backColor));
                    }
                    //在指定位置并且按指定大小绘制原图片的指定部分 
                    int top = (height - toheight) / 2;
                    int left = (width - towidth) / 2;
                    g.DrawImage(originalImage, new System.Drawing.Rectangle(left, top, towidth, toheight),
                    new System.Drawing.Rectangle(x, y, ow, oh),
                    System.Drawing.GraphicsUnit.Pixel);

                    //Pen pen = new Pen(ColorTranslator.FromHtml(borderColor));
                    // g.DrawRectangle(pen, 0, 0, width - 1, height - 1);
                    //以jpg格式保存缩略图 
                    bitmap.Save(toPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return toheight;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                if (originalImage != null)
                {

                    originalImage.Dispose();
                }
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
                if (g != null)
                {
                    g.Dispose();
                }
            }
        }
        /// <summary>   
        /// 判断是否有图片   
        /// </summary>   
        /// <param name="folderPath">指定文件夹路径</param>   
        /// <returns>bool</returns>   
        public static bool judgeExpensionName(string folderPath)
        {
            bool isTp = false;

            if (Directory.Exists(folderPath))
            {
                foreach (string itemFilePath in Directory.GetFiles(folderPath))
                {
                    FileInfo fi = new FileInfo(itemFilePath);

                    //创建时间    fi.CreationTime;   
                    //获取上次访问当前目录时间 fi.LastAccessTime   
                    //获取上次写入文件目录的时间 fi.LastWriteTime   
                    if (fi.Extension.Equals(".jpg") || fi.Extension.Equals(".JPG") || fi.Extension.Equals(".jpge") || fi.Extension.Equals(".JPEG") || fi.Extension.Equals(".gif") || fi.Extension.Equals(".GIF"))
                    {
                        isTp = true;
                        break;
                    }

                    else
                        isTp = false;
                }
            }

            return isTp;
        }
        /// <summary>
        /// 加水印
        /// </summary>
        /// <param name="yuanpath"></param>
        /// <param name="newpath"></param>
        /// <param name="waterimage"></param>
        public static void makewaterimage(string yuanpath, string newpath, string waterimage)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(yuanpath);
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(waterimage);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(copyImage, new Rectangle(image.Width / 2 - copyImage.Width / 2, image.Height / 2 - copyImage.Height / 2,

            copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
            g.Dispose();

            //保存加水印过后的图片,删除原始图片
            image.Save(newpath);

            image.Dispose();

            if (File.Exists(yuanpath))
            {
                File.Delete(yuanpath);
            }
        }

    }
}