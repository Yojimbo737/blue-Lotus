using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Drawing;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
//using FlowerApp4.Models;
using FlowerApp2.Controls;


namespace FlowerApp2.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage, INotifyPropertyChanged
    {
        public RenderPage RenderPage;
        public static bool hasTouched;
        public static ObservableCollection<Coords> CoordsList;
        public string LoadCoordsString;
        public Coords currentCoords;
        public SKColor skColorStroke1;
        public SKColor skColorStroke2;
        public SKColor skColorStroke3;
        public SKColor skColorStroke4;
        public Xamarin.Forms.Color touchColor;
        public bool picker1Touchable;
        public bool picker2Touchable;
        public bool picker3Touchable;
        public bool picker4Touchable;
        public KeyChain keys;


        //public IntegersOnlyBehavior integersOnlyBehavior;

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public class getColorClass : SetupPage
        {

            public static void setColorA(Xamarin.Forms.Color C)
            {


                var gCC = new getColorClass();
                gCC.setColorB(C);
                hasTouched = true;


            }

            public void setColorB(Xamarin.Forms.Color C)
            {
                setColor(C);

            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public SetupPage()
        {


            RenderPage = new RenderPage();
            touchColor = new Xamarin.Forms.Color();
            CoordsList = new ObservableCollection<Coords>();

            loadCoords();
            keys = new KeyChain(CoordsList);
            currentCoords = new Coords();
            //currentCoords = CoordsList[0];
            InitializeComponent();

            RefreshCurrentCoordsToGUI();


            //currentCoords = new Coords();
            //currentCoords.makeUniformForSaving();

            // currentCoords.name = "New Design";
            //CoordsList.Insert(0, currentCoords);
            //RefreshCurrentCoordsToGUI();

            BindingContext = this;
            listView1.ItemsSource = CoordsList;

            BackgroundColor = Xamarin.Forms.Color.Red;
            FlowerButton.BackgroundColor = Xamarin.Forms.Color.White;
           
            backGroundColorChanger();

        }

        public void backGroundColorChanger()
        {
            Device.StartTimer(TimeSpan.FromSeconds(50), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Random random = new Random();

                    int i = random.Next(12);

                    switch (i)
                    {
                        case 0:
                            BackgroundColor = Xamarin.Forms.Color.Red;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.LightBlue;
                            break;
                        case 1:
                            BackgroundColor = Xamarin.Forms.Color.Silver;
                            break;
                        case 2:
                            BackgroundColor = Xamarin.Forms.Color.Crimson;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.Blue;
                            break;
                        case 3:
                            BackgroundColor = Xamarin.Forms.Color.Silver;
                            break;
                        case 4:
                            BackgroundColor = Xamarin.Forms.Color.Red;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.DarkOrange;
                            break;
                        case 5:
                            BackgroundColor = Xamarin.Forms.Color.Red;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.Blue;
                            break;
                        case 6:
                            BackgroundColor = Xamarin.Forms.Color.BlueViolet;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.Red;
                            break;
                        case 7:
                            BackgroundColor = Xamarin.Forms.Color.Indigo;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.Red;
                            break;
                        case 8:
                            BackgroundColor = Xamarin.Forms.Color.Turquoise;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.Orange;
                            break;
                        case 9:
                            BackgroundColor = Xamarin.Forms.Color.Indigo;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.Red;
                            break;
                        case 10:
                            BackgroundColor = Xamarin.Forms.Color.Purple;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.Red;
                            break;
                        default:
                            BackgroundColor = Xamarin.Forms.Color.MidnightBlue;
                            FlowerButton.BackgroundColor = Xamarin.Forms.Color.Red;
                            break;
                    }
                });
                return true;
            });
        }


        public void setColor(Xamarin.Forms.Color C)
        {

            touchColor = C;

        }

        private void loadCoords()
        {

            CoordsList.Clear();



            //String destinationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments ), "C:\\Users\\Bugs Bunny 736423\\source\\Flower2XCopy\\Flower1\\Flower1\\TESTCoords.txt");
            //string[] LoadCoordsStringArray = File.ReadAllLines(destinationPath);
            //string[] LoadCoordsStringArray = File.ReadAllLines("..\\TEST1Coords.txt");
            string[] LoadCoordsStringArray = File.ReadAllLines("Test1CoordsTrash.txt");
            for (int i = 0; i < LoadCoordsStringArray.Length; i++)
            {

                Coords loadedNewCoords = new Coords();
                loadedNewCoords.coordsString = LoadCoordsStringArray[i];
                if (loadedNewCoords != null)
                {

                    loadedNewCoords.makeUniformForLoading();
                    loadedNewCoords.makeUniformForSaving();
                    CoordsList.Add(loadedNewCoords);

                }

            }


        }


        private string poo(string inputViewText, double maxValue, int inputLength)
        {


            string s = inputViewText;

            int firstPointIndex = 0;
            // bool isPoint = false;
            IList<char> L1 = new List<char>();
            string str2 = null;



            if (s == null)
                return s = "0";

            switch (inputLength)
            {
                case 0:
                    if (s.Count() > 15)
                        s = s.Substring(0, 15);
                    break;
                case 1:
                    if (s.Count() > 7)
                        s = s.Substring(0, 7);
                    break;
            };

            L1 = s.ToList();
            int j = L1.Count;

            for (int i = 0; i < j; i++)
                if (L1[i] == '.')
                {
                    // isPoint = true;
                    firstPointIndex = i;
                    break;
                }

            for (int b = 0; b < j; b++)
            {
                switch (inputLength)
                {
                    case 0:
                        if (char.IsNumber(L1.First()) || (L1.First() == '.' && b == firstPointIndex))
                        {
                            str2 = str2 + L1.FirstOrDefault();
                            L1.Remove(L1.First());
                        }
                        break;
                    case 1:
                        if (L1.Count != 0)
                            if (char.IsNumber(L1.First()) == true)
                            {
                                str2 = str2 + L1.FirstOrDefault();
                                L1.Remove(L1.First());
                            }
                            else
                                L1.Clear();

                        break;

                };
            }


            if (str2 == "." || str2 == "" || str2 == null)
                str2 = "0.0";
            else
               if (double.Parse(str2) > maxValue)
                str2 = maxValue.ToString();

            return str2;
        }


        private void Button_ClickedNew(object sender, EventArgs e)
        {

            Coords C = new Coords();

            picker1.BackgroundColor = Xamarin.Forms.Color.White;
            picker2.BackgroundColor = Xamarin.Forms.Color.White;
            picker3.BackgroundColor = Xamarin.Forms.Color.White;
            picker4.BackgroundColor = Xamarin.Forms.Color.White;
            C.color1 = Xamarin.Forms.Color.White.ToHex().ToString();
            C.color2 = Xamarin.Forms.Color.White.ToHex().ToString();
            C.color3 = Xamarin.Forms.Color.White.ToHex().ToString();
            C.color4 = Xamarin.Forms.Color.White.ToHex().ToString();

            C.name = "Enter new Design Name";
            EntryName.Text = "Enter new Design Name";
            C.preciseDegrees = "0.0";
            Entry1.Text = "0.0";
            C.degrees = "0.0";
            Entry2.Text = "0.0";
            C.radii = "0.0";
            Entry5.Text = "0.0";
            C.angle = "0.0";
            Entry6.Text = "0.0";
            C.angleLimit = "0.0";
            Entry4.Text = "0.0";
            C.fullScale = "0.0";
            Entry3.Text = "0.0";
            C.cStroke1 = "0";
            Stroke1_Entry.Text = "0";
            C.cStroke2 = "0";
            Stroke2_Entry.Text = "0";
            C.cStroke3 = "0";
            Stroke3_Entry.Text = "0";
            keys.verifyUsedKeys(CoordsList);
            C.key = keys.getNewKey();
            C.isVisible = true;

            C.makeUniformForSaving();
            C.makeUniformForLoading();

            CoordsList.Add(C);

            currentCoords.coordsString = C.coordsString;
            currentCoords.makeUniformForLoading();
            listView1.ScrollTo(C, ScrollToPosition.End, true);

            saveCoordinates();



        }


        private void saveCoordinates()
        {

            Coords[] CoordsArray = CoordsList.ToArray();
            string[] stringArray = new string[CoordsArray.Length];

            for (int i = 0; i < CoordsList.Count; i++)
            {
                CoordsList[i].makeUniformForSaving();
                stringArray[i] = CoordsArray[i].coordsString;
                // File.AppendAllText("saved_coords.txt", CoordsList[i].coordsString);
            }

            IEnumerable<string> slist = new List<string>(stringArray);

            File.Delete("TEST1Coords.txt");
            File.AppendAllLines("TEST1Coords.txt", slist);
            File.Delete("TEST1_Backup_Coords_Data.txt");
            File.AppendAllLines("TEST1_Backup_Coords_Data.txt", slist);
            // File.AppendAllText("saved_coords.txt", currentCoords.coordsString);

            // listView1.VerticalOptions.Alignment = LayoutAlignment.Start;// Center; //Layout HorizontalOptions.Alignment = 
            //listView1.HeightRequest = 750;
            //listView1.ItemsSource = null;
            //listView1.ItemsSource = CoordsList;
            //listView1.Focus();
        }



        private void Button_ClickedDelete(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < CoordsList.Count; i++)
                {
                    try
                    {



                        if (CoordsList[i].key.Equals(((Coords)listView1.SelectedItem).key) == true)
                        {

                            keys.setKeyOpen(CoordsList[i].key);
                            try
                            {
                                CoordsList.RemoveAt(i);
                            }
                            catch
                            {
                                DisplayAlert("Alert", "CoordsList.Remove of listView1.SelectedItem unsuccessful", "OK");
                            }
                            saveCoordinates();

                        }
                    }
                    catch
                    {
                        DisplayAlert("Alert", "Delete unsuccessful at if,Equals, and ListView.SelectedItem statement", "OK");
                    }
                }
            }
            catch
            {
                DisplayAlert("Alert", "Delete unsuccessful", "OK");
            }
        }

        /*private void setKey(int key)
        {
            keyArray[key] = true;    
        }


        private int getKey()
        {
            int key = 0;

            for (int i = 0; i < CoordsList.Count; i++)
            {
             
                    keyArray[CoordsList[i].key] = false;

                
            }
                
            for (int i = 0; i < keyArray.Count(); i++)
               if (keyArray[i])
                {
                    key = i;
                    keyArray[i] = false;
                    break;
                }
            
            return key;
        }*/

        private void Button_ClickedSave(object sender, EventArgs e)
        {

            Coords NewCoords = new Coords();

            RefreshCurrentCoords();
            NewCoords.coordsString = currentCoords.coordsString;
            NewCoords.makeUniformForLoading();
            NewCoords.key = keys.getNewKey();

            CoordsList.Add(NewCoords);
            saveCoordinates();

        }

        private void Button_ClickedSaveAs(object sender, EventArgs e)
        {
            for (int i = 0; i < CoordsList.Count; i++)
            {


                if (CoordsList[i].key.Equals(((Coords)listView1.SelectedItem).key) == true)
                {

                    try
                    {
                        Coords newCoords = new Coords();
                        RefreshCurrentCoords();
                        newCoords.coordsString = currentCoords.coordsString;
                        newCoords.makeUniformForLoading();

                        CoordsList[i] = newCoords;

                        // listView1.SelectedItem = newCoords; 
                        // ((Coords)listView1.SelectedItem).isVisible = true;

                    }
                    catch
                    {
                        DisplayAlert("Alert", "CoordsList.SaveAs listView1.SelectedItem unsuccessful", "OK");
                    }
                    saveCoordinates();

                }


            }



            /*   for (int i = 0; i < CoordsList.Count; i++)
               {
                   if (CoordsList[i].key == ((Coords)listView1.SelectedItem).key)
                   {
                       RefreshCurrentCoords();

                       CoordsList[i].coordsString = currentCoords.coordsString;
                       CoordsList[i].makeUniformForLoading();


                   }

               }

           }
           catch(Exception ex)
           {
               DisplayAlert("Error", "Resave Selected SaveAs Coordinates", "OK");
           }

           saveCoordinates();
           */
        }

        private void ColorSaveAs(string C)
        {
            int j = CoordsList.IndexOf((Coords)listView1.SelectedItem);
            if (j != -1)
            {
                CoordsList[j].color1 = C;
            }
            saveCoordinates();

            //loadCoords();
        }

        private async void ListView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            for (int i = 0; i < CoordsList.Count; i++)
            {

                if (CoordsList[i].key.Equals(((Coords)listView1.SelectedItem).key) == true)
                {

                    currentCoords.coordsString = CoordsList[i].coordsString;
                    currentCoords.makeUniformForLoading();
                    currentCoords.makeUniformForSaving();
                    RefreshCurrentCoordsToGUI();
                }
            }
        }



        /*if (CoordsList[i].key.Equals(((Coords)listView1.SelectedItem).key) == true)
                {
                    char[] coordsStringArray = new char[((Coords)listView1.SelectedItem).coordsString.Length];

                    ((Coords)listView1.SelectedItem).coordsString.CopyTo(0, coordsStringArray, 0, ((Coords)listView1.SelectedItem).coordsString.Length);

                    string s = null;

                    for (int j = 0; j < coordsStringArray.Length; j++)
                    {

                        s = s + coordsStringArray[j];

                    }
                    coordsStringArray[i]
                    currentCoords.coordsString = s;
                    currentCoords.makeUniformForLoading();
                    currentCoords.makeUniformForSaving();
                    RefreshCurrentCoordsToGUI();

                }
                */

        // IEnumerator enumerator = enumerableList.GetEnumerator();
        //currentCoords.coordsString = enumerableList.ToString();








        public void RefreshCurrentCoords()
        {

            SKColor.TryParse(currentCoords.color1, out skColorStroke1);
            SKColor.TryParse(currentCoords.color2, out skColorStroke2);
            SKColor.TryParse(currentCoords.color3, out skColorStroke3);
            SKColor.TryParse(currentCoords.color4, out skColorStroke4);

            currentCoords.color1 = skColorStroke1.ToFormsColor().ToHex().ToString();
            currentCoords.color2 = skColorStroke2.ToFormsColor().ToHex().ToString();
            currentCoords.color3 = skColorStroke3.ToFormsColor().ToHex().ToString();
            currentCoords.color4 = skColorStroke4.ToFormsColor().ToHex().ToString();

            currentCoords.name = EntryName.Text;
            currentCoords.preciseDegrees = poo(Entry1.Text, SliderR.Maximum, 0);
            currentCoords.degrees = poo(Entry2.Text, SliderR2.Maximum, 0);
            currentCoords.radii = poo(Entry5.Text, Slider3.Maximum, 0);
            currentCoords.angle = poo(Entry6.Text, Slider4.Maximum, 0);
            currentCoords.angleLimit = poo(Entry4.Text, Slider2.Maximum, 0);
            currentCoords.fullScale = poo(Entry3.Text, SliderScale.Maximum, 0);
            currentCoords.cStroke1 = (poo(Stroke1_Entry.Text, Slider_Stroke1.Maximum, 1));
            currentCoords.cStroke2 = (poo(Stroke2_Entry.Text, Slider_Stroke2.Maximum, 1));
            currentCoords.cStroke3 = (poo(Stroke3_Entry.Text, Slider_Stroke3.Maximum, 1));

            currentCoords.makeUniformForSaving();


        }

        public async void RefreshCurrentCoordsToGUI()
        {
            try
            {

                currentCoords.makeUniformForLoading();

                //Xamarin.Forms.Color C = new Xamarin.Forms.Color();
                //picker1.BackgroundColor = C.ToHex(currentCoords.color1);

                SKColor.TryParse(currentCoords.color1, out skColorStroke1);
                SKColor.TryParse(currentCoords.color2, out skColorStroke2);
                SKColor.TryParse(currentCoords.color3, out skColorStroke3);
                SKColor.TryParse(currentCoords.color4, out skColorStroke4);



                picker1.BackgroundColor = skColorStroke1.ToFormsColor();
                picker2.BackgroundColor = skColorStroke2.ToFormsColor();
                picker3.BackgroundColor = skColorStroke3.ToFormsColor();
                picker4.BackgroundColor = skColorStroke4.ToFormsColor();

                EntryName.Text = currentCoords.name;
                Entry1.Text = poo(currentCoords.preciseDegrees, SliderR.Maximum, 0);
                Entry2.Text = poo(currentCoords.degrees, SliderR2.Maximum, 0);
                Entry5.Text = poo(currentCoords.radii, Slider3.Maximum, 0);
                Entry6.Text = poo(currentCoords.angle, Slider4.Maximum, 0);
                Entry4.Text = poo(currentCoords.angleLimit, Slider2.Maximum, 0);
                Entry3.Text = poo(currentCoords.fullScale, SliderScale.Maximum, 0);
                Stroke1_Entry.Text = poo(currentCoords.cStroke1, Slider_Stroke1.Maximum, 1);
                Stroke2_Entry.Text = poo(currentCoords.cStroke2, Slider_Stroke2.Maximum, 1);
                Stroke3_Entry.Text = poo(currentCoords.cStroke3, Slider_Stroke3.Maximum, 1);

                // currentCoords.makeUniformForSaving();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert!", "Bongo says in RefreshCurrentCoords method: " + ex.Message, "OK");
            }
        }

        private async void StartFlowerButton_Clicked(object sender, EventArgs e)
        {

            RefreshCurrentCoords();

            SKColor.TryParse(currentCoords.color1, color: out RenderPage.colorStroke1);
            SKColor.TryParse(currentCoords.color2, out RenderPage.colorStroke2);
            SKColor.TryParse(currentCoords.color3, out RenderPage.colorStroke3);
            SKColor.TryParse(currentCoords.color4, out RenderPage.colorStroke4);

            RenderPage.colorStrokeWidth1 = int.Parse(currentCoords.cStroke1);
            RenderPage.colorStrokeWidth2 = int.Parse(currentCoords.cStroke2);
            RenderPage.colorStrokeWidth3 = int.Parse(currentCoords.cStroke3);

            if (degreesFlag == true)
                RenderPage.degree = float.Parse(currentCoords.preciseDegrees);
            else
                RenderPage.degree = float.Parse(currentCoords.degrees);
            RenderPage.radii1 = double.Parse(currentCoords.radii);
            RenderPage.angle = double.Parse(currentCoords.angle);
            RenderPage.angleLimit = double.Parse(currentCoords.angleLimit);
            RenderPage.scale = float.Parse(currentCoords.fullScale);

            await Navigation.PushAsync(RenderPage);
            //await Shell.Current.GoToAsync($"//{nameof(RenderPage)}");


            // int i = 0;
            //  int j = i / 0;

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private async void BackButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        public void fillColor(string C)
        {


            int j = CoordsList.IndexOf((Coords)listView1.SelectedItem);
            if (j != -1)
            {
                CoordsList[j].color1 = C;
            }

        }


        public void Picker_SelectedIndexChanged1(object sender, EventArgs e)
        {

            string str1 = picker1.SelectedItem.ToString();

            foreach (string keyName in nameAndColor.Keys)
                if (keyName.Equals(str1) == true)
                    if (nameAndColor.TryGetValue(str1, out skColorStroke1) == true)
                    {
                        currentCoords.color1 = skColorStroke1.ToFormsColor().ToHex().ToString();
                        picker1.BackgroundColor = skColorStroke1.ToFormsColor();
                        picker1.TextColor = Xamarin.Forms.Color.Transparent;
                        //fillColor(skColorStroke1.ToFormsColor().ToHex().ToString());
                        // listView1.BackgroundColor = skColorStroke1.ToFormsColor();  
                        break;
                    }

            double db = 10d;
            picker1.CharacterSpacing = db;



            picker1Touchable = true;

            if (picker2Touchable == true)
                picker2Touchable = false;

            if (picker3Touchable == true)
                picker3Touchable = false;

            if (picker2Touchable == true)
                picker2Touchable = false;

            // int b = 1;
            // int j = i / 0;


        }

        public void Picker_SelectedIndexChanged2(object sender, EventArgs e)
        {

            string str2 = picker2.SelectedItem.ToString();

            foreach (string keyName in nameAndColor.Keys)
                if (keyName.Equals(str2) == true)
                    if (nameAndColor.TryGetValue(str2, out skColorStroke2) == true)
                    {
                        currentCoords.color2 = skColorStroke2.ToFormsColor().ToHex().ToString();
                        picker2.BackgroundColor = skColorStroke2.ToFormsColor();
                        picker2.TextColor = Xamarin.Forms.Color.Transparent;
                        //fillColor(skColorStroke1.ToFormsColor().ToHex().ToString());
                        //((Coords)listView1.SelectedItem).color1 = skColorStroke2.ToFormsColor().ToHex().ToString();
                        //listView1.BackgroundColor = skColorStroke1.ToFormsColor();  //listView1.RefreshCommand.Execute(null); 
                        //ColorSaveAs(skColorStroke2.ToFormsColor().ToHex().ToString());
                        //loadCoords();

                        break;
                    }



            //listView1.BindingContext = picker1;
            //       listView1.SetBinding(ListView.BackgroundColorProperty, currentCoords.color1);

            //double db = 10d;
            //picker2.CharacterSpacing = db;

            picker2Touchable = true;

            if (picker1Touchable == true)
                picker1Touchable = false;

            if (picker3Touchable == true)
                picker3Touchable = false;

            if (picker4Touchable == true)
                picker4Touchable = false;

        }

        public void Picker_SelectedIndexChanged3(object sender, EventArgs e)
        {

            string str3 = picker3.SelectedItem.ToString();

            foreach (string keyName in nameAndColor.Keys)
                if (keyName.Equals(str3) == true)
                    if (nameAndColor.TryGetValue(str3, out skColorStroke3) == true)
                    {
                        currentCoords.color3 = skColorStroke3.ToFormsColor().ToHex().ToString();
                        picker3.BackgroundColor = skColorStroke3.ToFormsColor();
                        picker3.TextColor = Xamarin.Forms.Color.Transparent;
                        break;
                    }

            double db = 10d;
            picker3.CharacterSpacing = db;

            picker3Touchable = true;

            if (picker1Touchable)
                picker1Touchable = false;

            if (picker2Touchable)
                picker2Touchable = false;

            if (picker4Touchable)
                picker4Touchable = false;

        }

        public void Picker_SelectedIndexChanged4(object sender, EventArgs e)
        {

            string str4 = picker4.SelectedItem.ToString();

            foreach (string keyName in nameAndColor.Keys)
                if (keyName.Equals(str4) == true)
                    if (nameAndColor.TryGetValue(str4, out skColorStroke4) == true)
                    {
                        currentCoords.color4 = skColorStroke4.ToFormsColor().ToHex().ToString();
                        picker4.BackgroundColor = skColorStroke4.ToFormsColor();
                        picker4.TextColor = Xamarin.Forms.Color.Transparent;

                        break;
                    }

            double db = 10d;
            picker4.CharacterSpacing = db;

            picker4Touchable = true;

            if (picker1Touchable == true)
                picker1Touchable = false;

            if (picker2Touchable == true)
                picker2Touchable = false;

            if (picker3Touchable == true)
                picker3Touchable = false;


        }

        private void ColorPicker_PickedColorChanged(object sender, Xamarin.Forms.Color colorPicked)
        {


            if (hasTouched == true)
            {


                if (picker1Touchable == true)
                {
                    picker1.BackgroundColor = colorPicked;
                    picker1.TextColor = Xamarin.Forms.Color.Transparent;
                    currentCoords.color1 = colorPicked.ToHex().ToString();


                }
                else if (picker2Touchable == true)
                {
                    picker2.BackgroundColor = colorPicked;
                    picker2.TextColor = Xamarin.Forms.Color.Transparent;
                    currentCoords.color2 = colorPicked.ToHex().ToString();

                }
                else if (picker3Touchable == true)
                {
                    picker3.BackgroundColor = colorPicked;
                    picker3.TextColor = Xamarin.Forms.Color.Transparent;
                    currentCoords.color3 = colorPicked.ToHex().ToString();

                }

                else if (picker4Touchable == true)
                {
                    picker4.BackgroundColor = colorPicked;
                    picker4.TextColor = Xamarin.Forms.Color.Transparent;
                    currentCoords.color4 = colorPicked.ToHex().ToString();

                }

                hasTouched = false;
            }


        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void picker1_IsEnabled(object sender, FocusEventArgs e)
        {
            foreach (string colorName in nameAndColor.Keys)
                picker1.Items.Add(colorName);


        }

        private void picker2_IsEnabled(object sender, FocusEventArgs e)
        {
            foreach (string colorName in nameAndColor.Keys)
                picker2.Items.Add(colorName);

        }


        private void picker3_IsEnabled(object sender, FocusEventArgs e)
        {
            foreach (string colorName in nameAndColor.Keys)
                picker3.Items.Add(colorName);


        }

        private void picker4_IsEnabled(object sender, FocusEventArgs e)
        {
            foreach (string colorName in nameAndColor.Keys)
                picker4.Items.Add(colorName);


        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        /* public class FormattedNumberEntry : Entry
         {
             protected override void OnPropertyChanged(string propertyName = null)
             {
                 if (nameof(this.Text).Equals(propertyName))
                 {
                     // if (!_shouldReactToTextChange) return;

                     // _shouldReactToTextChange = false;

                     var oldText = this.Text;
                     //var number = DumbParse(oldText);
                     // var newText = $"{number:#,###}";

                     //this.Text = newText;

                     // _shouldReactToTextChange = true;
                 }
                 base.OnPropertyChanged(propertyName);
             }
         }

         */


        /*private void Entry1_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            currentCoords.preciseDegrees = Entry1.ToString();

            degreesFlag = true;
        }

        private void Entry2_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            currentCoords.degrees = Entry2.ToString();

            degreesFlag = false;
        }
        */
        public bool degreesFlag = false;
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            currentCoords.preciseDegrees = poo(Entry1.Text, Slider_Stroke1.Maximum, 1);

            degreesFlag = true;
        }

        private void Entry1_TextChanged(object sender, TextChangedEventArgs e)
        {

            currentCoords.degrees = poo(Entry2.Text, Slider_Stroke1.Maximum, 1);

            degreesFlag = false;
        }
        private void Stroke1_TextChanged(object sender, TextChangedEventArgs e)
        {

            currentCoords.cStroke1 = Stroke1_Entry.Text;
        }

        private void Stroke2_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentCoords.cStroke2 = Stroke2_Entry.Text;

        }

        private void Stroke3_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentCoords.cStroke3 = Stroke3_Entry.Text;


        }

        private void Entry2_TextChanged(object sender, EventArgs e)
        {


            currentCoords.fullScale = Entry3.Text;

        }

        private void Entry4_TextChanged(object sender, TextChangedEventArgs e)
        {

            currentCoords.angleLimit = Entry4.Text;

        }

        private void Entry5_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentCoords.radii = Entry5.Text;
        }
        private void Entry6_TextChanged(object sender, TextChangedEventArgs e)
        {

            currentCoords.angle = Entry6.Text;

        }

        private void EntryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EntryName.Text == "" || EntryName.Text == ".")
                return;

            currentCoords.name = EntryName.Text;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void SliderStroke1_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            currentCoords.cStroke1 = ((int)Math.Round(e.NewValue)).ToString();
            // Entry1.Text = currentCoords.cStroke1;
        }

        private void SliderStroke2_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            currentCoords.cStroke2 = ((int)Math.Round(e.NewValue)).ToString();

        }

        private void SliderStroke3_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            currentCoords.cStroke3 = ((int)Math.Round(e.NewValue)).ToString();
            // int i = (int)e.NewValue;
            // currentCoords.cStroke3 = i.ToString();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            currentCoords.preciseDegrees = e.NewValue.ToString();

            //degreesFlag = true;
            //  Entry1.Text = e.NewValue.ToString();
        }

        private void SliderR2_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            currentCoords.degrees = e.NewValue.ToString();

            // degreesFlag = false;
            //   Entry2.Text = e.NewValue.ToString();
        }

        private void Slider2_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            currentCoords.angleLimit = e.NewValue.ToString();
            // Entry4.Text = e.NewValue.ToString();
        }

        private void SliderScale_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            currentCoords.fullScale = e.NewValue.ToString();
            //Entry3.Text = e.NewValue.ToString();

        }

        private void Slider3_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            currentCoords.radii = e.NewValue.ToString();

        }

        private void Slider4_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //currentCoords.angle = e.NewValue.ToString();
            //int i = (int)e.NewValue;
            //currentCoords.angle = i.ToString();
            currentCoords.angle = e.NewValue.ToString();
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            picker1Touchable = true;
            picker2Touchable = false;
            picker3Touchable = false;
            picker4Touchable = false;

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            picker2Touchable = true;
            picker1Touchable = false;
            picker3Touchable = false;
            picker4Touchable = false;
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            picker3Touchable = true;
            picker1Touchable = false;
            picker2Touchable = false;
            picker4Touchable = false;
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            picker4Touchable = true;
            picker3Touchable = false;
            picker1Touchable = false;
            picker2Touchable = false;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Dictionary<string, SKColor> nameAndColor = new Dictionary<string, SKColor>
        {
                { "Aqua", SKColors.Aqua },
                { "Black", SKColors.Black },
                { "Blue", SKColors.Blue },
                { "Fuchsia", SKColors.Fuchsia },
                { "Gray", SKColors.Gray },
                { "Green", SKColors.Green },
                { "Lime", SKColors.Lime },
                { "Maroon", SKColors.Maroon },
                { "Navy", SKColors.Navy },
                { "Olive", SKColors.Olive },
                { "Purple", SKColors.Purple },
                { "Red", SKColors.Red },
                { "Silver", SKColors.Silver },
                { "Teal", SKColors.Teal },
                { "White", SKColors.White },
                { "Yellow", SKColors.Yellow },
                { "Turquois", SKColors.Turquoise },
                { "DarkTurquois", SKColors.DarkTurquoise },
                { "Pink", SKColors.Pink },
                { "Indigo", SKColors.Indigo },
                { "Orange", SKColors.Orange },
        };


    }
}




