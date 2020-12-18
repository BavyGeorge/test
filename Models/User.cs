using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Intern.Models
{
    public class User
    {
        public User()
        {
            this.CreatedAt = DateTime.UtcNow;
        }
        // CP-> Complete Prfile - fields which will be filled after the email has been verfied
        // Auto -> fields which gets filled by the system

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        [Required]
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        public bool UserEmailVerified { get; set; } // Auto
        public string UserAddress { get; set; } //CP
        public string UserCity { get; set; } //CP
        public string UserState { get; set; } //CP
        public string UserCountry { get; set; } //CP
        public int UserZip { get; set; } //CP
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string Salt { get; set; } // Auto
        public string UniqueToken { get; set; } // Auto
        public string UserPhone { get; set; }
        public string UserImage { get; set; }
        public string UserGender { get; set; } // Could be use full for User with student role.



        [Required]
        public virtual Role Role { get; set; } //FK
        public DateTime CreatedAt { get; set; } // Auto
        public bool SoftDelete { get; set; } // Auto
        public List<Qualification> Qualifications { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<UserDocument> UserDocuments { get; set; } // should get one row
        public List<UserCompany> UserCompanies { get; set; } // should get one row
        public List<Profile> Profiles { get; set; } // should get one row
        public List<InternStudent> InternStudents { get; set; } // list of students who are working in some internships
        public List<AppliedInternship> appliedInternships { get; set; } // list of user applyed for intership

        // add on 6th 10 2020
        public List<Course> Course { get; set; }


        public void AddFromAccountRegsiter(AccountRegister newUser, Role role, string salt)
        {
            this.UserFirstName = newUser.FirstName;
            this.UserLastName = newUser.LastName;
            this.UserGender = newUser.Gender;
            this.UserEmail = newUser.Email;
            this.UserEmailVerified = false;
            this.UserPassword = newUser.Password;
            this.Salt = salt;
            this.UserPhone = newUser.Phone.ToString();
            this.Role = role;
            this.CreatedAt = DateTime.UtcNow;
            this.SoftDelete = false;
        }

        public void UpdateUser(User user)
        {
            UserFirstName = user.UserFirstName;
            UserLastName = user.UserLastName;
            UserAddress = user.UserAddress;
            UserCity = user.UserCity;
            Salt = user.Salt;
            UserPassword = user.UserPassword;
            UniqueToken = user.UniqueToken;
            CreatedAt = user.CreatedAt;
            UserEmail = user.UserEmail;
            UserState = user.UserState;
            UserCountry = user.UserCountry;
            UserZip = user.UserZip;
            UserPhone = user.UserPhone;
            UserImage = user.UserImage;
            UserGender = user.UserGender;
        }


        public void AddFromAccountGeneralProfile(Global_Intern.Models.GeneralProfile.GeneralProfile updatedInfo, string UserImagePATH = "")
        {
            this.UserFirstName = updatedInfo.UserFirstName;
            this.UserLastName = updatedInfo.UserLastName;
            this.UserGender = updatedInfo.UserGender;
            this.UserPhone = updatedInfo.UserPhone.ToString();
            if (UserImagePATH != "")
            {
                this.UserImage = UserImagePATH;
            }
        }

        public void AddFromStudentProfileView(Global_Intern.Models.GeneralProfile.ProfileViewStudent updatedInfo, string UserImagePATH = "")
        {
            UserFirstName = updatedInfo.UserFirstName;
            UserLastName = updatedInfo.UserLastName;
            UserGender = updatedInfo.UserGender;
            UserPhone = updatedInfo.UserPhone.ToString();
            UserAddress = updatedInfo.UserAddress;
            UserCity = updatedInfo.UserCity;
            UserState = updatedInfo.UserState;
            UserCountry = updatedInfo.UserCountry;
            // if user upload new image
            if (UserImagePATH != "")
            {
                this.UserImage = UserImagePATH;
            }
        }


        public void AddFromEmployerProfileView(Global_Intern.Models.GeneralProfile.ProfileViewEmployer updatedInfo, string UserImagePATH = "")
        {
            UserFirstName = updatedInfo.UserFirstName;
            UserLastName = updatedInfo.UserLastName;
            UserGender = updatedInfo.UserGender;
            UserPhone = updatedInfo.UserPhone.ToString();
            UserAddress = updatedInfo.UserAddress;
            UserCity = updatedInfo.UserCity;
            UserState = updatedInfo.UserState;
            UserCountry = updatedInfo.UserCountry;
            if (UserImagePATH != "")
            {
                this.UserImage = UserImagePATH;
            }
        }


        // for Dashboard Teacher
        public void AddFromTeacherProfileView(User updatedInfo, string UserImagePATH = "")
        {
            this.UserFirstName = updatedInfo.UserFirstName;
            this.UserLastName = updatedInfo.UserLastName;
            this.UserGender = updatedInfo.UserGender;
            this.UserPhone = updatedInfo.UserPhone.ToString();
            this.UserAddress = updatedInfo.UserAddress;
            this.UserCity = updatedInfo.UserCity;
            this.UserState = updatedInfo.UserState;
            this.UserCountry = updatedInfo.UserCountry;
            //updatedInfo.Salt="jnjn";
            if (UserImagePATH != "sss")
            {
                this.UserImage = "iiiiiii";
            }
        }




    }
}
