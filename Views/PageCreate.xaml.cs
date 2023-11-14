namespace RestApiMaui.Views;

public partial class PageCreate : ContentPage
{
    FileResult photo;

    public PageCreate()
	{
		InitializeComponent();
	}

    public String Getimage64()
    {
        if (photo != null)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Stream stream = null; //photo.GetStream();
                stream.CopyTo(memory);
                byte[] fotobyte = memory.ToArray();

                String Base64 = Convert.ToBase64String(fotobyte);

                return Base64;
            }
        }

        return null;
    }


    public byte[] GetByteArray()
    {
        if (photo != null)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Stream stream = null; //photo.GetStream();
                stream.CopyTo(memory);
                byte[] fotobyte = memory.ToArray();

            
                return fotobyte;
            }
        }

        return null;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var emple = new Models.Empleado
        {
            nombres = nombresEntry.Text,
            apellidos = apellidosEntry.Text,
            fechanac = fechaNacEntry.Text,
            correo = correoEntry.Text,
            foto = GetByteArray()
        };

        Models.Msg msg = await Controllers.EmpleController.CreateEmple(emple);

        if (msg != null)
        {
            await DisplayAlert("Aviso", msg.message.ToString(), "OK");
        }

    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        photo = await MediaPicker.Default.CapturePhotoAsync();

        if (photo != null)
        {
           
            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

            using Stream sourceStream = await photo.OpenReadAsync();
            using FileStream localFileStream = File.OpenWrite(localFilePath);

            // Mostrar la foto en el objeto Image
            fotoImage.Source = ImageSource.FromStream(() => photo.OpenReadAsync().Result);


            await sourceStream.CopyToAsync(localFileStream);
        }
    }
}