using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//using Flower1.Views;

//using Flower1.Models;

namespace FlowerApp2.Views
{
   
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class Coords : INotifyPropertyChanged
        {

            public Coords()
            {
                //InitializeComponent();


                name = "Enter new Design Name";
                color1 = "#ffff0000";
                color2 = "#ffff0000";                        // width = "2000";                                                                             
                color3 = "#ffff0000";
                color4 = "#FFFFFFFF";
                cStroke1 = "10";
                cStroke2 = "10";
                cStroke3 = "10";
                preciseDegrees = "3.0";
                degrees = "3.0";
                radii = "10.0";
                radiiLimit = "360.0";
                angle = "10";
                angleLimit = "1080";
                fullScale = "0.5";
                coordsString = "None                                    #ffff0000      #ffff0000      #ffff0000      #ffffffff      3.0            3.0            10.0           360.0          10             1080           0.5     3      3      3      0  true ";
                key = 0;
                isVisible = true;

            }

            public Coords(KeyChain K)
            {
                name = "Enter New Design Name";
                color1 = "#ffff0000";
                color2 = "#ffff0000";                        // width = "2000";                                                                             
                color3 = "#ffff0000";
                color4 = "#FFFFFFFF";
                cStroke1 = "10";
                cStroke2 = "10";
                cStroke3 = "10";
                preciseDegrees = "3.0";
                degrees = "3.0";
                radii = "10.0";
                radiiLimit = "360.0";
                angle = "10";
                angleLimit = "1080";
                fullScale = "0.5";
                coordsString = "None                                    #ffff0000      #ffff0000      #ffff0000      #ffffffff      3.0            3.0            10.0           360.0          10             1080           0.5     3      3      3      0  true ";
                key = K.getNewKey();
                isVisible = true;

            }

            public Coords(string coord)
            {
                coordsString = coord;
                makeUniformForLoading();
                makeUniformForSaving();


            }

            public Coords(Coords C)
            {
                coordsString = C.CoordsString;
                makeUniformForLoading();
                makeUniformForSaving();
            }



            public event PropertyChangedEventHandler PropertyChanged;  // = delegate { };

            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private string Name;
            public string name
            {
                get { return Name; }
                set
                {
                    Name = value;
                    NotifyPropertyChanged("name");
                }
            }

            private string Color1;
            public string color1
            {
                get { return Color1; }
                set
                {
                    Color1 = value;
                    NotifyPropertyChanged("color1");
                }
            }


            private string Color2;
            public string color2
            {
                get { return Color2; }
                set
                {
                    Color2 = value;
                    NotifyPropertyChanged("color2");
                }
            }


            private string Color3;
            public string color3
            {
                get { return Color3; }
                set
                {
                    Color3 = value;
                    NotifyPropertyChanged("color3");
                }
            }


            private string Color4;
            public string color4
            {
                get { return Color4; }
                set
                {
                    Color4 = value;
                    NotifyPropertyChanged("color4");
                }
            }

            private bool IsVisible;
            public bool isVisible
            {
                get { return IsVisible; }
                set
                {
                    IsVisible = value;
                    NotifyPropertyChanged("isVisible");
                }
            }


            private int Key;
            public int key
            {
                get { return Key; }
                set
                {
                    Key = value;
                    NotifyPropertyChanged("keyChain");
                }
            }



            private string PreciseDegrees;
            public string preciseDegrees
            {
                get { return PreciseDegrees; }
                set
                {
                    PreciseDegrees = value;
                    NotifyPropertyChanged("preciseDegrees");
                }
            }


            private string Degrees;
            public string degrees
            {
                get { return Degrees; }
                set
                {
                    Degrees = value;
                    NotifyPropertyChanged("degrees");
                }
            }


            private string Radii;
            public string radii
            {
                get { return Radii; }
                set
                {
                    Radii = value;
                    NotifyPropertyChanged("radii");
                }
            }


            private string RadiiLimit;
            public string radiiLimit
            {
                get { return RadiiLimit; }
                set
                {
                    RadiiLimit = value;
                    NotifyPropertyChanged("radiiLimit");
                }
            }


            private string Angle;
            public string angle
            {
                get { return Angle; }
                set
                {
                    Angle = value;
                    NotifyPropertyChanged("angle");
                }
            }


            private string AngleLimit;
            public string angleLimit
            {
                get { return AngleLimit; }
                set
                {
                    AngleLimit = value;
                    NotifyPropertyChanged("angleLimit");
                }
            }


            private string FullScale;
            public string fullScale
            {
                get { return FullScale; }
                set
                {
                    FullScale = value;
                    NotifyPropertyChanged("fullScale");
                }
            }



            private string CStroke1;
            public string cStroke1
            {
                get { return CStroke1; }
                set
                {
                    CStroke1 = value;
                    NotifyPropertyChanged("cStroke1");
                }
            }



            private string CStroke2;
            public string cStroke2
            {
                get { return CStroke2; }
                set
                {
                    CStroke2 = value;
                    NotifyPropertyChanged("cStroke2");
                }
            }


            private string CStroke3;
            public string cStroke3
            {
                get { return CStroke3; }
                set
                {
                    CStroke3 = value;
                    NotifyPropertyChanged("cStroke3");
                }
            }

            private string CoordsString;
            public string coordsString
            {
                get { return CoordsString; }
                set
                {
                    CoordsString = value;
                    NotifyPropertyChanged("coordsString");
                }
            }

            // public override string ToString()
            // {
            //     makeUniformForSaving();
            //     return coordsString.ToString();
            // }

            public void makeUniformForLoading()
            {
                string UnTrimmedString;

                if (coordsString != null)
                {

                    UnTrimmedString = coordsString.Substring(0, 40);
                    name = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(40, 15);
                    color1 = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(55, 15);
                    color2 = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(70, 15);
                    color3 = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(85, 15);
                    color4 = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(100, 15);
                    preciseDegrees = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(115, 15);
                    degrees = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(130, 15);
                    radii = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(145, 15);
                    radiiLimit = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(160, 15);
                    angle = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(175, 15);
                    angleLimit = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(190, 7);
                    fullScale = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(197, 7);
                    cStroke1 = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(204, 7);
                    cStroke2 = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(211, 7);
                    cStroke3 = UnTrimmedString.Trim();
                    UnTrimmedString = coordsString.Substring(218, 3);
                    key = int.Parse(UnTrimmedString.Trim());
                    UnTrimmedString = coordsString.Substring(221, 5);
                    isVisible = bool.Parse(UnTrimmedString.Trim());
                }
            }



            public void makeUniformForSaving()
            {
                coordsString = null;

                coordsString += name.PadRight(40);
                coordsString += color1.PadRight(15);
                coordsString += color2.PadRight(15);
                coordsString += color3.PadRight(15);
                coordsString += color4.PadRight(15);
                coordsString += preciseDegrees.PadRight(15);
                coordsString += degrees.PadRight(15);
                coordsString += radii.PadRight(15);
                coordsString += radiiLimit.PadRight(15);
                coordsString += angle.PadRight(15);
                coordsString += angleLimit.PadRight(15);
                coordsString += fullScale.PadRight(7);
                coordsString += cStroke1.ToString().PadRight(7);
                coordsString += cStroke2.ToString().PadRight(7);
                coordsString += cStroke3.ToString().PadRight(7);
                coordsString += key.ToString().PadRight(3);
                coordsString += isVisible.ToString().PadRight(5);
            }

        }