/*  private void Stroke1_Entry_Completed(object sender, EventArgs e)
        {

        }

        private void Stroke1_Entry_Focused(object sender, EventArgs e)
        {
            int i = (int)e.
            Stroke1_Entry.Text = (int)e.ToString();
            currentCoords.angle = i.ToString();
            integersOnlyBehavior.OnAttachedTo();
        }*/


/*void OnEntryTextChanged(object sender, TextChangedEventArgs e)
{
    string oldText = e.OldTextValue;
    string newText = e.NewTextValue;
}

void OnEntryCompleted(object sender, EventArgs e)
{
    string text = ((Entry)sender).Text;
}


public class IntegersOnlyBehavior : Behavior<Entry>
{


    public Action<Entry, string> AdditionalCheck;

    protected override void OnAttachedTo(Entry bindable)
    {
        base.OnAttachedTo(bindable);

        bindable.TextChanged += TextChanged_Handler;
    }

    protected override void OnDetachingFrom(Entry bindable)
    {
        base.OnDetachingFrom(bindable);
    }

    public virtual void TextChanged_Handler(object sender, TextChangedEventArgs e)
    {




      // Entry6.Text =  e.NewTextValue.ToString();








         if (string.IsNullOrEmpty(e.NewTextValue))
        {
            ((Entry)sender).Text = 0.ToString();
            return;
        }

        double _;
        if (!double.TryParse(e.NewTextValue, out _))
            ((Entry)sender).Text = e.OldTextValue;
        else
            AdditionalCheck?.Invoke(((Entry)sender), e.OldTextValue);
    }
}
}
/*
   string s1;
   private int foo(string stroke, double maxValue)
   {



       s1 = stroke;
       IList<char> L1 = s.ToList();
       string str2 = null;
       int j = L1.Count;

       if (s1.Count() > 7)
           s1 = s1.Substring(0,7);

       L1 = s1.ToList();

       if (s1 != null)
       {
           for (int b = 0; b < j; b++)
           {
               if (char.IsNumber(L1.First()))
                   str2 = str2 + L1.FirstOrDefault();

               L1.Remove(L1.First());
           }

           if (str2 == "" || str2 == null)
               str2 = "0";

           if (double.Parse(str2) > maxValue)
               str2 = maxValue.ToString();

           return int.Parse(str2);
       }
       else
       if (s1 == "")
           s1 = "0";

       if (double.Parse(s1) > maxValue)
           s1 = maxValue.ToString();


       return int.Parse(s1);

   }
   */
