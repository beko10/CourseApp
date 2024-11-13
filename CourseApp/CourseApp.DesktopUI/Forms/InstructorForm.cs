using CourseApp.EntityLayer.Dto.InstructorDto;
using CourseApp.ServiceLayer.Abstract;

namespace CourseApp.DesktopUI.Forms
{
    public partial class InstructorForm : BaseForm
    {
        private readonly IInstructorService _instructorService;
        private string selectedInstructorId;

        public InstructorForm(IInstructorService instructorService)
        {
            InitializeComponent();
            _instructorService = instructorService;
        }

        protected override async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Ad ve soyad alanları boş bırakılamaz!");
                return;
            }

            CreatedInstructorDto createInstructorDto = new CreatedInstructorDto
            {
                Name = txtAd.Text,
                Surname = txtSoyad.Text,
                Email = txtEmail.Text,
                Professions = txtUzmanlik.Text,
                PhoneNumber = txtTelefon.Text
            };

            var result = await _instructorService.CreateAsync(createInstructorDto);
            MessageBox.Show(result.Message);
            if (result.IsSuccess)
            {
                ClearForm();
                await LoadInstructors();
            }
        }

        protected override async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedInstructorId))
            {
                MessageBox.Show("Lütfen silinecek eğitmeni seçiniz.");
                return;
            }

            DeletedInstructorDto deletedInstructorDto = new DeletedInstructorDto
            {
                Id = selectedInstructorId,
                Name = txtAd.Text,
                Surname = txtSoyad.Text,
                Email = txtEmail.Text,
                Professions = txtUzmanlik.Text,
                PhoneNumber = txtTelefon.Text
            };

            var result = await _instructorService.Remove(deletedInstructorDto);
            MessageBox.Show(result.Message);
            if (result.IsSuccess)
            {
                ClearForm();
                await LoadInstructors();
            }
        }

        protected override async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedInstructorId))
            {
                MessageBox.Show("Lütfen güncellenecek eğitmeni seçiniz.");
                return;
            }

            UpdatedInstructorDto updatedInstructorDto = new UpdatedInstructorDto
            {
                Id = selectedInstructorId,
                Name = txtAd.Text,
                Surname = txtSoyad.Text,
                Email = txtEmail.Text,
                Professions = txtUzmanlik.Text,
                PhoneNumber = txtTelefon.Text
            };

            var result = await _instructorService.Update(updatedInstructorDto);
            MessageBox.Show(result.Message);
            if (result.IsSuccess)
            {
                ClearForm();
                await LoadInstructors();
            }
        }

        protected override async void btnList_Click(object sender, EventArgs e)
        {
            await LoadInstructors();
        }

        private async Task LoadInstructors()
        {
            var instructors = await _instructorService.GetAllAsync();
            lstListe.Items.Clear();

            if (instructors.IsSuccess && instructors.Data != null)
            {
                foreach (var instructor in instructors.Data)
                {
                    lstListe.Items.Add($"{instructor.FullName} - {instructor.Email} - {instructor.Professions} - {instructor.PhoneNumber}");
                }
            }
        }

        private void lstListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstListe.SelectedItem != null)
            {
                string selectedItem = lstListe.SelectedItem.ToString();
                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                selectedInstructorId = parts[0].Replace("ID:", "").Trim();

                var instructors = _instructorService.GetAllAsync().Result;
                var selectedInstructor = instructors.Data?.FirstOrDefault(i => i.Id == selectedInstructorId);

                if (selectedInstructor != null)
                {
                    txtAd.Text = selectedInstructor.Name;
                    txtSoyad.Text = selectedInstructor.Surname;
                    txtEmail.Text = selectedInstructor.Email;
                    txtUzmanlik.Text = selectedInstructor.Professions;
                    txtTelefon.Text = selectedInstructor.PhoneNumber;
                }
            }
        }

        private void ClearForm()
        {
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtUzmanlik.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            selectedInstructorId = null;
        }

        private void InstructorForm_Load(object sender, EventArgs e)
        {
            LoadInstructors();
        }
    }
}
