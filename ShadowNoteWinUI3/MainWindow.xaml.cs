using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ShadowNoteWinUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        private AppWindow _apw;
        private OverlappedPresenter _presenter;
        public MainWindow()
        {
            this.InitializeComponent();
            this.ViewModel = new NotepadModel();

            GetAppWindowAndPresenter();
            _presenter.IsMaximizable = false;
            _presenter.IsMinimizable = false;
            _presenter.IsAlwaysOnTop = true;
            _presenter.IsResizable = false;
            _presenter.SetBorderAndTitleBar(false, false);

            //ExtendsContentIntoTitleBar = true;
        }

        public NotepadModel ViewModel { get; set; }

        public void GetAppWindowAndPresenter()
        {
            var hWind = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId winID = Win32Interop.GetWindowIdFromWindow(hWind);
            _apw = AppWindow.GetFromWindowId(winID);
            _apw.Title = "";
            //_apw.IsShownInSwitchers = false;
            //_apw.Resize(new Windows.Graphics.SizeInt32((int)Bounds.Width,(int)Bounds.Height/2)); //This is set to 1920x1080 on my 1440p monitor?
            _apw.Resize(new Windows.Graphics.SizeInt32(2560,720));
            _apw.Move(new Windows.Graphics.PointInt32(0,0));

            _presenter = _apw.Presenter as OverlappedPresenter;
        }

        private void NoteGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NoteGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void formatButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newNoteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    // CustomDataObject class definition
    public class Notepad
    {
        public string Title { get; set; }
        public string NoteText { get; set; }

        public Notepad() { }
    }

    public class NotepadModel
    {
        private Notepad defaultNotepad = new Notepad();
        public Notepad DefaultNotepad { get { return this.defaultNotepad; } }
        private ObservableCollection<Notepad> notes = new ObservableCollection<Notepad>();
        public ObservableCollection<Notepad> Notes { get { return this.notes; } }
        public NotepadModel() 
        {
            this.notes.Add(new Notepad() { Title = "test", NoteText = "testing notepad" });
            this.notes.Add(new Notepad() { Title = "test2", NoteText = "testing notepad" });
        }

    }

}
