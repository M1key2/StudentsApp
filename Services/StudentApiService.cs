using System.Net.Http.Json;
using StudentsApp.Models;

namespace StudentsApp.Services
{
    public class StudentApiService
    {
        private readonly HttpClient _http;

        public StudentApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _http.GetFromJsonAsync<List<Student>>("api/student") ?? new List<Student>();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _http.GetFromJsonAsync<Student>($"api/student/{id}");
        }

        public async Task<string> CreateStudent(Student student)
        {
            student.CreatedAt = DateTime.Now;
            var response = await _http.PostAsJsonAsync("api/student", student);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al crear estudiante: {response.StatusCode} - {content}");
            }

            return content; 
        }


        public async Task<HttpResponseMessage> UpdateStudent(Student student)
        {
            student.UpdatedAt = DateTime.Now;
            return await _http.PutAsJsonAsync($"api/student/{student.Id}", student);
        }


        public async Task DeleteStudent(int id)
        {
            await _http.DeleteAsync($"api/student/{id}");
        }
    }
}
