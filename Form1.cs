using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatricksImagingTools;


namespace Gruppenseminar2425 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }
    Bitmap bitBeispiel; //Bitmaps sind unsere "klassischen" Bilder, also eine Fläche mit ganz vielen Pixeln, die alle 2 Koordinaten haben und einen Farbwert
    ImageObject ioBeispiel; //ImageObjects sind Objekte, die eigentlich nur sehr lange Listen mit Pixeln sind
    ImageObjectList iol_cellpose_result;


    //Der folgende Button öffnet zunächst die Tiff-Ausgabe von cellpose (das sind 16bit Graustufenbilder, die sind blöd einzulesen)
    private void buttonOpenFile_Click(object sender, EventArgs e) { //alles was jetzt folgt, passiert, sobald dieser button gedrückt wird
      OpenFileDialog openFileDialog = new OpenFileDialog(); //öffnet den Windowseigenen "Datei-öffnen"-Dialog
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {//falls das fenster nicht weggeklickt wurde etc.
        string path = openFileDialog.FileName; //FileName ist der pfad, der zu der Datei führt (zB D:/Eigene Dateien/Bild.tif)
        ImageMagick.MagickImage magickImage = new ImageMagick.MagickImage(path);
        Bitmap bitmap = new Bitmap(path);
        ushort[] pixelvalues = magickImage.GetPixels().GetValues();
        iol_cellpose_result = new ImageObjectList();
        List<ushort> shorts  = new List<ushort>();

        for (int y = 0; y < bitmap.Height; y++) {
          for (int x = 0; x < bitmap.Width; x++) {
            ushort p=pixelvalues[y*bitmap.Width+x];
            if (p!=0) {
              if (shorts.Contains(p)) {
                iol_cellpose_result[shorts.IndexOf(p)].Add(new Point(x, y));
              }
              else {
                iol_cellpose_result.Add(new ImageObject());
                shorts.Add(p);
                iol_cellpose_result[shorts.IndexOf(p)].Add(new Point(x, y));
              }
            }
          }
        }


      }

      
    }

    private void buttonTutorial_Click(object sender, EventArgs e) {
      //so öffnet man "normale" 8-bit Bilder:
      OpenFileDialog openFileDialog = new OpenFileDialog(); //erstmal wieder die Datei auswählen
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        bitBeispiel=new Bitmap(openFileDialog.FileName);
        
      }
    }
  }
}
