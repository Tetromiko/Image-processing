using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;

namespace Theme31
{
    public partial class Form1 : Form
    {
        Image image,resizedImage,output, resizedOut;
        Func<Image, Image>[] filters = {  Filtering.Blur, Filtering.Sharpen, Filtering.Repulsion, Filtering.GaussianDifference, Filtering.Mediane };
        public Form1()
        {
            InitializeComponent();
            output = new Bitmap(2, 2);
            image = new Bitmap(2,2);
        }
        private void dropField_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void filter_Click(object sender, EventArgs e)
        {
            if ((output = filters[buttons.GetRow((Button)sender)](image)) != null)
            {
                outputImage.Image = output;
            }
            ResizeImages();
            MessageBox.Show($" PSNR = {Testing.CalculatePSNR(image, output)}, SSIM = {Testing.CalculateSSIM(image, output)}");
        }

        private void SaveImage(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image File (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Image image = output;
                image.Save(filePath);
            }
        }

        private void OpenImage(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp) | *.jpg; *.jpeg; *.png; *.bmp";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image fileImage = Image.FromFile(openFileDialog1.FileName);
                    image = fileImage;
                    ResizeImages();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталася помилка: " + ex.Message);
                }
            }
        }

        private void dropField_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                image = Image.FromFile(files[0]);
                ResizeImages();
            }

        }
        
        private void ResizeImages()
        {
            int width = image.Width;
            int height = image.Height;
            int maxWidth = inputImage.Size.Width;
            int maxHeight = inputImage.Size.Height;
            double widthRatio = (double)maxWidth / width;
            double heightRatio = (double)maxHeight / height;
            double ratio = Math.Min(widthRatio, heightRatio);
            int newWidth = (int)(width * ratio);
            int newHeight = (int)(height * ratio);
            resizedImage = new Bitmap(image, newWidth, newHeight);
            inputImage.Image = resizedImage;
            resizedOut = new Bitmap(output, newWidth, newHeight);
            outputImage.Image = resizedOut;
        }
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeImages();
        }
    }
}