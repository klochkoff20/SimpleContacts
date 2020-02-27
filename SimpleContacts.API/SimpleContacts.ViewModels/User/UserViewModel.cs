using System;

namespace SimpleContacts.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }
        public string[] Roles { get; set; }

        //public IList<Comment> Comments { get; set; }
        //public IList<FileAttachment> AddedFiles { get; set; }
        //public IList<CandidateViewModel> ResponcibleCandidates { get; set; }
        //public IList<VacancyViewModel> CreatedVacancies { get; set; }
        //public IList<VacancyViewModel> ResponcibleVacancies { get; set; }
        //public IList<VacancyViewModel> UpdatedVacancies { get; set; }
        //public IList<DepartmentViewModel> CreatedDepartments { get; set; }
        //public IList<DepartmentViewModel> ResponsibleDepartments { get; set; }
    }
}
