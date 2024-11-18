using CourseApp.DesktopUI.Utilities;
using CourseApp.EntityLayer.Dto.InstructorDto;
using CourseApp.ServiceLayer.Abstract;

namespace CourseApp.DesktopUI.Forms;

public partial class InstructorForm : BaseForm
{
    private readonly IInstructorService _instructorService;

    public InstructorForm(IInstructorService instructorService)
    {
        InitializeComponent();
        _instructorService = instructorService;
    }

    private async void InstructorForm_Load(object sender, EventArgs e)
    {
        await InstructorLoad();
    }

    private async Task InstructorLoad()
    {
        var instructorList = await _instructorService.GetAllAsync(false);
        lstListe.DataSource = instructorList.Data;
        lstListe.DisplayMember = "FullName";
        lstListe.ValueMember = "ID";
    }

    protected override async void btnList_Click(object sender, EventArgs e)
    {
        await InstructorLoad();
    }

    private async void lstListe_SelectedIndexChanged(object sender, EventArgs e)
    {
        string instructorId = lstListe.SelectedValue.ToString();

        var instructor = await _instructorService.GetByIdAsync(instructorId,false);

        if (instructor.IsSuccess)
        {
            txtAd.Text = instructor.Data.Name;
            txtSoyad.Text = instructor.Data.Surname;
            txtEmail.Text = instructor.Data.Email;
            txtUzmanlik.Text = instructor.Data.Professions;
            txtTelefon.Text = instructor.Data.PhoneNumber;
        }

    }

    protected async override void btnSave_Click(object sender, EventArgs e)
    {
        CreatedInstructorDto createdInstructorDto = new()
        {
            Name = txtAd.Text,
            Surname = txtSoyad.Text,
            Email = txtEmail.Text,
            PhoneNumber = txtTelefon.Text,
            Professions = txtUzmanlik.Text,
        };

        var result = await _instructorService.CreateAsync(createdInstructorDto);
        if (result.IsSuccess)
        {
            MessageBox.Show(result.Message);
        }
        else
        {
            MessageBox.Show(result.Message);
        }
    }

    protected override async void btnUpdate_Click(object sender, EventArgs e)
    {
        if(lstListe.SelectedItems != null)
        {
            UpdatedInstructorDto updatedInstructorDto = new()
            {
                Id = lstListe.SelectedValue.ToString(),
                Name = txtAd.Text,
                Surname = txtSoyad.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtTelefon.Text,
                Professions = txtUzmanlik.Text,
            };

            var result = await _instructorService.Update(updatedInstructorDto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
        else
        {
            MessageBox.Show(string.Format(UIMessages.ItemNotSelected, "Eğitmen"));
        }

    }

    protected override async void btnDelete_Click(object sender, EventArgs e)
    {
        if(lstListe.SelectedItems != null)
        {
            DeletedInstructorDto deletedInstructorDto = new()
            {
                Id = lstListe.SelectedValue.ToString(),
                Name = txtAd.Text,
                Surname= txtSoyad.Text, 
                Email = txtEmail.Text,
                PhoneNumber = txtTelefon.Text,  
                Professions= txtUzmanlik.Text,  
            };
            var result = await _instructorService.Remove(deletedInstructorDto);  
            if(result.IsSuccess)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
        else
        {
            MessageBox.Show(string.Format(UIMessages.ItemNotSelected, "Eğitmen"));
        }
    }

}