        public partial class TempoCoords : Coords
        {
            public string tempo { get; set; }
            public TempoCoords()
            {
                tempo = "0";
            }

            public void makeUniformForLoading()
            {
                string UnTrimmedString;
                base.makeUniformForLoading();
                UnTrimmedString = coordsString.Substring(226, 5);
                tempo = UnTrimmedString.Trim();
            }

            public void makeUniformForSaving()
            {
                base.makeUniformForSaving();
                coordsString += tempo.ToString().PadRight(5);
            }
        }
}

/*
 <?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Flower1.Views.SetupPage"
             xmlns:skia="clr-namespace:SkiaSharp.Views.Forms;assembly=SkiaSharp.Views.Forms"
             xmlns:local="clr-namespace:Flower1.Views"  
             xmlns:model="clr-namespace:Flower1.Models"  
      
             xmlns:behavior="clr-namespace:Flower1.Views;assembly=Flower1"
             xmlns:controls="clr-namespace:Flower1.Controls;assembly=Flower1"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006">

    <ContentPage.Content>

        <StackLayout Padding="10,10,0,0" Orientation="Horizontal" >
            <Grid x:Name="Grid1" Padding="5,0,15,0">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="500" />
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height="355" />
                    <RowDefinition Height="0" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="35" />
                    <RowDefinition Height="40" />
                    <RowDefinition Height="35" />
                    <RowDefinition Height="40" />
                    <RowDefinition Height="35" />
                    <RowDefinition Height="35" />
                    <RowDefinition Height="35" />
                    <RowDefinition Height="35" />
                    <RowDefinition Height="35" />
                    <RowDefinition Height="35" />
                    <RowDefinition Height="20" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30"/>
                    <RowDefinition Height="25"/>
                    <RowDefinition Height="35"/>
                    <RowDefinition Height="35"/>
                    <RowDefinition Height="35"/>
                </Grid.RowDefinitions>

                <StackLayout    Grid.Row="0" Grid.Column="0"       
                    Orientation="Vertical"
                    VerticalOptions="Start"
                    HorizontalOptions="Start">
                    <Frame 
                     x:Name="ColorPickerHolderFrame"        
                     HeightRequest="300"
                     HorizontalOptions="Center"
                     WidthRequest="525"                        
                        
                    CornerRadius="0" >

                        <controls:ColorPicker
                         x:Name="ColorPicker"
                         ColorListDirection="Horizontal"
                         GradientColorStyle="DarkToColorsToLightStyle"
                    
                        PickedColorChanged="ColorPicker_PickedColorChanged"
                        PointerCircleBorderUnits="0.4"
                        PointerCircleDiameterUnits="0.8">
                            <!--BindingContextChanged="ColorPicker_BindingContextChanged"> -->
                            <controls:ColorPicker.ColorList>
                                <x:Array Type="{x:Type x:String}">
                                    <!--  Red  -->
                                    <x:String>#ff0000</x:String>
                                    <!--  Yellow  -->
                                    <x:String>#ffff00</x:String>
                                    <!--  Green (Lime)  -->
                                    <x:String>#00ff00</x:String>
                                    <!--  Aqua  -->
                                    <x:String>#00ffff</x:String>
                                    <!--  Blue  -->
                                    <x:String>#0000ff</x:String>
                                    <!--  Fuchsia  -->
                                    <x:String>#ff00ff</x:String>
                                    <!--  Red  -->
                                    <x:String>#ff0000</x:String>
                                </x:Array>
                            </controls:ColorPicker.ColorList>
                        </controls:ColorPicker>
                    </Frame>
                </StackLayout>

                <Label Text="Select Color 1" Grid.Row="2" TextColor="White" VerticalTextAlignment="End" />
                <Button Text="Choose Color" BackgroundColor="Silver" HorizontalOptions="End" VerticalOptions="End" IsEnabled="True"  Clicked="Button_Clicked_1" Grid.Row="2" />
                <Picker x:Name="picker1"  Grid.Column="0" Grid.Row="3"  Focused="picker1_IsEnabled" SelectedIndexChanged="Picker_SelectedIndexChanged1" ItemsSource="{Binding nameAndColor}" />
                <Label Text="Select Color2"  Grid.Column="0" Grid.Row="4" TextColor="White" VerticalTextAlignment="End"/>
                <Button Text="Choose Color" BackgroundColor="Silver" HorizontalOptions="End" VerticalOptions="End" IsEnabled="True" Clicked="Button_Clicked_2" Grid.Row="4" />
                <Picker x:Name="picker2"  Grid.Column="0" Grid.Row="5"  Focused="picker2_IsEnabled" SelectedIndexChanged="Picker_SelectedIndexChanged2" ItemsSource="{Binding nameAndColor}" />
                <Label Text="Select Color 3" Grid.Column="0" Grid.Row="6" TextColor="White" VerticalTextAlignment="End"/>
                <Button Text="Choose Color" BackgroundColor="Silver" HorizontalOptions="End" VerticalOptions="End" IsEnabled="True" Clicked="Button_Clicked_3" Grid.Row="6" />
                <Picker x:Name="picker3"  Grid.Column="0" Grid.Row="7"  Focused="picker3_IsEnabled" SelectedIndexChanged="Picker_SelectedIndexChanged3" ItemsSource="{Binding nameAndColor}" />
                <Label Text="Select BackGround Color" Grid.Column="0" Grid.Row="8" TextColor="White" VerticalTextAlignment="End"/>
                <Button Text="Choose Color" BackgroundColor="Silver" HorizontalOptions="End" VerticalOptions="End" IsEnabled="True" Clicked="Button_Clicked_4" Grid.Row="8" />
                <Picker x:Name="picker4"  Grid.Column="0" Grid.Row="9"  Focused="picker4_IsEnabled" SelectedIndexChanged="Picker_SelectedIndexChanged4" ItemsSource="{Binding nameAndColor}" />

                <Grid x:Name="Grid2" Grid.Row="10">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="163" />
                        <ColumnDefinition Width="163" />
                        <ColumnDefinition Width="162" />
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="35" />
                        <RowDefinition Height="35" />
                        <RowDefinition Height="35" />
                    </Grid.RowDefinitions>

                    <Label Text="Enter Stroke Width of Color 1:" TextColor="White" Grid.Row="0" Grid.Column="0" />
                    <Entry x:Name="Stroke1_Entry" Placeholder="{Binding Path=Value}" TextChanged="Stroke1_TextChanged" BindingContext="{x:Reference Slider_Stroke1}" Text="{Binding Path=Value}" Grid.Row="1" Grid.Column="0" 
                          IsEnabled="True" />
                    <Slider x:Name="Slider_Stroke1" Minimum="0" Maximum="100" ValueChanged="SliderStroke1_ValueChanged" Value="1" Grid.Row="2" Grid.Column="0"  />

                    <Label Text="Enter Stroke Width of Color 2: " TextColor="White"  Grid.Row="0" Grid.Column="1" />
                    <Entry x:Name="Stroke2_Entry" TextChanged="Stroke2_TextChanged"  BindingContext="{x:Reference Name=Slider_Stroke2}" Text="{Binding Path=Value}"   Grid.Row="1" Grid.Column="1" IsTextPredictionEnabled="True"/>
                    <Slider x:Name="Slider_Stroke2" Minimum="0" Maximum="100"   ValueChanged="SliderStroke2_ValueChanged" Value="1"  Grid.Row="2" Grid.Column="1" />

                    <Label Text="Enter Stroke Width of Color 3:" TextColor="White" Grid.Row="0" Grid.Column="2" />
                    <Entry x:Name="Stroke3_Entry" TextChanged="Stroke3_TextChanged"  Grid.Row="1" Grid.Column="2" BindingContext="{x:Reference Name=Slider_Stroke3}"  Text="{Binding Path=Value}" />
                    <Slider x:Name="Slider_Stroke3" Minimum="0" Maximum="100"   ValueChanged="SliderStroke3_ValueChanged" Value="1"  Grid.Row="2" Grid.Column="2"/>

                </Grid>
            </Grid>
            <Grid x:Name="Grid3" HorizontalOptions="Start" Padding="20,0,0,0">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="140" />
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height="0" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="60" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                    <RowDefinition Height="30" />
                </Grid.RowDefinitions>

                <Label Text="Enter Name:" Grid.Column="0" Grid.Row="1" TextColor="White" VerticalTextAlignment="End"/>
                <Entry x:Name="EntryName" TextChanged="EntryName_TextChanged" Text="No Name" Grid.Column="0" Grid.Row="2" MaxLength="40" />

                <Label Text="Enter Precise Degrees up to 3.0: " TextColor="White"  Grid.Row="3" Grid.Column="0" VerticalTextAlignment="End"/>
                <Entry x:Name="Entry1" 
                        BindingContext="{x:Reference Name=SliderR}" Text="{Binding Path=Value}"   Grid.Row="4" Grid.Column="0" />
                <Slider  x:Name="SliderR" Minimum="0.00" Maximum="3.00" ValueChanged="Slider_ValueChanged" Value="0" Grid.Row="5" Grid.Column="0"/>

                <Label Text="Enter Degrees: " TextColor="White"  Grid.Column="0" Grid.Row="6" VerticalTextAlignment="End"/>
                <Entry x:Name="Entry2" 
                        BindingContext="{x:Reference Name=SliderR2}" Text="{Binding Path=Value}"  Grid.Column="0" Grid.Row="7" />
                <Slider x:Name="SliderR2" Minimum="0.0" Maximum="7000.0" ValueChanged="SliderR2_ValueChanged" Value="0" Grid.Column="0" Grid.Row="8"  />

                <Label Text="Enter Radii: " TextColor="White" Grid.Column="0" Grid.Row="9" VerticalTextAlignment="End"/>
                <Entry x:Name="Entry5" TextChanged="Entry5_TextChanged" IsTextPredictionEnabled="True" 
                      BindingContext="{x:Reference Name=Slider3}" Text="{Binding Path=Value}"  Grid.Column="0" Grid.Row="10" />
                <Slider x:Name="Slider3"  Minimum="0" Maximum="30000" ValueChanged="Slider3_ValueChanged"  Value="0" Grid.Column="0" Grid.Row="11"/>

                <Label Text="Enter Angle: " TextColor="White" Grid.Row="12" VerticalTextAlignment ="End" />
                <Entry x:Name="Entry6" TextChanged="Entry6_TextChanged" BindingContext="{x:Reference Name=Slider4}"  Text="{Binding Path=Value}" Grid.Row="13"/>
                <Slider x:Name="Slider4" Minimum="0.0" Maximum="360.0" ValueChanged="Slider4_ValueChanged" Value="0" Grid.Row="14"/>

                <Label Text="Enter Angle Index:" TextColor="White" Grid.Row="15" VerticalTextAlignment="End"/>
                <Entry x:Name="Entry4" TextChanged="Entry4_TextChanged" BindingContext="{x:Reference Name=Slider2}" Text="{Binding Path=Value}" Grid.Row="16" />
                <Slider x:Name="Slider2" Minimum="0.00" Maximum="7000.00" ValueChanged="Slider2_ValueChanged" Value="0" Grid.Row="17" />

                <Label Text="Enter Scale:" TextColor="White" Grid.Column="0" Grid.Row="18"  VerticalTextAlignment="End"/>
                <Entry x:Name="Entry3" TextChanged="Entry2_TextChanged" 
                        BindingContext="{x:Reference Name=SliderScale}" Text="{Binding Path=Value}"  Grid.Column="0" Grid.Row="19" />
                <Slider x:Name="SliderScale"  Minimum="0.00" Maximum="10.00" ValueChanged="SliderScale_ValueChanged" Value="0" Grid.Column="0" Grid.Row="20" />

            </Grid>

            <Grid x:Name="Grid4" Padding="35,0,0,0">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="1070" />
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height="50" />
                    <RowDefinition Height="50" />
                    <RowDefinition Height="50" />
                    <RowDefinition Height="50" />
                    <RowDefinition Height="50" />
                    <RowDefinition Height="650" />
                </Grid.RowDefinitions>
                <Button x:Name="ButtonNew" Text="New Coordinates" TextColor="DarkBlue" Clicked="Button_ClickedNew"  BackgroundColor="Turquoise" Grid.Column="0" Grid.Row="0"/>
                <Button x:Name="Button3" Text="Save Coordinates" TextColor="DarkBlue"  Clicked="Button_ClickedSave"  BackgroundColor="Pink" Grid.Column="0" Grid.Row="1"/>
                <Button x:Name="Button4" Text="Save Selected Coordinates" TextColor="DarkBlue"  Clicked="Button_ClickedSaveAs" BackgroundColor="PaleGoldenrod" Grid.Column="0" Grid.Row="2" />
                <Button x:Name="ButtonDelete" Text="Delete Coordinates" TextColor="DarkBlue"  Clicked="Button_ClickedDelete" BackgroundColor="LightGreen" Grid.Column="0" Grid.Row="3" />
                <Label TextColor="White"   Text="Name                                      Color 1      Color 2      Color 3    Back Color     Degrees        Radii           Angle       AngleIndex       Scale         Stroke1    Stroke2    Stroke3" FontAttributes="Bold"  Grid.Column="0" Grid.Row="4" />
                <ListView x:Name="listView1" ItemsSource="{Binding CoordsList}" Grid.Column="0" Grid.Row="5" ItemSelected="ListView1_ItemSelected" SeparatorColor="Yellow" IsVisible="{Binding isVisible}" >
                    <ListView.ItemTemplate>
                        <DataTemplate>
                            <ViewCell>
                                <Grid Padding="0,10,10,0"
                                RowDefinitions="Auto">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="180"/>
                                        <ColumnDefinition Width="61"/>
                                        <ColumnDefinition Width="62"/>
                                        <ColumnDefinition Width="62"/>
                                        <ColumnDefinition Width="62"/>
                                        <ColumnDefinition Width="35"/>
                                        <ColumnDefinition Width="70"/>
                                        <ColumnDefinition Width="70"/>
                                        <ColumnDefinition Width="65"/>
                                        <ColumnDefinition Width="90"/>
                                        <ColumnDefinition Width="70"/>
                                        <ColumnDefinition Width="55"/>
                                        <ColumnDefinition Width="65"/>
                                        <ColumnDefinition Width="20"/>
                                    </Grid.ColumnDefinitions>
                                    <Label Text="{Binding name}" TextColor="White" Grid.Column="0" />
                                    <BoxView Color="{Binding color1}" Grid.Column="1" />
                                    <BoxView Color="{Binding color2}" Grid.Column="2"/>
                                    <BoxView Color="{Binding color3}" Grid.Column="3"/>
                                    <BoxView Color="{Binding color4}" Grid.Column="4"/>
                                    <Label Text="     "  Grid.Column="5"/>
                                    <Label Text="{Binding degrees}" TextColor="White" Grid.Column="6"/>
                                    <Label Text="{Binding radii}" TextColor="White" Grid.Column="7"/>
                                    <Label Text="{Binding angle}" TextColor="White" Grid.Column="8"/>
                                    <Label Text="{Binding angleLimit}" TextColor="White" Grid.Column="9"/>
                                    <Label Text="{Binding fullScale}" TextColor="White" Grid.Column="10"/>
                                    <Label Text="{Binding cStroke1}" TextColor="White" Grid.Column="11"/>
                                    <Label Text="{Binding cStroke2}" TextColor="White" Grid.Column="12"/>
                                    <Label Text="{Binding cStroke3}" TextColor="White" Grid.Column="13"/>
                                </Grid>
                            </ViewCell>
                        </DataTemplate>
                    </ListView.ItemTemplate>
                </ListView>
            </Grid>
            <StackLayout  Padding="10,0,20,30">
                <Button x:Name="FlowerButton" Text="StartFlower"  TextColor="DarkBlue" VerticalOptions="FillAndExpand" HorizontalOptions="StartAndExpand"  Clicked="StartFlowerButton_Clicked"  BackgroundColor="White"/>
            </StackLayout>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>

*/