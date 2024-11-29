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
        bitBeispiel=new Bitmap(openFileDialog.FileName); //hier erstellt man die eingelesene Bilddatei einfach als "bitmap"
      }
      int iTest = 0; //ich erstelle ienen integer namens iTest und setze ihn auf 0
      Color DiesIstEineFarbe=bitBeispiel.GetPixel(5,10); //hiermit lese ich die "Farbe" des Pixels im Bild bei x=5, y=10. Die Farbe ist jetzt in DiesIstEineFarbe gespeichert
      iTest = DiesIstEineFarbe.R; // jetzt setze ich i auf den Rotwert (R) des Pixels, das ich eben eingelesen habe. Bei graustufenbildern sind R, G und B gleich (ist also egal, was man nimmt)

      int[] iTestArray = new int[20]; //so erstelle ich einen Array, der aus integern besteht und 20 lang ist
      for (int i = 0; i < 20; i++) { //for-schleife, die ich nutze, um alle einträge in iTestArray zu ändern. ACHTUNG: Das erste Element hat immer den index 0, darum starten wir auch bei i=0
        iTestArray[i] = 10;
      }
      
      //wenn ich keine Ahnung habe, wie lang mein Array sein muss, dann kann ich auch eine Liste bennutzen
      List<int> Testliste = new List<int>();
      //jetzt kann ich beliebig viele Sachen da reinschreiben
      Testliste.Add(1);
      Testliste.Add(2057);
      Testliste.Add(45); //jetzt habe ich 3 verschiedene Zahlen in meiner Liste :) 1, 2057 und 45. Ohne dass ich am Anfang wissen muss, wie viele Zahlen ich reinschreibe

      //mit einer foreach-schleife kann ich jedes Element in einer Liste einmal durchgehen
      foreach (int blabla in Testliste) { //--> was in dieser Schleife steht, wird einmal für jeden int in testliste ausgeführt. 
        ioBeispiel.Add(blabla,2);
      }

    }
  }
}