/*private async void listView1_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Coords currentCoords = new Coords();
        currentCoords = (Coords)listView1.SelectedItem;
        currentCoords.makeUniformForLoading();
        await DisplayAlert("Tapped New Coord: ", currentCoords.Name, "ok");


        ///  await DisplayAlert("Boink", "Bongo says error at handler ListView_ItemTapped", "OK");





        SKColor.TryParse(currentCoords.color1, out skColorStroke1);
        SKColor.TryParse(currentCoords.color2, out skColorStroke2);
        SKColor.TryParse(currentCoords.color3, out skColorStroke3);
        SKColor.TryParse(currentCoords.color4, out skColorStroke4);

        picker1.BackgroundColor = skColorStroke1.ToFormsColor();
        picker2.BackgroundColor = skColorStroke2.ToFormsColor();
        picker3.BackgroundColor = skColorStroke3.ToFormsColor();
        picker4.BackgroundColor = skColorStroke4.ToFormsColor();


        EntryName.Text = currentCoords.Name;
        Entry1.Text = currentCoords.degrees;
        Entry2.Text = currentCoords.degrees;
        Entry5.Text = currentCoords.radii;
        Entry7.Text = currentCoords.radiiLimit;
        Entry6.Text = currentCoords.angle;
        Entry4.Text = currentCoords.angleLimit;
        Entry3.Text = currentCoords.fullScale;
        Stroke1_Entry.Text = currentCoords.cStroke1;
        Stroke2_Entry.Text = currentCoords.cStroke2;
        Stroke3_Entry.Text = currentCoords.cStroke3;

        listView1.ItemsSource = CoordsList;
    }*//*
if (CoordsList[i].key.Equals(((Coords)listView1.SelectedItem).key) == true)
{
    //char[] coordsStringArray = new char[((Coords)listView1.SelectedItem).coordsString.Length];

    IList<char> iList = ((Coords)listView1.SelectedItem).coordsString.ToArray<char>();


    IEnumerable<char> enumerableList = new List<char>(iList);
    enumerableList = ((Coords)listView1.SelectedItem).coordsString.ToList();


                    //((Coords)listView1.SelectedItem).coordsString.CopyTo(0, coordsStringArray, 0, ((Coords)listView1.SelectedItem).coordsString.Length);

//string s = null;

/*for (int j = 0; j < coordsStringArray.Length; j++)
{

    s = s + coordsStringArray[j];

}*/