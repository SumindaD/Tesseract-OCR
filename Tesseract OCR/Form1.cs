using System;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;
using System.IO;
using NUnit.Framework;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Tesseract_OCR
{
    public partial class FormOCRTesseract : Form
    {
        int x = 0;
        int y = 0;
        int width = 0;
        int height = 0;
        bool isMouseDown = false;
        string basedImagePath;
        string ResultsDirectory;
        string ConvertedImageResultDirectory;

        Rectangle rect;
        Point LocationX1Y1;
        Point LocationX2Y2;

        Bitmap image, cropImg, bitDepthBitmap;
        EncoderParameter bitDepthEncoderParameter;
        Encoder bitDepthEncoder;
        EncoderParameters bitDepthEncoderParameters;
        ImageCodecInfo bitDepthImageCodecInfo;

        public FormOCRTesseract()
        {
            InitializeComponent();
        }

        private void FormOCRTesseract_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //Create essential directories in MyDocuments
            string basedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ResultsDirectory = basedPath + @"\Tesseract OCR\temp";
            ConvertedImageResultDirectory = basedPath + @"\Tesseract OCR\temp\converted";

            if (!Directory.Exists(ResultsDirectory) || (!Directory.Exists(ConvertedImageResultDirectory)))
            {
                Directory.CreateDirectory(ResultsDirectory);
                Directory.CreateDirectory(ConvertedImageResultDirectory);
            }
        }

        private void ButtonImport_Click(object sender, EventArgs e)
        {
            ImportImage();
        }

        private void ButtonExtractText_Click(object sender, EventArgs e)
        {
            ExtractTextFromImage();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            richTextBoxTextOut.Clear();
        }

        private void PictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            LocationX1Y1 = e.Location;
        }

        private void PictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                LocationX2Y2 = e.Location;
                Refresh();
            }
            if (e.Button == MouseButtons.Right && pictureBoxImage.Image != null)
            {
                int newLeft = e.X + pictureBoxImage.Left - LocationX1Y1.X;
                int newTop = e.Y + pictureBoxImage.Top - LocationX1Y1.Y;

                pictureBoxImage.Left = newLeft;
                pictureBoxImage.Top = newTop;
            }
        }

        private void PictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                LocationX2Y2 = e.Location;
                isMouseDown = false;
            }
        }

        private void PictureBoxImage_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect());
                x = rect.X;
                y = rect.Y;
                width = rect.Width;
                height = rect.Height;
            }
        }

        private Rectangle GetRect()
        {
            rect = new Rectangle();
            rect.X = Math.Min(LocationX1Y1.X, LocationX2Y2.X);
            rect.Y = Math.Min(LocationX1Y1.Y, LocationX2Y2.Y);
            rect.Width = Math.Abs(LocationX1Y1.X - LocationX2Y2.X);
            rect.Height = Math.Abs(LocationX1Y1.Y - LocationX2Y2.Y);

            return rect;
        }

        private ImageCodecInfo GetCodecForstring(string type)
        {
            ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();

            for (int i = 0; i < info.Length; i++)
            {
                string EnumName = type.ToString();
                if (info[i].FormatDescription.Equals(EnumName))
                {
                    return info[i];
                }
            }

            return null;

        }

        private void ReformatImage(string imagePath) 
        {
            using (MemoryStream memStream = new MemoryStream(File.ReadAllBytes(imagePath)))
            {
                ImageCodecInfo codecInfo = GetCodecForstring("TIFF");

                Bitmap image = new Bitmap(memStream);
                EncoderParameters iparams = new EncoderParameters(1);
                Encoder iparam = Encoder.Compression;
                EncoderParameter iparamPara = new EncoderParameter(iparam, (long)(EncoderValue.CompressionCCITT4));
                iparams.Param[0] = iparamPara;

                File.Delete(imagePath);

                image.Save(imagePath, codecInfo, iparams);
            }
        }

        private void ImportImage()
        {
            var tokenExpiration = TimeSpan.FromMinutes(22);

            var date = DateTime.UtcNow.AddMinutes(tokenExpiration.Minutes);


            //string filePath = @"C:\Users\User\Desktop\Testing\00000001.TIF";
            //try
            //{
            //    // Check if Image can be opened via Tesseract library,
            //    // Otherwise, PixArray.LoadMultiPageTiffFromFile will lock the file and it won't release unless service restart
            //    using (MemoryStream memStream = new MemoryStream(File.ReadAllBytes(filePath)))
            //    {
            //        var pixA = Pix.LoadTiffFromMemory(memStream.ToArray());
            //    }

            //    //using (var pixA = Pix.LoadFromFile(filePath))
            //    //{
            //    //    int x = 0;
            //    //}

            //    using (var pixA = PixArray.LoadMultiPageTiffFromFile(filePath))
            //    {
            //        int x = 0;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //ReformatImage(filePath);
            //    //ImportImage();
            //}
            //finally 
            //{
            //    File.Delete(filePath);
            //}


            //DeleteAndResetPicturebox();

            //openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp; *.tif)|*.jpg; *.jpeg; *.gif; *.png; *.bmp; *.tif";

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    image = new Bitmap(openFileDialog.FileName);
            //    pictureBoxImage.Tag = openFileDialog.FileName;
            //    basedImagePath = openFileDialog.FileName.ToString();
            //    pictureBoxImage.Image = image;

            //    if (pictureBoxImage.Image != null)
            //    {
            //        buttonConvertRGBToGray.Enabled = true;
            //        buttonDescew.Enabled = true;
            //        buttonOtsuBinarization.Enabled = true;
            //        buttonSauvolaBinarization.Enabled = true;
            //        buttonSauvolaTiledBinarization.Enabled = true;
            //        buttonResetImage.Enabled = true;
            //        buttonDespeckle.Enabled = true;
            //    }
            //}
        }

        private void ExtractTextFromImage()
        {
            try
            {
                if (image != null)
                {
                    CropImage();

                    string trainingPath = "./tessdata";
                    string lang = "eng";
                    var ocr = new TesseractEngine(trainingPath, lang, EngineMode.TesseractOnly);
                    var text = ocr.Process(cropImg);

                    richTextBoxTextOut.AppendText(text.GetText());
                }
                else
                {
                    MessageBox.Show("Import a picture before click Extract Text button.");
                    ImportImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CropImage()
        {
            cropImg = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(cropImg);
            //g.DrawImage(image, 0, 0, rect, GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle() { X = 0, Y = 0, Width = width, Height = height }, rect, GraphicsUnit.Pixel);

            cropImg = new Bitmap(cropImg, new Size(rect.Width * 1, rect.Height * 1));
        }

        //Deskew image 
        private void ButtonDescew_Click(object sender, EventArgs e)
        {
            try
            {
                var sourcePixPath = pictureBoxImage.Tag.ToString();
                
                string resultImageName = "descewedImage.png";

                using (var sourcePix = Pix.LoadFromFile(sourcePixPath))
                {
                    Scew scew;
                    using (var descewedImage = sourcePix.Deskew(new ScewSweep(range: 45), Pix.DefaultBinarySearchReduction, Pix.DefaultBinaryThreshold, out scew))
                    {
                        if(File.Exists(Path.Combine(ResultsDirectory, resultImageName)))
                        {
                            if (pictureBoxImage.Image != null)
                            {
                                pictureBoxImage.Image.Dispose();
                            }

                            File.Delete(Path.Combine(ResultsDirectory, resultImageName));
                        }

                        SaveResult(descewedImage, resultImageName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Otsu Binarization image
        private void ButtonOtsuBinarization_Click(object sender, EventArgs e)
        {
            try
            {
                var sourcePixFilename = pictureBoxImage.Tag.ToString();

                //int bitDepth = 8;
                string bitDepthImageName = "otsuImage8bit.png";
                string resultImageName = "otsuBinarizedImg.png";

                var convertedImagePath = BitDepthConverter(sourcePixFilename, 8L, bitDepthImageName);

                using (var sourcePix = Pix.LoadFromFile(convertedImagePath.ToString()))
                {
                    using (var binarizedImage = sourcePix.BinarizeOtsuAdaptiveThreshold(200, 200, 10, 10, 0.1F))
                    {
                        if ((File.Exists(Path.Combine(ResultsDirectory, resultImageName)) ||(File.Exists(Path.Combine(ConvertedImageResultDirectory, bitDepthImageName)))))
                        {
                            if (pictureBoxImage.Image != null)
                            {
                                pictureBoxImage.Image.Dispose();
                            }

                            File.Delete(Path.Combine(ResultsDirectory, resultImageName));
                        }

                        SaveResult(binarizedImage, resultImageName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Sauvola binarization image
        private void ButtonSauvolaBinarization_Click(object sender, EventArgs e)
        {
            try
            {
                var sourcePixFilename = pictureBoxImage.Tag.ToString();

                string bitDepthImageName = "sauvolaImage32bit.png";
                string resultImageName = "binarizedSauvolaImage.png";

                var convertedImagePath = BitDepthConverter(sourcePixFilename, 32L, bitDepthImageName);

                using (var sourcePix = Pix.LoadFromFile(convertedImagePath.ToString()))
                {
                    using (var grayscalePix = sourcePix.ConvertRGBToGray(1, 1, 1))
                    {
                        using (var binarizedImage = grayscalePix.BinarizeSauvola(10, 0.35f, false))
                        {
                            if ((File.Exists(Path.Combine(ResultsDirectory, resultImageName)) || (File.Exists(Path.Combine(ConvertedImageResultDirectory, bitDepthImageName)))))
                            {
                                if (pictureBoxImage.Image != null)
                                {
                                    pictureBoxImage.Image.Dispose();
                                }

                                File.Delete(Path.Combine(ResultsDirectory, resultImageName));
                            }

                            SaveResult(binarizedImage, resultImageName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Sauvola Tiled Binarization
        private void ButtonSauvolaTiledBinarization_Click(object sender, EventArgs e)
        {
            try
            {
                var sourcePixFilename = pictureBoxImage.Tag.ToString();
                string bitDepthImageName = "sauvolaTiledImage32bit.png";
                string resultImageName = "binarizedSauvolaTiledImage.png";

                var convertedImagePath = BitDepthConverter(sourcePixFilename, 32L, bitDepthImageName);

                using (var sourcePix = Pix.LoadFromFile(convertedImagePath.ToString()))
                {
                    using (var grayscalePix = sourcePix.ConvertRGBToGray(1, 1, 1))
                    {
                        using (var binarizedImage = grayscalePix.BinarizeSauvolaTiled(10, 0.35f, 2, 2))
                        {

                            if ((File.Exists(Path.Combine(ResultsDirectory, resultImageName)) || (File.Exists(Path.Combine(ConvertedImageResultDirectory, bitDepthImageName)))))
                            {
                                if (pictureBoxImage.Image != null)
                                {
                                    pictureBoxImage.Image.Dispose();
                                }

                                File.Delete(Path.Combine(ResultsDirectory, resultImageName));
                            }

                            SaveResult(binarizedImage, resultImageName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        //Convert RGB to Grayscale image
        private void ButtonConvertRGBToGray_Click(object sender, EventArgs e)
        {
            try
            {
                var sourcePixFilename = pictureBoxImage.Tag.ToString();

                string bitDepthImageName = "grayscale32bit.png";
                string resultImageName = "grayscaleImage.png";

                var convertedImagePath = BitDepthConverter(sourcePixFilename, 32L, bitDepthImageName);

                using (var sourcePix = Pix.LoadFromFile(convertedImagePath.ToString()))
                using (var grayscaleImage = sourcePix.ConvertRGBToGray())
                {

                    if ((File.Exists(Path.Combine(ResultsDirectory, resultImageName)) || (File.Exists(Path.Combine(ConvertedImageResultDirectory, bitDepthImageName)))))
                    {
                        if (pictureBoxImage.Image != null)
                        {
                            pictureBoxImage.Image.Dispose();
                        }

                        File.Delete(Path.Combine(ResultsDirectory, resultImageName));
                    }

                    SaveResult(grayscaleImage, resultImageName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Despeckle
        private void buttonDespeckle_Click(object sender, EventArgs e)
        {
            try
            {
                var sourcePixFilename = pictureBoxImage.Tag.ToString();

                string bitDepthImageName = "despeckle32bit.png";
                string resultImageName = "DespeckleImage.png";

                var bitmap = (Bitmap)pictureBoxImage.Image;

                var testImage = ColorToGrayscale(bitmap);

                testImage.Save(@"C:\Users\User\Desktop\Test.png");

                using (var sourcePix = Pix.LoadFromFile(@"C:\Users\User\Desktop\Test.png"))
                {
                    using (var result = sourcePix.Despeckle(Pix.SEL_STR2, 2))
                    {
                        if ((File.Exists(Path.Combine(ResultsDirectory, resultImageName))))
                        {
                            if (pictureBoxImage.Image != null)
                            {
                                pictureBoxImage.Image.Dispose();
                            }

                            File.Delete(Path.Combine(ResultsDirectory, resultImageName));
                        }

                        SaveResult(result, resultImageName);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Converts a bitmap into an 8-bit grayscale bitmap
        /// </summary>
        public static Bitmap ColorToGrayscale(Bitmap bmp)
        {
            int w = bmp.Width,
                h = bmp.Height,
                r, ic, oc, bmpStride, outputStride, bytesPerPixel;
            PixelFormat pfIn = bmp.PixelFormat;
            ColorPalette palette;
            Bitmap output;
            BitmapData bmpData, outputData;

            //Create the new bitmap
            output = new Bitmap(w, h, PixelFormat.Format8bppIndexed);
            output.SetResolution(96, 96);

            //Build a grayscale color Palette
            palette = output.Palette;
            for (int i = 0; i < 256; i++)
            {
                Color tmp = Color.FromArgb(255, i, i, i);
                palette.Entries[i] = Color.FromArgb(255, i, i, i);
            }
            output.Palette = palette;

            //No need to convert formats if already in 8 bit
            if (pfIn == PixelFormat.Format8bppIndexed)
            {
                output = (Bitmap)bmp.Clone();

                //Make sure the palette is a grayscale palette and not some other
                //8-bit indexed palette
                output.Palette = palette;

                return output;
            }

            //Get the number of bytes per pixel
            switch (pfIn)
            {
                case PixelFormat.Format24bppRgb: bytesPerPixel = 3; break;
                case PixelFormat.Format32bppArgb: bytesPerPixel = 4; break;
                case PixelFormat.Format32bppRgb: bytesPerPixel = 4; break;
                default: throw new InvalidOperationException("Image format not supported");
            }

            //Lock the images
            bmpData = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly,
                                   pfIn);
            outputData = output.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly,
                                         PixelFormat.Format8bppIndexed);
            bmpStride = bmpData.Stride;
            outputStride = outputData.Stride;

            //Traverse each pixel of the image
            unsafe
            {
                byte* bmpPtr = (byte*)bmpData.Scan0.ToPointer(),
                outputPtr = (byte*)outputData.Scan0.ToPointer();

                if (bytesPerPixel == 3)
                {
                    //Convert the pixel to it's luminance using the formula:
                    // L = .299*R + .587*G + .114*B
                    //Note that ic is the input column and oc is the output column
                    for (r = 0; r < h; r++)
                        for (ic = oc = 0; oc < w; ic += 3, ++oc)
                            outputPtr[r * outputStride + oc] = (byte)(int)
                                (0.299f * bmpPtr[r * bmpStride + ic] +
                                 0.587f * bmpPtr[r * bmpStride + ic + 1] +
                                 0.114f * bmpPtr[r * bmpStride + ic + 2]);
                }
                else //bytesPerPixel == 4
                {
                    //Convert the pixel to it's luminance using the formula:
                    // L = alpha * (.299*R + .587*G + .114*B)
                    //Note that ic is the input column and oc is the output column
                    for (r = 0; r < h; r++)
                        for (ic = oc = 0; oc < w; ic += 4, ++oc)
                            outputPtr[r * outputStride + oc] = (byte)(int)
                                ((bmpPtr[r * bmpStride + ic] / 255.0f) *
                                (0.299f * bmpPtr[r * bmpStride + ic + 1] +
                                 0.587f * bmpPtr[r * bmpStride + ic + 2] +
                                 0.114f * bmpPtr[r * bmpStride + ic + 3]));
                }
            }

            //Unlock the images
            bmp.UnlockBits(bmpData);
            output.UnlockBits(outputData);
            

            return output;
        }

        //Reset Image
        private void ButtonResetImage_Click(object sender, EventArgs e)
        {
            DeleteAndResetPicturebox();

            image = new Bitmap(basedImagePath);
            pictureBoxImage.Image = image;
            pictureBoxImage.Tag = basedImagePath;

        }

        //Reset Picturebox
        private void DeleteAndResetPicturebox()
        {
            if (pictureBoxImage.Image != null)
            {
                pictureBoxImage.Image.Dispose();
            }

            DirectoryInfo di = new DirectoryInfo(ResultsDirectory);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            DirectoryInfo di2 = new DirectoryInfo(ConvertedImageResultDirectory);
            foreach (FileInfo file in di2.GetFiles())
            {
                file.Delete();
            }
        }

        //Save images in directory
        private void SaveResult(Pix result, string filename)
        {
            var runFilename = Path.Combine(ResultsDirectory, filename);
            result.Save(runFilename);

            image = new Bitmap(Path.Combine(ResultsDirectory, filename));
            pictureBoxImage.Image = image;
            pictureBoxImage.Tag = Path.Combine(ResultsDirectory, filename);
        }


        //Image Bit depth convertor
        private string BitDepthConverter(string sourcePixFilename, long bitDepth, string fileName)
        {
            bitDepthBitmap = new Bitmap(sourcePixFilename);
            bitDepthImageCodecInfo = GetEncoderInfo("image/png");
            bitDepthEncoder = Encoder.ColorDepth;
            bitDepthEncoderParameters = new EncoderParameters(1);

            bitDepthEncoderParameter = new EncoderParameter(bitDepthEncoder, bitDepth);
            bitDepthEncoderParameters.Param[0] = bitDepthEncoderParameter;

            string path = Path.Combine(ConvertedImageResultDirectory, fileName);
            bitDepthBitmap.Save(path, bitDepthImageCodecInfo, bitDepthEncoderParameters);
            bitDepthBitmap.Dispose();
            return path;
        }

        //Get image encoded info for BitDepthConverter function
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
